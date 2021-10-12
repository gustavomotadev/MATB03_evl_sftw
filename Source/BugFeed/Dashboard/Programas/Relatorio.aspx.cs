using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Objects.Extensions;
using BugFeed.Pages;
using BugFeed.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnconstrainedMelody;

namespace BugFeed.Dashboard.Programas
{
  public partial class Relatorio : WebForm
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (this.Session["RelatorioBugId"] != null)
        this.LoadRelatorio();
      else
        this.Response.Redirect(Urls.ListaRelatorios);
    }

    protected void LoadRelatorio()
    {
      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        RelatorioBug loRelatorio = unitOfWork.RelatoriosBug.GetByID(Convert.ToInt32(this.Session["RelatorioBugId"]));
        this.lblTitulo.Text = loRelatorio.Titulo;
        this.lblData.Text = loRelatorio.Data.ToShortDateString();
        this.lblPesquisador.Text = " " + loRelatorio.Pesquisador.Usuario.Nome + " " + loRelatorio.Pesquisador.Usuario.Sobrenome;
        this.lblStatus.Text = Enums.GetDescription(loRelatorio.Estado);
        this.lblStatus.CssClass = String.Join(" ", lblStatus
             .CssClass
             .Split(' ')
             .Except(new string[] { "", loRelatorio.Estado.GetTextClass() })
             .Concat(new string[] { loRelatorio.Estado.GetTextClass() })
             .ToArray()
     );
        this.divAceitar.Visible = loRelatorio.Comentarios.Count > 0 && loRelatorio.Estado == EstadoRelatorioBug.EmAnalise;
        this.divPagamento.Visible = loRelatorio.Estado == EstadoRelatorioBug.Concluido;

        if (loRelatorio.Recompensa != null)
        {
          this.txtPagamento.Text = String.Format("{0:C}", loRelatorio.Recompensa.Valor);
          this.txtPagamento.Enabled = false;
          this.btPagamento.Visible = false;
        }

        this.lblImpacto.Text = loRelatorio.Impacto;
        this.divContent.InnerHtml = loRelatorio.Descricao;
        this.rptComentarios.DataSource = loRelatorio.Comentarios.OrderByDescending(i => i.UltimaRevisao).ToList();
        this.rptComentarios.DataBind();

        if (loRelatorio.Comentarios.Count > 0)
        {
          this.txtComentario.Visible = false;
          this.btSalvar.Visible = false;
        }
      }
    }

    protected void rptComentarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var loComentario = (ComentarioRelatorio)e.Item.DataItem;

        var lbUsuario = (Label)e.Item.FindControl("lblUsuarioComentario");
        var lbData = (Label)e.Item.FindControl("lblDataComentario");
        var lbComentario = (Label)e.Item.FindControl("lblComentario");

        lbUsuario.Text = loComentario.Usuario.Nome;
        lbData.Text = loComentario.UltimaRevisao.ToShortDateString();
        lbComentario.Text = loComentario.Conteudo;

      }

    }

    protected void btSalvar_Click(object sender, EventArgs e)
    {
      try
      {
        using (UnitOfWork loUnitOfWork = new UnitOfWork())
        {
          RelatorioBug loRelatorio = loUnitOfWork.RelatoriosBug.GetByID(Convert.ToInt32(this.Session["RelatorioBugId"]));

          ComentarioRelatorio loComentario = new ComentarioRelatorio();

          loComentario.Conteudo = this.txtComentario.Text.Trim();
          loComentario.Data = DateTime.Now;
          loComentario.DataHora = DateTime.Now;
          loComentario.UltimaRevisao = DateTime.Now;
          loComentario.Usuario = this.GetUsuario(loUnitOfWork.Context);
          loComentario.Relatorio = loRelatorio;

          loUnitOfWork.Comentario.Insert(loComentario);
          loUnitOfWork.Save();
          this.AddAlert("Resposta enviada com sucesso.");
          LoadRelatorio();
        }
      }
      catch (Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }

    protected void btPagamento_Click(object sender, EventArgs e)
    {
      try
      {
        using (UnitOfWork loUnitOfWork = new UnitOfWork())
        {
          RelatorioBug loRelatorio = loUnitOfWork.RelatoriosBug.GetByID(Convert.ToInt32(this.Session["RelatorioBugId"]));
          Recompensa loRecompensa = new Recompensa();

          loRecompensa.Estado = EstadoRecompensa.ARetirar;
          loRecompensa.Pagador = loUnitOfWork.Funcionario.FindByUsername(this.User.Identity.Name);
          loRecompensa.Relatorio = loRelatorio;
          loRecompensa.Valor = decimal.Parse(this.txtPagamento.Text.Replace(",", ".").Replace("R$", ""), CultureInfo.InvariantCulture);
          loRecompensa.Avaliador = loUnitOfWork.Funcionario.FindByUsername(this.User.Identity.Name);

          loRelatorio.Recompensa = loRecompensa;

          loUnitOfWork.RelatoriosBug.Update(loRelatorio);
          loUnitOfWork.Save();
          this.AddAlert("O pagamento foi realizado com sucesso.");
          LoadRelatorio();
        }
      }
      catch (Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }

    protected void btRecusar_Click(object sender, EventArgs e)
    {
      this.AnalisarRelatorio(false);
    }

    protected void btAceitar_Click(object sender, EventArgs e)
    {
      this.AnalisarRelatorio(true);
    }

    protected void AnalisarRelatorio(bool aceitar)
    {
      try
      {
        using (UnitOfWork loUnitOfWork = new UnitOfWork())
        {
          RelatorioBug loRelatorio = loUnitOfWork.RelatoriosBug.GetByID(Convert.ToInt32(this.Session["RelatorioBugId"]));

          loRelatorio.Estado = aceitar ? EstadoRelatorioBug.Concluido : EstadoRelatorioBug.Recusado;

          loUnitOfWork.RelatoriosBug.Update(loRelatorio);
          loUnitOfWork.Save();
          this.AddAlert("O relatório foi analisado com sucesso.");
          this.LoadRelatorio();
        }
      }
      catch (Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }
  }
}
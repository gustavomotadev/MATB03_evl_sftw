using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Objects.Extensions;
using BugFeed.Pages.Dashboard;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnconstrainedMelody;

namespace BugFeed.Dashboard.Pesquisador
{
  public partial class Recompensas : DashboardPage
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      if (!this.IsPostBack)
        LoadRepeater();
    }

    protected void LoadRepeater()
    {
      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        string userId = User.Identity.GetUserId();
        List<RelatorioBug> relatorios = unitOfWork.RelatoriosBug.Get(r => r.Pesquisador.Usuario.Id == userId && r.Recompensa != null).ToList();
        this.rptRecompensas.DataSource = relatorios;
        this.rptRecompensas.DataBind();
      }
    }


    private void Retirar(RepeaterCommandEventArgs e)
    {
      throw new NotImplementedException();
    }

    protected void rptRecompensas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var relatorio = (RelatorioBug)e.Item.DataItem;

        var cbRetirar = (HtmlInputCheckBox)e.Item.FindControl("cbRetirar");
        var tdValor = (HtmlTableCell)e.Item.FindControl("tdValor");
        var tdEstado = (HtmlTableCell)e.Item.FindControl("tdEstado");

        cbRetirar.Disabled = relatorio.Recompensa.Estado != EstadoRecompensa.ARetirar;
        cbRetirar.Attributes["data-id"] = relatorio.Recompensa.RecompensaId.ToString();
        tdValor.InnerText = string.Format("{0:C}", relatorio.Recompensa.Valor);

        tdEstado.InnerText = Enums.GetDescription(relatorio.Recompensa.Estado);
        tdEstado.Attributes["class"] = relatorio.Estado.GetTextClass();
      }
    }

    protected void btRetirar_Click(object sender, EventArgs e)
    {
      try
      {
        List<int> idsRecompensas = new List<int>();
        foreach (RepeaterItem item in this.rptRecompensas.Items)
        {
          var cbRetirar = (HtmlInputCheckBox)item.FindControl("cbRetirar");
          if (cbRetirar.Checked)
          {
            var relatorio = (RelatorioBug)item.DataItem;
            idsRecompensas.Add(Convert.ToInt32(cbRetirar.Attributes["data-id"]));
          }
        }

        if (idsRecompensas.Count == 0)
          throw new InvalidOperationException("Selecione ao menos uma recompensa para retirar.");

        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
          List<Recompensa> recompensas = unitOfWork.Recompensas.Get(r => idsRecompensas.Contains(r.RecompensaId)).ToList();
          recompensas.ForEach(r => {
            r.Estado = EstadoRecompensa.Processando;
            unitOfWork.Recompensas.Update(r);
          });
          unitOfWork.Save();
          LoadRepeater();
          this.AddAlert("As recompensas selecionadas estão sendo processadas.");
        }
      }
      catch(Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }
  }
}
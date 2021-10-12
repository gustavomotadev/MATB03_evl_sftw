using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Pages;
using BugFeed.Pages.Dashboard;
using BugFeed.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BugFeed.Dashboard.Programas
{
  public partial class AnalisarRelatorios : WebForm
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        Empresa empresa = this.GetUsuario(unitOfWork.Context).Funcionario.Grupo.Empresa;
        List<ProgramaRecompensas> programas = unitOfWork.ProgramasRecompensas.FindByEmpresa(empresa);
        this.rptProgramas.DataSource = programas;
        this.rptProgramas.DataBind();
      }
    }
    protected void rptProgramas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var programa = (ProgramaRecompensas)e.Item.DataItem;

        var tdEstado = (HtmlTableCell)e.Item.FindControl("tdEstado");
        var tdQntRelatorios = (HtmlTableCell)e.Item.FindControl("tdQntRelatorios");
        var spnOrcamento = (HtmlGenericControl)e.Item.FindControl("spnOrcamento");
        var divOrcamentoProgress = (HtmlGenericControl)e.Item.FindControl("divOrcamentoProgress");
        var tdData = (HtmlTableCell)e.Item.FindControl("tdData");

        var lbRelatorios = (LinkButton)e.Item.FindControl("lbRelatorios");
        //var tdQntRelatorios = (HtmlGenericControl)e.Item.FindControl("tdQntRelatorios");

        tdQntRelatorios.InnerText = programa.Relatorios.Count.ToString();

        decimal valorGasto = programa.Relatorios.Select(r => r.Recompensa).Where(r => r != null).Sum(r => r.Valor);
        spnOrcamento.InnerText = String.Format("R$ {0} / {1}",
          valorGasto,
          programa.Orcamento);

        decimal porcentagem = programa.Orcamento == 0 ? 0 : valorGasto / programa.Orcamento * 100;
        divOrcamentoProgress.Style[HtmlTextWriterStyle.Width] = porcentagem.ToString("0") + "%";

        tdData.InnerText = programa.DataCriacao.ToShortDateString();

        lbRelatorios.Command += LbRelatorios_Command;
        lbRelatorios.CommandArgument = programa.ProgramaRecompensasId.ToString();
      }
    }
    private void LbRelatorios_Command(object sender, CommandEventArgs e)
    {
      this.Session["ProgramaRecompensasId"] = e.CommandArgument;
      this.Response.Redirect(Urls.ListaRelatorios);
    }
  }
}

using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Pages.Dashboard;
using BugFeed.Properties;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BugFeed.Dashboard.Pesquisador
{
  public partial class ProgramasAbertos : DashboardPage
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        List<ProgramaRecompensas> programas = unitOfWork.ProgramasRecompensas.Get(p => p.Estado == EstadoProgramaRecompensa.Ativo).OrderByDescending(p => p.DataCriacao).ToList();
        this.rptProgramas.ItemCommand += RptProgramas_ItemCommand;
        this.rptProgramas.DataSource = programas;
        this.rptProgramas.DataBind();
      }
    }

    private void RptProgramas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      if (e.CommandName == "Editar")
        this.EnviarRelatorio(e);
      else if (e.CommandName == "Ver")
        this.VerRelatorio(e);
    }

    private void VerRelatorio(RepeaterCommandEventArgs e)
    {
      this.Session["ProgramaRecompensasId"] = e.CommandArgument;
      this.Response.Redirect(Urls.ProgramaPesquisador);
    }

    protected void rptProgramas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var programa = (ProgramaRecompensas)e.Item.DataItem;
        
        var tdQntRelatorios = (HtmlTableCell)e.Item.FindControl("tdQntRelatorios");
        var tdData = (HtmlTableCell)e.Item.FindControl("tdData");
        var btVerRelatorio = (Button)e.Item.FindControl("btVerRelatorio");
        var btEnviarRelatorio = (Button)e.Item.FindControl("btEnviarRelatorio");
        //var tdQntRelatorios = (HtmlGenericControl)e.Item.FindControl("tdQntRelatorios");

        tdQntRelatorios.InnerText = programa.Relatorios
          .Where(r => r.Pesquisador.Usuario.Id == User.Identity.GetUserId())
          .Count().ToString();
        
        tdData.InnerText = programa.DataCriacao.ToShortDateString();

        btVerRelatorio.CommandArgument = programa.ProgramaRecompensasId.ToString();
        btEnviarRelatorio.CommandArgument = programa.ProgramaRecompensasId.ToString();
      }
    }

    protected void EnviarRelatorio(RepeaterCommandEventArgs e)
    {
      this.Session["ProgramaRecompensasId"] = e.CommandArgument;
      this.Response.Redirect(Urls.EnviarRelatorio);
    }

  }
}
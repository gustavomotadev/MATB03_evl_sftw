using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Pages.Dashboard;
using BugFeed.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.Dashboard.Pesquisador
{
  public partial class Programa : DashboardPage
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      if (this.Session["ProgramaRecompensasId"] != null)
      {
        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
          ProgramaRecompensas programa = unitOfWork.ProgramasRecompensas.GetByID(Convert.ToInt32(this.Session["ProgramaRecompensasId"]));
          this.h3Titulo.InnerText = String.Format("{0}: {1}", programa.Empresa.Nome, programa.Titulo);
          this.divContent.InnerHtml = programa.Descricao;
        }
      }
      else
        this.Response.Redirect(Urls.ProgramasAbertos);
    }

    protected void btEnviar_Click(object sender, EventArgs e)
    {
      this.Response.Redirect(Urls.EnviarRelatorio);
    }
  }
}
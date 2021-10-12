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
using System.Web.UI.WebControls;

namespace BugFeed.Dashboard
{
  public partial class Default : DashboardPage
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);

      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        Usuario usuario = this.GetUsuario(unitOfWork.Context);
        if (usuario.Pesquisador != null)
          this.Response.Redirect(Urls.DashboardPesquisador);
        else if (usuario.Funcionario != null)
          this.Response.Redirect(Urls.GerenciamentoProgramas);
      }
    }
  }
}
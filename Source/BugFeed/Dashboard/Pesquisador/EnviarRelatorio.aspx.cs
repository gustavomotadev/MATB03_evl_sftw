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
  public partial class EnviarRelatorio : DashboardPage
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
        }
      }
      else
        this.Response.Redirect(Urls.ProgramasAbertos);
    }

    protected void btCancelar_Click(object sender, EventArgs e)
    {
      this.Response.Redirect(Urls.ProgramasAbertos);
    }

    protected void btSalvar_Click(object sender, EventArgs e)
    {
      try
      {
        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
          Usuario usuario = this.GetUsuario(unitOfWork.Context);
          ProgramaRecompensas programa = unitOfWork.ProgramasRecompensas.GetByID(Convert.ToInt32(this.Session["ProgramaRecompensasId"]));

          RelatorioBug relatorio = new RelatorioBug
          {
            Titulo = this.txtTitulo.Text.Trim(),
            Impacto = this.txtImpacto.Text.Trim(),
            Descricao = this.txtDescricao.Text.Trim(),
            Estado = EstadoRelatorioBug.EmAnalise,
            Pesquisador = usuario.Pesquisador,
            Programa = programa,
            Data = DateTime.Now
          };

          unitOfWork.RelatoriosBug.Insert(relatorio);
          unitOfWork.Save();
          this.Response.Redirect(Urls.ProgramasAbertos);
        }
      
      }
      catch(Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }
  }
}
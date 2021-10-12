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

namespace BugFeed.Dashboard.Programas
{
  public partial class Novo : WebForm
  {
    protected void btSalvar_Click(object sender, EventArgs e)
    {
      try
      {
        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
          ProgramaRecompensas programa = unitOfWork.Context.ProgramasRecompensas.Create();
          Usuario usuario = this.GetUsuario(unitOfWork.Context);
          
          programa.Titulo = this.txtTitulo.Text.Trim();
          programa.Estado = EstadoProgramaRecompensa.Ativo;
          programa.Descricao = this.txtDescricao.Text.Trim();
          programa.Empresa = usuario.Funcionario.Grupo.Empresa;
          programa.Orcamento = Convert.ToDecimal(this.txtOrcamento.Text.Replace(",","").Replace(".", "").Replace("R$", ""));
          programa.DataCriacao = DateTime.Now;

          unitOfWork.ProgramasRecompensas.Insert(programa);
          unitOfWork.Save();
          this.AddAlert("O programa de recompensas foi criado.");
          this.LimparCampos();
        }
      }
      catch (Exception ex)
      {
        this.AddErrorAlert(ex.Message);
      }
    }

    private void LimparCampos()
    {
      this.txtDescricao.Text = String.Empty;
      this.txtOrcamento.Text = String.Empty;
      this.txtTitulo.Text = String.Empty;
    }


    protected void btCancelar_Click(object sender, EventArgs e)
    {
      this.Response.Redirect(Urls.GerenciamentoProgramas);
    }
  }
}
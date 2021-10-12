using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Pages;
using BugFeed.Properties;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.SignUp
{
  public partial class Business : WebForm
  {
    public string Senha
    {
      get
      {
        if (this.txtPassword.Text != this.txtConfirmaSenha.Text)
          throw new ValidationException("As senhas devem ser iguais.");
        return this.txtPassword.Text;
      }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
      if (this.IsFormValid("RegisterForm"))
      {
        try
        {
          using (UnitOfWork unitOfWork = new UnitOfWork())
          {
            DbContextTransaction transaction = unitOfWork.Context.Database.BeginTransaction();
            var userStore = new UserStore<Usuario>(unitOfWork.Context);
            var manager = new UserManager<Usuario>(userStore);

            this.ValidaUsernameEmail(manager, unitOfWork);

            Usuario usuario = this.GetUsuario();
            var result = manager.Create(usuario, this.Senha);
            if (result.Succeeded)
            {
              Empresa empresa = this.GetEmpresa();
              unitOfWork.Empresas.Insert(empresa);
              empresa = unitOfWork.Empresas.GetByID(empresa.EmpresaId);

              empresa.GrupoFuncionarios.First().Funcionarios = new List<Funcionario>
              {
                new Funcionario { Usuario = usuario }
              };

              unitOfWork.Save();
              transaction.Commit();

              var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
              var userIdentity = manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
              authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

              Response.Redirect(Urls.SignIn);
            }
            else
            {
              transaction.Rollback();
              result.Errors.ToList().ForEach(er => this.AddErrorAlert(er));
            }
          }
        }
        catch (Exception ex)
        {
          this.AddErrorAlert(ex.Message);
        }
      }
    }

    private void ValidaUsernameEmail(UserManager<Usuario> aoManager, UnitOfWork aoUnitiOfWork)
    {
      Usuario loUsuario = aoManager.FindByEmail(this.txtEmail.Text);
      if (loUsuario != null)
        throw new ValidationException("Já existe uma conta associada a esse email.");
    }
    private Usuario GetUsuario()
    {
      return new Usuario
      {
        DataNascimento = this.dtDatePicker.DateTime,
        Ativo = true,
        Nome = this.txtNome.Text,
        Email = this.txtEmail.Text,
        UserName = this.txtUsername.Text,
        Sobrenome = this.txtSobrenome.Text
      };
    }

    private Empresa GetEmpresa()
    {
      return new Empresa
      {
        Nome = this.txtNome.Text,
        Site = this.txtSite.Text,
        Endereco = new Endereco()
        {
          Destinatario = this.txtDestinatario.Text,
          Linha1 = this.txtComplemento.Text,
          Bairro = this.txtBairro.Text,
          Cidade = this.txtCidade.Text,
          Estado = this.txtEstado.Text,
          Pais = this.txtPais.Text
        },
        GrupoFuncionarios = new List<GrupoFuncionarios>()
        {
          new GrupoFuncionarios()
          {
            Permissoes = new List<Permissao>() {
                new Permissao() {
                  Perfil = Perfil.Admin
                }
              }
          }
        }
      };
    }
  }
}
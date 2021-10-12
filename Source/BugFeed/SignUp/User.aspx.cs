using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Pages;
using BugFeed.Properties;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.SignUp
{
  public partial class User : WebForm
  {
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

            Usuario usuario = new Usuario
            {
              Nome = this.CadastroUsuario.Nome,
              Sobrenome = this.CadastroUsuario.Sobrenome,
              UserName = this.CadastroUsuario.Username,
              Email = this.CadastroUsuario.Email,
              Ativo = false,
              DataNascimento = this.CadastroUsuario.DataNascimento
            };

            var result = manager.Create(usuario, this.CadastroUsuario.Senha);

            if (result.Succeeded)
            {
              Pesquisador pesquisador = new Pesquisador { Usuario = usuario };
              unitOfWork.Pesquisadores.Insert(pesquisador);

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
  }
}
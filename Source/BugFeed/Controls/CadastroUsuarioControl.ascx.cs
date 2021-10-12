using BugFeed.DAL;
using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.Controls
{
  public partial class CadastroUsuarioControl : System.Web.UI.UserControl
  {
    public string Nome { get { return this.txtNome.Text; } }
    public string Sobrenome { get { return this.txtSobrenome.Text; } }
    public string Username { get { return this.txtUsername.Text; } }
    public string Email { get { return this.txtEmail.Text; } }
    public string Senha
    {
      get {
        if (this.txtPassword.Text != this.txtConfirmaSenha.Text)
          throw new ValidationException("As senhas devem ser iguais.");
        return this.txtPassword.Text;
      }
    }
    public string ConfirmarSenha { get { return this.txtConfirmaSenha.Text; } }
    public DateTime DataNascimento { get { return this.dtDatePicker.DateTime; } }
  }
}
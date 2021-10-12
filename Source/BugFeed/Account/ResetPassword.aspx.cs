using BugFeed.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.Account
{
  public partial class ResetPassword : WebForm
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnRecuperar_Click(object sender, EventArgs e)
    {
      if (this.IsFormValid("ResetPassword"))
      {
        this.AddAlert("Um email será enviado com um link de redefinição de senha.");
      }
    }
  }
}
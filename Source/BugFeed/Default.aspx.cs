using BugFeed.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed
{
  public partial class Default : WebForm
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.loggedInMenu.Visible = User.Identity.IsAuthenticated;
      this.loggedOutMenu.Visible = !this.loggedInMenu.Visible;
    }
  }
}
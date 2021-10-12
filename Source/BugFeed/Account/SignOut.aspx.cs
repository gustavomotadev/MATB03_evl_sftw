using BugFeed.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed
{
  public partial class SignOut : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
      authenticationManager.SignOut();
      this.Session.Clear();
      Response.Redirect("~/");
    }
  }
}
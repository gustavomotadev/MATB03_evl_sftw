using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Properties;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugFeed.Pages.Dashboard
{
  public class DashboardPage : WebForm
  {

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.LoadUser();
    }

    protected virtual void LoadUser()
    {
      if (!this.User.Identity.IsAuthenticated)
        this.Response.Redirect(Urls.SignIn);
      else
      {
        this.ValidatePermissions();
      }
    }

    protected virtual void ValidatePermissions()
    {
      var teste = true;
      if (!teste)
        this.Response.Redirect("~/Error/Unauthorized.aspx");
    }

  }
}
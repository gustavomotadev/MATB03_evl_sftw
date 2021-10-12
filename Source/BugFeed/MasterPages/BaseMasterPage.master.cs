using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace BugFeed.MasterPages
{
  public partial class BaseMasterPage : System.Web.UI.MasterPage
  {
    public virtual string BodyClass => "";
    protected HtmlGenericControl PageBody => this.Master != null ? (HtmlGenericControl)this.Master.FindControl("body") : null;

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      if (this.PageBody != null)
        this.PageBody.Attributes["class"] = this.BodyClass;
    }
  }
}
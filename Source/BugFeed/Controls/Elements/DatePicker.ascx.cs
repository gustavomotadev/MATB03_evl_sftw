using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.Controls.Elements
{
  public partial class DatePicker : System.Web.UI.UserControl
  {
    public DateTime DateTime
    {
      get
      {
        try
        {
          return Convert.ToDateTime(this.txtDateTime.Text);
        }
        catch(FormatException ex)
        {
          throw new FormatException("A data inserida é inválida.", ex);
        }
        
      }
    }
  }
}
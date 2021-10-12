using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BugFeed.Objects.Extensions
{
  public static class PageExtensions
  {
    public static string GetGravatarUrl(this Page page, int size = 200)
    {
      return String.Format("https://www.gravatar.com/avatar/{0}.jpg?s={1}", page.Session["Gravatar"], size);
    }
  }
}

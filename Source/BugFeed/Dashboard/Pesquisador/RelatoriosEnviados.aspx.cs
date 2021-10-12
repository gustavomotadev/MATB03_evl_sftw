using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Objects.Extensions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnconstrainedMelody;

namespace BugFeed.Dashboard.Pesquisador
{
  public partial class RelatoriosEnviados : System.Web.UI.Page
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      using (UnitOfWork unitOfWork = new UnitOfWork())
      {
        string userId = User.Identity.GetUserId();
        List<RelatorioBug> relatorios = unitOfWork.RelatoriosBug.Get(r => r.Pesquisador.Usuario.Id == userId).ToList();
        this.rptRelatorios.DataSource = relatorios.Count > 10 ? relatorios.GetRange(0, 10) : relatorios;
        this.rptRelatorios.DataBind();
      }
    }

    protected void rptRelatorios_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var relatorio = (RelatorioBug)e.Item.DataItem;

        var tdData = (HtmlTableCell)e.Item.FindControl("tdData");
        var tdEstado = (HtmlTableCell)e.Item.FindControl("tdEstado");

        tdData.InnerText = relatorio.Data.ToShortDateString();
        tdEstado.InnerText = Enums.GetDescription(relatorio.Estado);
        tdEstado.Attributes["class"] = relatorio.Estado.GetTextClass();
      }
    }
  }
}
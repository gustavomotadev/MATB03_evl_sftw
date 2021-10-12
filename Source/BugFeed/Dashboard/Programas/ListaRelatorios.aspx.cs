using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Objects.Extensions;
using BugFeed.Pages;
using BugFeed.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnconstrainedMelody;

namespace BugFeed.Dashboard.Programas
{
  public partial class ListaRelatorios : WebForm
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (this.Session["ProgramaRecompensasId"] != null) {
        using (UnitOfWork unitOfWork = new UnitOfWork())
        {
          ProgramaRecompensas loProgramaRecompensa = unitOfWork.ProgramasRecompensas.GetByID(Convert.ToInt32(this.Session["ProgramaRecompensasId"]));
          this.rptProgramas.DataSource = loProgramaRecompensa.Relatorios;
          this.rptProgramas.DataBind();
        }
      }
      else
        this.Response.Redirect(Urls.AnalisarRelatorio);      
    }
    protected void rptProgramas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var loRelatorio = (RelatorioBug)e.Item.DataItem;

        var tdData = (HtmlTableCell)e.Item.FindControl("tdData");
        var tdEstado = (HtmlTableCell)e.Item.FindControl("tdEstado");

        var lbAnalisar = (LinkButton)e.Item.FindControl("lbAnalisar");

        tdEstado.InnerText = Enums.GetDescription(loRelatorio.Estado);
        tdEstado.Attributes["class"] = loRelatorio.Estado.GetTextClass();

        tdData.InnerText = loRelatorio.Data.ToShortDateString();

        lbAnalisar.Command += LbAnalisar_Command;
        lbAnalisar.CommandArgument = loRelatorio.RelatorioBugId.ToString();

      }
    }
    private void LbAnalisar_Command(object sender, CommandEventArgs e)
    {
      this.Session["RelatorioBugId"] = e.CommandArgument;
      this.Response.Redirect(Urls.Relatorio);
    }
  }
}
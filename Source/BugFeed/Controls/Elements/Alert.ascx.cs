using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugFeed.Controls.Elements
{
  public partial class Alert : System.Web.UI.UserControl
  {
    public string Title { get; set; }
    public bool Dismissible { get; set; } = true;
    public AlertSkin Skin { get; set; }
    public AlertType Type { get; set; }
    public string Message { get; set; }

    protected string AlertClasses
    {
      get
      {
        List<string> classes = new List<string>();

        classes.Add("alert");

        classes.Add(this.TypeClass);
        classes.Add(this.SkinClass);

        if (this.Dismissible)
          classes.Add("alert-dismissible");

        return string.Join(" ", classes.ToArray());
      }
    }

    #region Skin

    public enum AlertSkin
    {
      Success,
      Primary,
      Warning,
      Danger
    }

    private string SkinClass
    {
      get
      {
        switch (this.Skin)
        {
          default:
          case AlertSkin.Success:
            return "alert-success";
          case AlertSkin.Primary:
            return "alert-primary";
          case AlertSkin.Warning:
            return "alert-warning";
          case AlertSkin.Danger:
            return "alert-danger";
        }
      }
    }

    protected string IconClass
    {
      get
      {
        switch (this.Skin)
        {
          default:
          case AlertSkin.Success:
            return "mdi mdi-check";
          case AlertSkin.Primary:
            return "mdi mdi-info-outline";
          case AlertSkin.Warning:
            return "mdi mdi-alert-triangle";
          case AlertSkin.Danger:
            return "mdi mdi-close-circle-o";
        }
      }
    }

    protected string AlertTitle
    {
      get
      {
        switch (this.Skin)
        {
          default:
          case AlertSkin.Success:
            return "Sucesso!";
          case AlertSkin.Primary:
            return "Informação!";
          case AlertSkin.Warning:
            return "Atenção!";
          case AlertSkin.Danger:
            return "Erro!";
        }
      }
    }

    #endregion Skin

    #region Type
    public enum AlertType
    {
      Default,
      Contrasts,
      Icon,
      BorderColor,
      IconColored,
      Basic
    }

    private string TypeClass
    {
      get
      {
        switch (this.Type)
        {
          default:
          case AlertType.Default:
            return "";
          case AlertType.Contrasts:
            return "alert-contrast";
          case AlertType.Icon:
            return "alert-icon";
          case AlertType.BorderColor:
            return "alert-icon alert-icon-border";
          case AlertType.IconColored:
            return "alert-icon alert-icon-colored";
          case AlertType.Basic:
            return "alert-simple";
        }
      }
    }

    #endregion
  }
}
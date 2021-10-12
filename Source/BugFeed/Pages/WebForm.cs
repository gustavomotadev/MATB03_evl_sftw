using BugFeed.Controls.Elements;
using BugFeed.DAL;
using BugFeed.Database;
using BugFeed.Objects.Utils;
using BugFeed.Properties;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BugFeed.Controls.Elements.Alert;

namespace BugFeed.Pages
{
  public class WebForm : Page
  {
    private Panel AlertsPanel { get; set; }
    private List<Alert> Alerts { get; set; } = new List<Alert>();

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      if (User.Identity.IsAuthenticated && this.Session["LoadedProfile"] == null)
        this.LoadProfileInfo();
    }
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.OnLoadPageControls(e);
      this.ClearAlerts();
    }

    public Usuario GetUsuario(BugFeedContext context = null)
    {
      var userStore = new UserStore<Usuario>(context);
      var userManager = new UserManager<Usuario>(userStore);
      string userId = this.User.Identity.GetUserId();
      return userManager.FindById(userId);
    }

    protected override void OnLoadComplete(EventArgs e)
    {
      this.RenderAlerts();
      base.OnLoadComplete(e);
    }

    /// <summary>
    /// Limpar os alertas da página
    /// </summary>
    protected void ClearAlerts()
    {
      if (this.AlertsPanel != null)
        this.AlertsPanel.Controls.Clear();
    }

    /// <summary>
    /// Carregar os controles padrão da página
    /// </summary>
    /// <param name="e"></param>
    protected void OnLoadPageControls(EventArgs e)
    {
      this.AlertsPanel = (Panel)this.FindControlRecursive((Control) this.Master ?? this, "pnAlerts");
    }

    #region Alerts

    /// <summary>
    /// Adicionar alerta na página
    /// </summary>
    /// <param name="type"></param>
    /// <param name="skin"></param>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="dismissible"></param>
    /// <returns></returns>
    public bool AddAlert(string message, AlertType type = AlertType.Default, AlertSkin skin = AlertSkin.Success, bool dismissible = true)
    {
      if (this.AlertsPanel == null)
        return false;

      this.Alerts.Add(new Alert
      {
        Type = type,
        Skin = skin,
        Message = message,
        Dismissible = dismissible
      });

      return true;
    }

    /// <summary>
    /// Adicionar alerta de erro
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool AddErrorAlert(string message)
    {
      return this.AddAlert(message, skin: AlertSkin.Danger);
    }

    /// <summary>
    /// Adicionar alerta primário
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool AddPrimaryAlert(string message)
    {
      return this.AddAlert(message, skin: AlertSkin.Primary);
    }

    /// <summary>
    /// Adicionar alerta primário
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool AddWarningAlert(string message)
    {
      return this.AddAlert(message, skin: AlertSkin.Warning);
    }

    /// <summary>
    /// Renderizar alertas na tela
    /// </summary>
    private void RenderAlerts()
    {
      foreach (var group in this.Alerts.GroupBy(a => a.Skin))
      {
        Alert alert = (Alert)this.LoadControl("~/Controls/Elements/Alert.ascx");

        alert.Skin = group.Key;

        if (group.Count() > 1)
        {
          StringBuilder builder = new StringBuilder();
          builder.Append("<ul>");
          group.ToList().ForEach(a =>
          {
            builder.Append(String.Format("<li>{0}</li>", a.Message));
          });
          builder.Append("</ul>");
          alert.Message = builder.ToString();
        }
        else
        {
          Alert alertObj = group.First();
          alert.Message = alertObj.Message;
          alert.Dismissible = alertObj.Dismissible;
          alert.Type = alertObj.Type;
        }
        
        this.AlertsPanel.Controls.Add(alert);
      }
    }

    #endregion Alerts

    public Control FindControlRecursive(Control container, string name)
    {
      if ((container.ID != null) && (container.ID.Equals(name)))
        return container;

      foreach (Control ctrl in container.Controls)
      {
        Control foundCtrl = FindControlRecursive(ctrl, name);
        if (foundCtrl != null)
          return foundCtrl;
      }
      return null;
    }

    protected bool IsFormValid(string validationGroup = null)
    {
      this.Validate();

      List<IValidator> notValidValidators = (string.IsNullOrWhiteSpace(validationGroup) ? this.Validators : this.GetValidators(validationGroup))
        .Cast<IValidator>().ToList().FindAll(v => !v.IsValid);

      notValidValidators.ForEach(v =>
      {
        this.AddAlert(skin: AlertSkin.Danger, message: v.ErrorMessage);
      });

      return notValidValidators.Count == 0;
    }

    protected void LoadProfileInfo()
    {
      using (UnitOfWork unifOfWork = new UnitOfWork())
      {
        Usuario usuario = this.GetUsuario(unifOfWork.Context);
        this.Session["Gravatar"] = MD5Hash.Calculate(usuario.Email.Trim().ToLower()).ToLower();
        this.Session["Usuario"] = usuario.UserName;
        this.Session["Nome"] = usuario.Nome;
        this.Session["Sobrenome"] = usuario.Sobrenome;
        this.Session["NomeSobrenome"] = usuario.Nome + " " + usuario.Sobrenome;
        this.Session["DataNascimento"] = usuario.DataNascimento;
        this.Session["LoadedProfile"] = true;
      }
    }
  }
}
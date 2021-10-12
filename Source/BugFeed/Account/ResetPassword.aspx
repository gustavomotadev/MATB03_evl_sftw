<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="BugFeed.Account.ResetPassword" MasterPageFile="~/MasterPages/SplashScreenMasterPage.master" Title="Recuperar senha" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="upAlerts" runat="server">
    <ContentTemplate>
      <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtEmailUsername" runat="server" ValidationGroup="ResetPassword" ErrorMessage="O campo <b>Email ou Usuário</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
      <div class="be-wrapper be-login">
        <div class="be-content">
          <div class="main-content container-fluid">
            <div class="splash-container">
              <div class="card card-border-color card-border-color-primary">
                <div class="card-header">
                  <img src="/assets/img/logo@2x.png" alt="logo" width="102" height="27" class="logo-img"><span class="splash-description">Digite seu email ou usuário abaixo para receber um link com instruções para redefinir sua senha.</span>
                </div>
                <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
                <div class="card-body">
                  <div class="form-group">
                    <asp:TextBox runat="server" ID="txtEmailUsername" CssClass="form-control" placeholder="Email ou Usuário"></asp:TextBox>
                  </div>
                  <div class="form-group login-submit">
                    <asp:Button ID="btnRecuperar" runat="server" CssClass="btn btn-primary btn-xl" Text="Recuperar senha" data-dismiss="modal" OnClick="btnRecuperar_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

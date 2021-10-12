<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuarioControl.ascx.cs" Inherits="BugFeed.Controls.CadastroUsuarioControl" %>
<div class="form-group row sign-up">
  <div class="col-6">
    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Nome"></asp:TextBox>
  </div>
  <div class="col-6">
    <asp:TextBox runat="server" ID="txtSobrenome" CssClass="form-control" placeholder="Sobrenome"></asp:TextBox>
  </div>
</div>
<div class="form-group">
  <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Username"></asp:TextBox>
</div>
<div class="form-group">
  <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="E-mail"></asp:TextBox>
</div>
<div class="form-group row signup-password">
  <div class="col-6">
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Senha"></asp:TextBox>
  </div>
  <div class="col-6">
    <asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirmar senha"></asp:TextBox>
  </div>
</div>
<div class="form-group">
  <uc:DatePicker ID="dtDatePicker" runat="server"></uc:DatePicker>
</div>


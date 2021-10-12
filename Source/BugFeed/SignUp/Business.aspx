<%@ Page Title="Cadastro de Empresas" Language="C#" MasterPageFile="~/MasterPages/SplashScreenMasterPage.master" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="BugFeed.SignUp.Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtNome" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Nome</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtSobrenome" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Sobrenome</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtUsername" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Username</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtEmail" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Email</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtPassword" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Confirmar Senha</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtConfirmaSenha" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Usuário</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <%--<asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="dtDatePicker" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Data de aniversário</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>--%>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtNomeEmpresa" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Nome Empresa</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtCNPJ" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>CNPJ</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtSite" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Site</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtDestinatario" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Endereço</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <%--  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtComplemento" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Complemento</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>--%>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtBairro" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Bairro</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtCidade" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Cidade</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtEstado" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>Estado</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="txtPais" runat="server" ValidationGroup="RegisterForm" ErrorMessage="O campo <b>País</b> é obrigatório." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>
  <%--<asp:RequiredFieldValidator SkinID="RequiredValidator" ControlToValidate="cbxTermos" runat="server" ValidationGroup="RegisterForm" ErrorMessage="É necessário aceitar os Termos de Uso." EnableClientScript="false" Display="None"></asp:RequiredFieldValidator>--%>
  <div class="main-content container-fluid">
    <div class="splash-container sign-up" style="max-width: 800px">
      <div class="card card-border-color card-border-color-primary">
        <div class="card-header">
          <img src="/assets/img/logo@2x.png" alt="logo" width="102" height="27" class="logo-img"><span class="splash-description">Digite suas informações.</span>
        </div>
        <asp:UpdatePanel runat="server">
          <ContentTemplate>
            <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCadastrar" />
          </Triggers>
        </asp:UpdatePanel>
        <div class="card-body">
          <div class="row wizard-row">
            <div class="col-md-12 fuelux">
              <div class="block-wizard">
                <div id="wizard1" class="wizard wizard-ux">
                  <div class="steps-container">
                    <ul class="steps" style="margin-left: 0">
                      <li data-step="1" class="active">Primeiro passo<span class="chevron"></span></li>
                      <li data-step="2" class="">Segundo passo<span class="chevron"></span></li>
                    </ul>
                  </div>
                  <div class="step-content">
                    <div data-step="1" class="step-pane active">
                      <div class="container p-0">
                        <div class="form-group row">
                          <div class="col-sm-7">
                            <h3 class="wizard-title">Informações de usuário</h3>
                          </div>
                        </div>
                        <div class="form-group row">
                          <label class="col-12 col-sm-3 col-form-label text-left text-sm-right"></label>
                          <div class="col-6 col-sm-4 col-lg-3">
                            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                          </div>
                          <div class="col-6 col-sm-4 col-lg-3">
                            <asp:TextBox runat="server" ID="txtSobrenome" CssClass="form-control" placeholder="Sobrenome"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group row">
                          <label class="col-12 col-sm-3 col-form-label text-left text-sm-right"></label>
                          <div class="col-12 col-sm-8 col-lg-6">
                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Username"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group row">
                          <label class="col-12 col-sm-3 col-form-label text-left text-sm-right"></label>
                          <div class="col-12 col-sm-8 col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="E-mail"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group row">
                          <label class="col-12 col-sm-3 col-form-label text-left text-sm-right"></label>
                          <div class="col-6 col-sm-4 col-lg-3">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Senha"></asp:TextBox>
                          </div>
                          <div class="col-6 col-sm-4 col-lg-3">
                            <asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirmar senha"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group row">
                          <label class="col-12 col-sm-3 col-form-label text-left text-sm-right"></label>
                          <div class="col-12 col-sm-8 col-lg-6">
                            <uc:DatePicker ID="dtDatePicker" runat="server"></uc:DatePicker>
                          </div>
                        </div>
                        <div class="form-group row">
                          <div class="col-sm-12" style="text-align: center">
                            <button data-wizard="#wizard1" class="btn btn-primary btn-space wizard-next">Próximo passo</button>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div data-step="2" class="step-pane">
                      <div class="form-group row">
                        <div class="col-sm-7">
                          <h3 class="wizard-title">Informações da Empresa</h3>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-6 col-sm-4 col-lg-5">
                          <asp:TextBox runat="server" ID="txtNomeEmpresa" CssClass="form-control" placeholder="Nome Empresa"></asp:TextBox>
                        </div>
                        <div class="col-6 col-sm-4 col-lg-4">
                          <asp:TextBox runat="server" ID="txtCNPJ" data-mask="cnpj" CssClass="form-control" placeholder="CNPJ"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-12 col-sm-8 col-lg-9">
                          <asp:TextBox runat="server" ID="txtSite" TextMode="Url" CssClass="form-control" placeholder="Site"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-12 col-sm-8 col-lg-9">
                          <asp:TextBox runat="server" ID="txtDestinatario" CssClass="form-control" placeholder="Endereço"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-12 col-sm-8 col-lg-9">
                          <asp:TextBox runat="server" ID="txtComplemento" CssClass="form-control" placeholder="Complemento"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-6 col-sm-4 col-lg-5">
                          <asp:TextBox runat="server" ID="txtBairro" CssClass="form-control" placeholder="Bairro" MaxLength="30"></asp:TextBox>
                        </div>
                        <div class="col-6 col-sm-4 col-lg-4">
                          <asp:TextBox runat="server" ID="txtCidade" CssClass="form-control" placeholder="Cidade" MaxLength="50"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <div class="col-6 col-sm-4 col-lg-6">
                          <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control" placeholder="Estado" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="col-6 col-sm-4 col-lg-3">
                          <asp:TextBox runat="server" ID="txtPais" CssClass="form-control" placeholder="País" MaxLength="2"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group row">
                        <label class="col-12 col-sm-2 col-form-label text-left text-sm-right"></label>
                        <asp:CheckBox Checked="true" ID="teste" runat="server" CssClass="custom-control-input" />
                        <div class="col-12 col-sm-8 col-lg-9">
                          <label class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input"><span class="custom-control-label">Ao criar uma conta, você concorda com nossos <a href="#">termos e condições</a>.</span>
                          </label>
                        </div>
                      </div>
                      <div class="form-group row">
                        <div class="col-sm-12" style="text-align: center">
                          <button data-wizard="#wizard1" class="btn btn-secondary btn-space wizard-previous">Anterior</button>
                          <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-primary btn-space" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="splash-footer">© 2018 BugFeed</div>
    </div>
  </div>

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviarRelatorio.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.EnviarRelatorio" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" Title="Enviar Relatório" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="page-head">
    <h3 class="page-head-title" id="h3Titulo" runat="server"></h3>
  </div>
  <div class="main-content container-fluid">
    <asp:UpdatePanel runat="server">
      <ContentTemplate>
        <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btSalvar" />
        <asp:AsyncPostBackTrigger ControlID="btCancelar" />
      </Triggers>
    </asp:UpdatePanel>
    <div class="row">
      <div class="col-md-12">
        <div class="card card-border-color card-border-color-primary">
          <%--<div class="card-header card-header-divider">Basic Elements<span class="card-subtitle">These are the basic bootstrap form elements</span></div>--%>
          <div class="card-body">
            <div class="form-group pt-2">
              <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" placeholder="Título do Relatório"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:TextBox runat="server" ID="txtImpacto" CssClass="form-control" placeholder="Impacto da Falha"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:TextBox ValidateRequestMode="Disabled" runat="server" ID="txtDescricao" TextMode="MultiLine" CssClass="summernote"></asp:TextBox>
            </div>
            <div class="row pt-3">
              <div class="col-sm-12 text-right">
                <asp:Button runat="server" CssClass="btn btn-space btn-secondary" Text="Cancelar" ID="btCancelar" OnClick="btCancelar_Click" />
                <asp:Button runat="server" CssClass="btn btn-space btn-primary" Text="Enviar" ID="btSalvar" OnClick="btSalvar_Click" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</asp:Content>

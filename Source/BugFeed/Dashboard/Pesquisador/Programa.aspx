<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programa.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.Programa" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" Title="Detalhes do Programa" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="page-head">
        <h3 class="page-head-title" id="h3Titulo" runat="server"></h3>
      </div>
      <div class="main-content container-fluid">
        <div class="row">
          <div class="col-12 text-right">
            <asp:LinkButton CssClass="btn btn-space btn-primary" runat="server" ID="btEnviar" Text="Enviar Relatório" OnClick="btEnviar_Click" />
          </div>
        </div>
        <div class="row mt-3"></div>
        <div class="row">
          <div class="col-12">
            <div class="card card-border-color card-border-color-primary">
              <div class="card-body html-content" id="divContent" runat="server">
              </div>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

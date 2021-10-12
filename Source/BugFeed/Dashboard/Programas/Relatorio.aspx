<%@ Page Title="Relatório" Language="C#" MasterPageFile="~/MasterPages/Dashboard/FuncionarioMasterPage.master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="BugFeed.Dashboard.Programas.Relatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
        <div class="row">
          <div class="col-12">
            <div class="user-info-list card">
              <div class="card-header card-header-divider">
                <div class="tools" id="divPagamento" runat="server" visible="false">
                  <div class="btn-group btn-hspace">
                    <asp:TextBox runat="server" ID="txtPagamento" CssClass="form-control form-control-sm currency" placeholder="Valor" data-affixes-stay="true" data-prefix="R$ " data-thousands="." data-decimal="," data-allow-empty="false"></asp:TextBox>
                    <asp:Button runat="server" ID="btPagamento" CssClass="btn btn-primary" Text="Pagar Recompensa" OnClick="btPagamento_Click" />
                  </div>
                </div>
                <asp:Label runat="server" ID="Label1" Text="Título: "></asp:Label>
                <asp:Label runat="server" ID="lblTitulo"></asp:Label>
                <span class="card-subtitle">
                  <asp:Label runat="server" ID="Label2" Text="Data: "></asp:Label>
                  <asp:Label runat="server" ID="lblData"></asp:Label>
                </span>
              </div>
              <div class="card-body">
                <table class="no-border no-strip skills">
                  <tbody class="no-border-x no-border-y">
                    <tr>
                      <td class="item" style="width: 6%">Pesquisador: <span class="icon s7-portfolio"></span></td>
                      <td>
                        <asp:Label runat="server" ID="lblPesquisador"></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="item">Status: <span class="icon s7-gift"></span></td>
                      <td>
                        <asp:Label runat="server" ID="lblStatus" CssClass="col-form-label"></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="item">Impacto: <span class="icon s7-phone"></span></td>
                      <td>
                        <asp:Label runat="server" ID="lblImpacto" CssClass="col-form-label"></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="item" style="vertical-align: top">Descrição: <span class="icon s7-map-marker"></span></td>
                      <td>
                        <div class="card card-border-color card-border-color-primary">
                          <div class="card-body html-content" id="divContent" runat="server">
                          </div>
                        </div>
                    </tr>
                  </tbody>
                </table>
                <div class="row"></div>
                <div class="row"></div>
                <asp:Repeater runat="server" ID="rptComentarios" OnItemDataBound="rptComentarios_ItemDataBound">
                  <HeaderTemplate>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <div class="card card-contrast">
                      <div class="card-header card-header-contrast">
                        <asp:Label runat="server" ID="lblUsuarioComentario"></asp:Label>
                        <span class="card-subtitle">
                          <asp:Label runat="server" ID="lblDataComentario"></asp:Label>
                        </span>
                      </div>
                      <div class="card-body">
                        <asp:Label runat="server" ID="lblComentario"></asp:Label>
                      </div>
                    </div>
                  </ItemTemplate>
                  <FooterTemplate>
                  </FooterTemplate>
                </asp:Repeater>
                <div class="form-group">
                  <asp:TextBox ValidateRequestMode="Disabled" runat="server" ID="txtComentario" TextMode="MultiLine" CssClass="summernote"></asp:TextBox>
                </div>
                <div class="row pt-3">
                  <div class="col-sm-12 text-right">
                    <asp:Button runat="server" CssClass="btn btn-space btn-primary" Text="Salvar" ID="btSalvar" OnClick="btSalvar_Click" />
                  </div>
                </div>
                <div class="row" id="divAceitar" runat="server">
                  <div class="col-sm-12 text-right">
                    <asp:Button runat="server" CssClass="btn btn-space btn-danger" Text="Recusar" ID="btRecusar" OnClick="btRecusar_Click" />
                    <asp:Button runat="server" CssClass="btn btn-space btn-success" Text="Aceitar" ID="btAceitar" OnClick="btAceitar_Click" />
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

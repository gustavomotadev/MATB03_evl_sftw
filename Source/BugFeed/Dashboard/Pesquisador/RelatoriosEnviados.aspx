<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelatoriosEnviados.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.RelatoriosEnviados" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" Title="Relatórios Enviados"%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <div class="row">
          <div class="col-12">
            <asp:Repeater runat="server" ID="rptRelatorios" OnItemDataBound="rptRelatorios_ItemDataBound">
            <HeaderTemplate>
              <div class="card card-table">
                <div class="card-body table-responsive">
                  <table class="table table-striped table-borderless">
                    <thead>
                      <tr>
                        <th>Título</th>
                        <th>Empresa</th>
                        <th>Programa</th>
                        <th class="text-center">Data</th>
                        <th>Estado</th>
<%--                        <th style="width: 5%;" class="actions"></th>--%>
                      </tr>
                    </thead>
                    <tbody class="no-border-x">
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td><%# Eval("Titulo") %></td>
                <td><%# Eval("Programa.Empresa.Nome") %></td>
                <td><%# Eval("Programa.Titulo") %></td>
                <td class="text-center" id="tdData" runat="server"></td>
                <td id="tdEstado" runat="server"></td>
<%--                <td class="actions"><a href="#" class="icon"><i class="mdi mdi-plus-circle-o"></i></a></td>--%>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
              </tbody>
              </table>
            </div>
              </div>
            </FooterTemplate>
          </asp:Repeater>
          </div>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
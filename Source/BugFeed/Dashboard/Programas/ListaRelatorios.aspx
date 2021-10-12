<%@ Page Title="Lista de Relatórios" Language="C#" MasterPageFile="~/MasterPages/Dashboard/FuncionarioMasterPage.master" AutoEventWireup="true" CodeBehind="ListaRelatorios.aspx.cs" Inherits="BugFeed.Dashboard.Programas.ListaRelatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="main-content container-fluid">
    <div class="col-sm-12">
      <div class="card card-table">
        <div class="card-body">
          <asp:Repeater runat="server" ID="rptProgramas" OnItemDataBound="rptProgramas_ItemDataBound">
            <HeaderTemplate>
              <div class="table-responsive noSwipe">
                <table class="table table-striped table-hover">
                  <thead>
                    <tr>
                      <th style="width: 23%;">Título</th>
                      <th style="width: 5%;">Estado</th>
                      <th style="width: 64%;">Impacto</th>
                      <th style="width: 1%;">Enviado em</th>
                      <th style="width: 7%;"></th>
                    </tr>
                  </thead>
                  <tbody>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td><%# Eval("Titulo") %></td>
                <td id="tdEstado" runat="server"></td>
                <td><%# Eval("Impacto") %></td>
                <td runat="server" id="tdData"></td>
                <td class="text-right">
                  <div class="btn-group btn-hspace">
                    <asp:LinkButton runat="server" ID="lbAnalisar" CssClass="btn btn-secondary" Text="Analisar"></asp:LinkButton>
                  </div>
                </td>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
              </tbody>
                  </table>
              </div>
            </FooterTemplate>
          </asp:Repeater>
        </div>
      </div>
    </div>
  </div>
</asp:Content>

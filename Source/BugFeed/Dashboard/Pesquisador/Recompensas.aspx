<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recompensas.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.Recompensas" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" Title="Minhas Recompensas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
        <div class="row text-right">
          <div class="col-12">
            <asp:Button CssClass="btn btn-space btn-primary" runat="server" ID="btRetirar" OnClick="btRetirar_Click" Text="Retirar" />
          </div>
        </div>
        <div class="row mt-3"></div>
        <div class="row">
          <!--Responsive table-->
          <div class="col-sm-12">
            <div class="card card-table">
              <div class="card-body">
                <asp:Repeater runat="server" ID="rptRecompensas" OnItemDataBound="rptRecompensas_ItemDataBound">
                  <HeaderTemplate>
                    <div class="table-responsive noSwipe">
                      <table class="table table-striped table-hover">
                        <thead>
                          <tr>
                            <th style="width: 5%;"></th>
                            <th style="width: 25%;">Título</th>
                            <th style="width: 15%;">Empresa</th>
                            <th style="width: 15%;">Programa</th>
                            <th style="width: 10%;" class="text-center">Valor</th>
                            <th style="width: 10%;">Estado</th>
                          </tr>
                        </thead>
                        <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <tr>
                      <td>
                        <label class="custom-control custom-control-sm custom-checkbox">
                          <input type="checkbox" id="cbRetirar" runat="server" class="custom-control-input"><span class="custom-control-label"></span>
                        </label>
                      </td>
                      <td><%# Eval("Titulo") %></td>
                      <td><%# Eval("Programa.Empresa.Nome") %></td>
                      <td><%# Eval("Programa.Titulo") %></td>
                      <td class="text-center" id="tdValor" runat="server"></td>
                      <td id="tdEstado" runat="server"></td>
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
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

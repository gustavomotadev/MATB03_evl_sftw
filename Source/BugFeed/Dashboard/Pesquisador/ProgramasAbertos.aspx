<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramasAbertos.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.ProgramasAbertos" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" Title="Programas Abertos"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <div class="row mt-3"></div>
        <div class="row">
          <!--Responsive table-->
          <div class="col-sm-12">
            <div class="card card-table">
              <div class="card-body">
                <asp:Repeater runat="server" ID="rptProgramas" OnItemDataBound="rptProgramas_ItemDataBound">
                  <HeaderTemplate>
                    <div class="table-responsive noSwipe">
                      <table class="table table-striped table-hover">
                        <thead>
                          <tr>
                            <th>Empresa</th>
                            <th>Título</th>
                            <th class="text-center">Relatórios Enviados</th>
                            <th>Criado em</th>
                            <th></th>
                          </tr>
                        </thead>
                        <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <tr>
                      <td><%# Eval("Empresa.Nome") %></td>
                      <td><%# Eval("Titulo") %></td>
                      <td runat="server" id="tdQntRelatorios" class="text-center"></td>
                      <td runat="server" id="tdData"></td>
                      <td>
                        <asp:Button ID="btVerRelatorio" runat="server" CssClass="btn btn-secondary btn-space" Text="Ver" UseSubmitBehavior="false" CommandName="Ver"></asp:Button>
                        <asp:Button ID="btEnviarRelatorio" runat="server" CssClass="btn btn-primary btn-space" Text="Enviar Relatório" UseSubmitBehavior="false" CommandName="Editar"></asp:Button>
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
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
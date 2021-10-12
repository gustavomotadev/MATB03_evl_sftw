<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BugFeed.Dashboard.Programas.Default" MasterPageFile="~/MasterPages/Dashboard/FuncionarioMasterPage.master" Title="Programas de Recompensa" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <div class="row">
          <div class="col-12">
            <asp:Button CssClass="btn btn-space btn-primary" runat="server" ID="btNovo" OnClick="btNovo_Click" Text="Novo Programa" />
          </div>
        </div>
        <div class="row mt-3"></div>
        <div class="row">
          <!--Responsive table-->
          <div class="col-sm-12">
            <div class="card card-table">
              <%--              <div class="card-header">
                <div class="tools dropdown">
                  <span class="icon mdi mdi-download"></span><a href="#" role="button" data-toggle="dropdown" class="dropdown-toggle"><span class="icon mdi mdi-more-vert"></span></a>
                  <div role="menu" class="dropdown-menu">
                    <a href="#" class="dropdown-item">Action</a><a href="#" class="dropdown-item">Another action</a><a href="#" class="dropdown-item">Something else here</a>
                    <div class="dropdown-divider"></div>
                    <a href="#" class="dropdown-item">Separated link</a>
                  </div>
                </div>
              </div>--%>
              <div class="card-body">
                <asp:Repeater runat="server" ID="rptProgramas" OnItemDataBound="rptProgramas_ItemDataBound">
                  <HeaderTemplate>
                    <div class="table-responsive noSwipe">
                      <table class="table table-striped table-hover">
                        <thead>
                          <tr>
                            <th style="width: 25%;">Título</th>
                            <th style="width: 17%;">Estado</th>
                            <th style="width: 10%;">Relatórios</th>
                            <th style="width: 20%;">Orçamento</th>
                            <th style="width: 10%;">Criado em</th>
                            <th style="width: 10%;"></th>
                          </tr>
                        </thead>
                        <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <tr>
                      <td><%# Eval("Titulo") %></td>
                      <td runat="server" id="tdEstado"><%# Eval("Estado") %></td>
                      <td runat="server" id="tdQntRelatorios"></td>
                      <td class="milestone">
                        <span class="completed" runat="server" id="spnOrcamento"></span>
                        <span class="version">&nbsp;</span>
                        <div class="progress">
                          <div id="divOrcamentoProgress" runat="server" class="progress-bar progress-bar-primary"></div>
                        </div>
                      </td>
                      <td runat="server" id="tdData"></td>
                      <td class="text-right">
                        <asp:LinkButton runat="server" ID="lbEditar" CssClass="btn btn-secondary" Text="Editar"></asp:LinkButton>
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

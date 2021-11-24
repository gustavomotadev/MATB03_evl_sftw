<%@ Page Language="C#" Title="Dashboard" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BugFeed.Dashboard.Pesquisador.Default" MasterPageFile="~/MasterPages/Dashboard/PesquisadorMasterPage.master" %>

<%@ Import Namespace="BugFeed.Objects.Extensions" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <div class="main-content container-fluid">
    <div class="user-profile">
      <div class="row">
        <div class="col-lg-5">
          <div class="user-display">
            <div class="user-display-bg">
              <img src="/assets/img/user-profile-display.png" alt="Profile Background">
            </div>
            <div class="user-display-bottom">
              <div class="user-display-avatar">
                <img src="<%: this.GetGravatarUrl(110) %>" alt="Avatar">
              </div>
              <div class="user-display-info">
                <div class="name"><%: Session["NomeSobrenome"] %></div>
                <div class="nick"><span class="mdi mdi-account"></span><%: Session["Usuario"] %></div>
              </div>
              <div class="row user-display-details text-center">
                <div class="col-6">
                  <div class="title">Relatórios</div>
                  <div class="counter" id="divRelatorios" runat="server"></div>
                </div>
                <div class="col-6">
                  <div class="title">Recompensas</div>
                  <div class="counter" id="divRecompensas" runat="server"></div>
                </div>
               
              </div>
            </div>
          </div>
          </div>
        <div class="col-lg-7">
          <asp:Repeater runat="server" ID="rptRelatorios" OnItemDataBound="rptRelatorios_ItemDataBound">
            <HeaderTemplate>
              <div class="card card-table">
                <div class="card-header">
                  <div class="title">Últimos relatórios</div>
                </div>
                <div class="card-body table-responsive">
                  <table class="table table-striped table-borderless" aria-label="Relatorios">
                    <thead>
                      <tr>
                        <th>Título</th>
                        <th>Empresa</th>
                        <th>Programa</th>
                        <th class="text-center">Data</th>
                        <th>Estado</th>
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
  </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Novo.aspx.cs" Inherits="BugFeed.Dashboard.Programas.Novo" MasterPageFile="~/MasterPages/Dashboard/FuncionarioMasterPage.master" Title="Novo Programa" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <div class="main-content container-fluid">
        <div class="row">
          <div class="col-12">
            <asp:Panel ID="pnAlerts" runat="server"></asp:Panel>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div class="card card-border-color card-border-color-primary">
              <%--<div class="card-header card-header-divider">Basic Elements<span class="card-subtitle">These are the basic bootstrap form elements</span></div>--%>
              <div class="card-body">
                <div class="form-group pt-2">
                  <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" placeholder="Título do Programa"></asp:TextBox>
                </div>
                <div class="form-group" style="width: 30%;">
                  <asp:TextBox runat="server" ID="txtOrcamento" CssClass="form-control currency" placeholder="Orçamento" data-affixes-stay="true" data-prefix="R$ " data-thousands="." data-decimal="," data-allow-empty="false"></asp:TextBox>
                </div>
                <%--            <div class="form-group row pt-1 pb-1">
              <div class="col-12 col-sm-8 col-lg-6 form-check mt-2">
                <label class="custom-control custom-radio custom-control-inline text-success">
                  <input type="radio" runat="server" name="rbEstado" checked="" value="0" class="custom-control-input"><span class="custom-control-label">Ativo</span>
                </label>
                <label class="custom-control custom-radio custom-control-inline text-warning">
                  <input type="radio" runat="server" name="rbEstado" value="1" class="custom-control-input"><span class="custom-control-label">Pausado</span>
                </label>
                <label class="custom-control custom-radio custom-control-inline text-danger">
                  <input type="radio" runat="server" name="rbEstado" value="2" class="custom-control-input"><span class="custom-control-label">Finalizado</span>
                </label>
              </div>
            </div>--%>
                <div class="form-group">
                  <asp:TextBox ValidateRequestMode="Disabled" runat="server" ID="txtDescricao" TextMode="MultiLine" CssClass="summernote"></asp:TextBox>
                </div>
                <div class="row pt-3">
                  <div class="col-sm-12 text-right">
                    <asp:Button runat="server" CssClass="btn btn-space btn-secondary" Text="Cancelar" ID="btCancelar" OnClick="btCancelar_Click" />
                    <asp:Button runat="server" CssClass="btn btn-space btn-primary" Text="Salvar" ID="btSalvar" OnClick="btSalvar_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="btSalvar" />
      <asp:AsyncPostBackTrigger ControlID="btCancelar" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>

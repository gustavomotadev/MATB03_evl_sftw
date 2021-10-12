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
                <%--<div class="col-4">
                  <div class="title">Reputação</div>
                  <div class="counter">456</div>
                </div>--%>
              </div>
            </div>
          </div>
          <%--<div class="user-info-list card">
            <div class="card-header card-header-divider">
              Sobre Mim
              <span class="card-subtitle">Eu gosto de ler livros, ouvir músicas e praticar esportes. Acho bugs nas horas vagas.</span>
            </div>
            <div class="card-body">
              <table class="no-border no-strip skills">
                <tbody class="no-border-x no-border-y">
                  <tr>
                    <td class="icon"><span class="mdi mdi-case"></span></td>
                    <td class="item">Ocupação<span class="icon s7-portfolio"></span></td>
                    <td>Estudante</td>
                  </tr>
                  <tr>
                    <td class="icon"><span class="mdi mdi-cake"></span></td>
                    <td class="item">Aniversário<span class="icon s7-gift"></span></td>
                    <td>01 de Novembro, 1996</td>
                  </tr>
                  <tr>
                    <td class="icon"><span class="mdi mdi-globe-alt"></span></td>
                    <td class="item">Localização<span class="icon s7-map-marker"></span></td>
                    <td>Montreal, Canadá</td>
                  </tr>
                  <tr>
                    <td class="icon"><span class="mdi mdi-pin"></span></td>
                    <td class="item">Website<span class="icon s7-global"></span></td>
                    <td>www.website.com</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>--%>
        </div>
        <div class="col-lg-7">
          <asp:Repeater runat="server" ID="rptRelatorios" OnItemDataBound="rptRelatorios_ItemDataBound">
            <HeaderTemplate>
              <div class="card card-table">
                <div class="card-header">
                  <%--<div class="tools dropdown"> <span class="icon mdi mdi-download"></span><a href="#" role="button" data-toggle="dropdown" class="dropdown-toggle" aria-expanded="false"><span class="icon mdi mdi-more-vert"></span></a>
                    <div role="menu" class="dropdown-menu" x-placement="bottom-start" style="position: absolute; transform: translate3d(19px, 25px, 0px); top: 0px; left: 0px; will-change: transform;"><a href="#" class="dropdown-item">Action</a><a href="#" class="dropdown-item">Another action</a><a href="#" class="dropdown-item">Something else here</a>
                      <div class="dropdown-divider"></div><a href="#" class="dropdown-item">Separated link</a>
                    </div>
                  </div>--%>
                  <div class="title">Últimos relatórios</div>
                </div>
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
    <%--      <div class="row">
        <div class="col-lg-6">
          <div class="widget widget-calendar">
            <div id="calendar-widget" class="hasDatepicker">
              <div class="ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all" style="display: block;">
                <div class="ui-datepicker-header ui-widget-header ui-helper-clearfix ui-corner-all">
                  <a class="ui-datepicker-prev ui-corner-all" data-handler="prev" data-event="click" title="Prev"><span class="ui-icon ui-icon-circle-triangle-w">Prev</span></a><a class="ui-datepicker-next ui-corner-all" data-handler="next" data-event="click" title="Next"><span class="ui-icon ui-icon-circle-triangle-e">Next</span></a><div class="ui-datepicker-title"><span class="ui-datepicker-month">Maio</span>&nbsp;<span class="ui-datepicker-year">2018</span></div>
                </div>
                <table class="ui-datepicker-calendar">
                  <thead>
                    <tr>
                      <th scope="col" class="ui-datepicker-week-end"><span title="Sunday">Dom</span></th>
                      <th scope="col"><span title="Monday">Seg</span></th>
                      <th scope="col"><span title="Tuesday">Ter</span></th>
                      <th scope="col"><span title="Wednesday">Qua</span></th>
                      <th scope="col"><span title="Thursday">Qui</span></th>
                      <th scope="col"><span title="Friday">Sex</span></th>
                      <th scope="col" class="ui-datepicker-week-end"><span title="Saturday">Sáb</span></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td class=" ui-datepicker-week-end ui-datepicker-other-month " data-handler="selectDay" data-event="click" data-month="3" data-year="2018"><a class="ui-state-default ui-priority-secondary" href="#">29</a></td>
                      <td class=" ui-datepicker-other-month " data-handler="selectDay" data-event="click" data-month="3" data-year="2018"><a class="ui-state-default ui-priority-secondary" href="#">30</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">1</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">2</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">3</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">4</a></td>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">5</a></td>
                    </tr>
                    <tr>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">6</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">7</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">8</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">9</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">10</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">11</a></td>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">12</a></td>
                    </tr>
                    <tr>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">13</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">14</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">15</a></td>
                      <td class=" has-events" title="This day has events!" data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">16</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">17</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">18</a></td>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">19</a></td>
                    </tr>
                    <tr>
                      <td class=" ui-datepicker-week-end has-events" title="This day has events!" data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">20</a></td>
                      <td class=" ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today" data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default ui-state-highlight ui-state-active" href="#">21</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">22</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">23</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">24</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">25</a></td>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">26</a></td>
                    </tr>
                    <tr>
                      <td class=" ui-datepicker-week-end " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">27</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">28</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">29</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">30</a></td>
                      <td class=" " data-handler="selectDay" data-event="click" data-month="4" data-year="2018"><a class="ui-state-default" href="#">31</a></td>
                      <td class=" ui-datepicker-other-month " data-handler="selectDay" data-event="click" data-month="5" data-year="2018"><a class="ui-state-default ui-priority-secondary" href="#">1</a></td>
                      <td class=" ui-datepicker-week-end ui-datepicker-other-month " data-handler="selectDay" data-event="click" data-month="5" data-year="2018"><a class="ui-state-default ui-priority-secondary" href="#">2</a></td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-6">
          <div class="card">
            <div class="card-header card-header-divider">Últimas Atividades<%--<span class="card-subtitle">This is a custom timeline widget</span></div>
            <div class="card-body">
              <ul class="user-timeline">
                <li class="latest">
                  <div class="user-timeline-date">Agora</div>
                  <div class="user-timeline-title">Starbucks: Aplicativo iOS</div>
                  <div class="user-timeline-description">De acordo com seu relatório, verificamos que o aplicativo está, de fato, enviando requisições HTTP sem presença dos cabeçalhos de segurança mencionados. Porém, seria possivel...</div>
                </li>
                <li>
                  <div class="user-timeline-date">Hoje - 15:35</div>
                  <div class="user-timeline-title">Back Up Theme</div>
                  <div class="user-timeline-description">Quisque sed est felis. Vestibulum lectus nulla, maximus in eros non, tristique consectetur lorem. Nulla molestie sem quis imperdiet facilisis</div>
                </li>
                <li>
                  <div class="user-timeline-date">Yesterday - 10:41</div>
                  <div class="user-timeline-title">Changes In The Structure</div>
                  <div class="user-timeline-description">Quisque sed est felis. Vestibulum lectus nulla, maximus in eros non, tristique consectetur lorem. Nulla molestie sem quis imperdiet facilisis</div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>--%>
  </div>
  </div>
</asp:Content>

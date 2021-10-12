<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Alert.ascx.cs" Inherits="BugFeed.Controls.Elements.Alert" %>
<div role="alert" class="<%= this.AlertClasses %>">
  <div class="icon"><span class="<%= this.IconClass %>"></span></div>
  <div class="message">
    <button runat="server" visible="<%# this.Dismissible %>" type="button" data-dismiss="alert" aria-label="Fechar" class="close">
      <span aria-hidden="true" class="mdi mdi-close"></span>
    </button>
    <b><%= this.AlertTitle %></b>
    <%= this.Message %>
  </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="BugFeed.Controls.Elements.DatePicker" %>
<div class="form-group">
  <div data-min-view="2" data-date-format="dd-mm-yyyy" class="input-group date datetimepicker">
    <asp:TextBox runat="server" ID="txtDateTime" CssClass="form-control" placeholder="Data de Nascimento"></asp:TextBox>
    <div class="input-group-append">
      <button class="btn btn-primary"><i class="icon-th mdi mdi-calendar"></i></button>
    </div>
  </div>
</div>

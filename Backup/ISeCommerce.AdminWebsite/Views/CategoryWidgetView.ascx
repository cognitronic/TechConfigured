<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryWidgetView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.CategoryWidgetView" %>
<!-- Categories -->
<div class="category">
    <div class="small_heading">
        <h5 class="colr">
            <idea:Label
            runat="server"
            ID="lblViewTitle">
            </idea:Label>
        </h5>
    </div>
    <div runat="server" id="divLinks" class="arrowlistmenu">
    </div>
</div>
<div runat="server" id="divMessage"/>
        	    
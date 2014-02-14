<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="TwoColumn.aspx.cs" Inherits="ISeCommerce.AdminWebsite.TwoColumn" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="content_sec">
    	<div class="cont_top">&nbsp;</div>
        <div class="cont_center cont_center_sh">
    	    <!-- Column1 Section -->
    	    <div runat="server" id="divColumnOne" class="col1">
            </div>
            <div runat="server" id="divColumnTwo" class="col2">
            </div>
            <div class="clear"></div>
            <div class="clear"></div>
        </div>
        <div class="cont_botm">&nbsp;</div>
    </div>
    <div class="clear"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpFooter" runat="server">
</asp:Content>

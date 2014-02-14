<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FullWidth.aspx.cs" Inherits="ISeCommerce.AdminWebsite.FullWidth" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="content_sec">
    	<div class="cont_top">&nbsp;</div>
        <div class="cont_center">
    	    <div runat="server" id="divFullColumn">
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

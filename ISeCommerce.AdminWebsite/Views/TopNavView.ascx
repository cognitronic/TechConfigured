<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.TopNavView" %>
<div runat="server" id="divTopNav" class="secnd_navi">
    <ul class="links">
        <li>
            <idea:Label
            runat="server"
            ID="lblCurrentUser">
            </idea:Label>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbUsers"
            OnClick="UsersClicked">
                Users
            </idea:LinkButton>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbManagedLists"
            OnClick="ManagedListsClicked">
                Managed Lists
            </idea:LinkButton>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbSettings"
            OnClick="SettingsClicked">
               Settings
            </idea:LinkButton>
        </li>
        <li class="last">
            <idea:LinkButton
            runat="server"
            CausesValidation="false"
            OnClick="LogoutClicked"
            ID="lbLogout">
                Logout
            </idea:LinkButton>
        </li>
    </ul>
    <%--<ul class="network">
        <li>Share with us:</li>
        <li><a href="#"><img src="/images/blogger.gif" alt="" /></a></li>
        <li><a href="#"><img src="/images/facebook.gif" alt="" /></a></li>
        <li><a href="#"><img src="/images/twitter.gif" alt="" /></a></li>
        <li><a href="#"><img src="/images/wire.gif" alt="" /></a></li>
    </ul>--%>
</div>
<div class="clear"></div>
<div class="logo">
    <idea:LinkButton
    runat="server"
    ID="lbLogoClicked"
    OnClick="LogoClicked">
        <img src="/images/logo.png" alt="" />
    </idea:LinkButton>
</div>
<%--<ul class="search">
    <li>
        <input 
        type="text" 
        value="Search" 
        id="searchBox" 
        name="s" 
        onblur="if(this.value == '') { this.value = 'Search'; }" 
        onfocus="if(this.value == 'Search') { this.value = ''; }" 
        class="bar" /></li>
    <li>
        <idea:LinkButton
        runat="server"
        ID="lbSearch"
        OnClick="SearchClicked"
        CssClass="simplebtn">
            Search
        </idea:LinkButton>
    </li>
</ul>--%>
<div class="clear"></div>
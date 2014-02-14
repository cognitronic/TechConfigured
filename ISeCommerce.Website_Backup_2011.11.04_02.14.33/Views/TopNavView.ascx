<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavView.ascx.cs" Inherits="ISeCommerce.Website.Views.TopNavView" %>
<div class="secnd_navi">
    <%--<ul class="links">
        <li>
            <idea:Label
            runat="server"
            ID="lblCurrentUser">
            </idea:Label>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbMyAccount"
            OnClick="MyAccountClicked">
                My Account
            </idea:LinkButton>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbMyWishlist"
            OnClick="MyWishlistClicked">
                My Wishlist
            </idea:LinkButton>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbMyCart"
            OnClick="MyCartClicked">
                My Cart
            </idea:LinkButton>
        </li>
        <li>
            <idea:LinkButton
            runat="server"
            ID="lbCheckout"
            OnClick="CheckoutClicked">
                Checkout
            </idea:LinkButton>
        </li>
        <li class="last">
            <idea:LinkButton
            runat="server"
            OnClick="LoginClicked"
            ID="lbLogin">
                Login
            </idea:LinkButton>
            <idea:LinkButton
            runat="server"
            OnClick="LogoutClicked"
            ID="lbLogout">
                Logout
            </idea:LinkButton>
        </li>
    </ul>--%>
    <ul class="network">
        <li>Share with us:</li>
        <li><a href="#"><img src="/images/facebook.gif" alt="" /></a></li>
        <li><a href="#"><img src="/images/twitter.gif" alt="" /></a></li>
    </ul>
</div>
<div class="clear"></div>
<div class="logo">
    <idea:LinkButton
    runat="server"
    ID="lbLogoClicked"
    CausesValidation="false"
    OnClick="LogoClicked">
        <img src="/images/logo.png" alt="" />
    </idea:LinkButton>
</div><%--
<ul class="search">
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
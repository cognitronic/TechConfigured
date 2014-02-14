<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterView.ascx.cs" Inherits="ISeCommerce.Website.Views.FooterView" %>

<telerik:RadAjaxManagerProxy ID="rampCartActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbNewsletterSignup">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div class="clear" />
<div class="emailsignup" runat="server" id="divContent">
    <h5>Email Signup</h5>
    <ul class="inp">
        <li><idea:TextBox runat="server" Width="215px" ID="tbEmail" name="newsletter" class="bar" /></li>
        <li>
            <idea:LinkButton
            id="lbNewsletterSignup"
            runat="server"
            OnClick="NewsletterSignupClicked"
            CssClass="simplebtn">
                Signup
            </idea:LinkButton>
        </li>
    </ul>
    <div class="clear"></div>
    <div>
        <idea:Label
        ForeColor="White"
        ID="lblNewsletterResponse"
        runat="server" />
    </div>
    <p class="signtxt">
        Sign up for the newsletter to receive all the latest info on product reviews and online discounts!
    </p>
    <h6>Accepted Payment Methods</h6>
    <ul class="cards">
        <li><img src="/images/visa.gif" alt="" /></li>
        <li><img src="/images/master.gif" alt="" /></li>
        <%--<li><img src="/images/paypal.gif" alt="" /></li>--%>
        <li><img src="/images/american.gif" alt="" /></li>
    </ul>
</div>
        
<div class="partners">
    <h5>Tools &amp; Resources</h5>
    <ul>
        <li><a href="/Return-Policy">Return Policy Information</a></li>
        <li><a href="/Privacy-Policy">Privacy Policy</a></li>
        <li><a href="/Security-Policy">Security Policy</a></li>
    </ul>
    <div class="clear"></div>
</div>
<div class="partners">
    <h5>Customer Services</h5>
    <ul>
        <li><a href="/About-Us">About Us</a></li>
        <li><a href="/Contact-Us">Contact Us</a></li>
        <li class="last"><a href="/Shipping-Policy">Shipping Policy</a></li>
    </ul>
    <div class="clear"></div>
</div>
<div class="clear"></div>
<div class="copyrights">
    <p><img src="/Images/smalllogo.png" border="0" alt="Shop TechConfigured.com!" /></p>
    <div class="footer_links">
        <ul>
            <p>© <idea:Label runat="server" ID="lblCurrentYear" /> TechConfigured.com All Rights Reserved</p>
        </ul>
    </div>
</div>
<div class="clear"></div>
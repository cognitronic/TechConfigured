<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterView.ascx.cs" Inherits="ISeCommerce.Website.Views.FooterView" %>
<div class="emailsignup">
    <h5>Email Signup</h5>
    <ul class="inp">
        <li><input name="newsletter" type="text" class="bar" /></li>
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
    <p class="signtxt">
        Sign up for the newsletter to receive all the latest info on product reviews and online discounts!
    </p>
    <h6>FLEXIBLE PAYMENT METHODS</h6>
    <ul class="cards">
        <li><a href="#"><img src="images/visa.gif" alt="" /></a></li>
        <li><a href="#"><img src="images/master.gif" alt="" /></a></li>
        <li><a href="#"><img src="images/paypal.gif" alt="" /></a></li>
        <li><a href="#"><img src="images/american.gif" alt="" /></a></li>
    </ul>
</div>
        
<div class="partners">
    <h5>Tools &amp; Resources</h5>
    <ul>
        <li><a href="#">RSS Feeds</a></li>
        <li><a href="#">Return Policy Information</a></li>
        <li><a href="#">Track Orders</a></li>
    </ul>
    <div class="clear"></div>
</div>
<div class="partners">
    <h5>Customer Services</h5>
    <ul>
        <li><a href="#">About Us</a></li>
        <li><a href="#">Contact Us</a></li>
        <li><a href="#">Office Hours</a></li>
    </ul>
    <div class="clear"></div>
</div>
<div class="clear"></div>
<div class="copyrights">
    <p>© 2010 eCommerce Co. All Rights Reserved</p>
    <div class="footer_links">
        <ul>
            <li><a href="#">Privacy</a></li>
            <li><a href="#">Terms</a></li>
            <li><a href="#">Shipping &amp; Returns</a></li>
            <li class="last"><a href="#">Product Warranty Info</a></li>
        </ul>
    </div>
</div>
<div class="clear"></div>
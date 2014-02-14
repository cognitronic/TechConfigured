<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.LoginView" %>
<h3 class="heading colr">Login</h3>
	<div class="login">
		<div class="registrd">
			<h5>Please Sign In</h5>
			<p></p>
			<ul class="forms">
				<li class="txt bold">
                    Username:
                </li>
				<li class="inputfield">
                    <idea:TextBox
                    runat="server"
                    ID="tbUsername"
                    CssClass="bar" />
                </li>
			</ul>
			<ul class="forms">
				<li class="txt bold">
                    Password:
                </li>
				<li class="inputfield">
                    <idea:TextBox
                    runat="server"
                    TextMode="Password"
                    ID="tbPassword"
                    CssClass="bar" />
                </li>
			</ul>
			<ul class="forms">
				<li class="txt">&nbsp;</li>
				<li>
                    <idea:LinkButton
                    runat="server"
                    ID="lbLogin"
                    OnClick="LoginClicked"
                    CssClass="simplebtn">
                        Login
                    </idea:LinkButton>
                    <idea:LinkButton
                    runat="server"
                    ID="lbForgotPassword"
                    OnClick="ForgotPasswordClicked"
                    CssClass="simplebtn">
                        Forgot Your Password?
                    </idea:LinkButton>
                </li>
			</ul>
		</div>
	</div>
<div class="clear"></div>
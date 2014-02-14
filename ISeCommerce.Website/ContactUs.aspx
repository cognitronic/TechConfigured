<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ISeCommerce.Website.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="rampActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSend">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <div style="min-height: 400px; margin-bottom: 60px;">
        <h3>Contact Us</h3>
        <hr /><br />
        
        <iframe width="964" height="350" src="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=318+McHenry+Avenue,+Modesto,+CA&amp;aq=0&amp;sll=37.648662,-120.993416&amp;sspn=0.002325,0.002299&amp;vpsrc=0&amp;ie=UTF8&amp;hq=&amp;hnear=318+McHenry+Ave,+Modesto,+Stanislaus,+California+95354&amp;t=h&amp;z=19&amp;iwloc=A&amp;output=embed">
		</iframe>
        <br />
        <br />
        <div style="float: left; margin-right: 135px;">
            <p>
                <b>Email: </b><a href="mailto:customerservice@techconfigured.com">CustomerService@techconfigured.com</a>
            </p>
            <p>
                <b>Toll-Free: </b>888-800-0493
            </p>
            <p>
                <b>Local: </b>209-312-9800
            </p>
        </div>
        <div style="float: left; margin-bottom: 60px;"  runat="server" id="divContent">
            <div class="simple-success" id="divSuccess" runat="server">
                Your message has been sent.  Thank you!
            </div>
            <div class="simple-error" id="divError" runat="server">
                Your message was not sent.  Please try again.  If you receive the same error, please call our toll-free number.
            </div><br />
            <div>
                <div>
                <b>Name:</b>
                </div>
                <idea:TextBox
                runat="server"
                ID="tbName"
                Width="600px" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvName"
                CssClass="error"
                Display="Dynamic"
                ControlToValidate="tbName"
                ErrorMessage="<br />Please enter your name" />
            </div>
            <div >
                <div>
                    <b>Email:</b>
                </div>
                <idea:TextBox
                runat="server"
                ID="tbEmail"
                Width="600px" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                CssClass="error"
                Display="Dynamic"
                ControlToValidate="tbEmail"
                ErrorMessage="<br />Please enter an email address." />
                <asp:RegularExpressionValidator 
                ID="valEmailAddress"
                ControlToValidate="tbEmail"
                CssClass="error"
                ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
                ErrorMessage="<br />Email address is invalid." 
                Display="Dynamic" 
                EnableClientScript="true"
                Runat="server"/>
            </div>
            <div >
                <div>
                    <b>Phone:</b>
                </div>
                <idea:TextBox
                runat="server"
                ID="tbPhone"
                Width="600px" />
            </div>
            <div >
                <div>
                    <b>Message:</b>
                </div>
                <idea:TextBox
                runat="server"
                ID="tbMessage"
                TextMode="MultiLine"
                Height="75px"
                Width="600px" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                CssClass="error"
                Display="Dynamic"
                ControlToValidate="tbMessage"
                ErrorMessage="<br />Please enter a message." />
            </div>
            <br />
            <div>
                <idea:LinkButton
                runat="server"
                CssClass="simplebtn"
                ID="lbSend"
                OnClick="SendClicked">
                    Send Message 
                </idea:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpFooter" runat="server">
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSEOView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductSEOView" %>
<telerik:RadAjaxManagerProxy ID="rampActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div style="margin-top: 10px; margin-bottom: 50px;" runat="server" id="divContent">
    <h3>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h3><br />
    <div class="simple-success" id="divSuccess" runat="server">
        This record has been saved
    </div>
    <div class="simple-error" id="divError" runat="server">
        An error occurred.  This record has NOT been saved.
    </div><br />	
    <h6>
        Maybe some sort of instructions or examples....or something.
    </h6><br />				
    <div class="propertyContainer">
        <div>
            <div>Title:</div>
            <idea:TextBox
            runat="server"
            Width="600px"
            ID="tbSEOTitle">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvName"
            InitialValue=""
            ErrorMessage="<br/>Please enter a title."
            ControlToValidate="tbSEOTitle"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Keywords:</div>
            <idea:TextBox
            runat="server"
            Width="600px"
            Height="50px"
            TextMode="MultiLine"
            ID="tbSEOKeywords">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvKewords"
            InitialValue=""
            ErrorMessage="<br/>Please enter a comma separated list of keywords."
            ControlToValidate="tbSEOKeywords"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Description:</div>
            <idea:TextBox
            runat="server"
            Width="600px"
            Height="100px"
            TextMode="MultiLine"
            ID="tbSEODescription">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="RequiredFieldValidator1"
            InitialValue=""
            ErrorMessage="<br/>Please enter a description."
            ControlToValidate="tbSEODescription"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="actionToolBar">
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbSave"
            OnClick="SaveClicked">
                Save 
            </idea:LinkButton>
        </span>&nbsp;
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbCancel"
            OnClick="CancelClicked">
                Cancel
            </idea:LinkButton>
        </span>&nbsp;
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbDelete"
            OnClick="DeleteClicked">
                Delete
            </idea:LinkButton>
        </span>
    </div>
</div>
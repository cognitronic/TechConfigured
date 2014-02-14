<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductPricingView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductPricingView" %>
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
    <div class="propertyContainer">
        <div>
            <div>Retail Price:</div>
            <idea:TextBox
            runat="server"
            Width="100px"
            ID="tbRetailPrice">
            </idea:TextBox>
            <asp:RegularExpressionValidator
            runat="server"
            ID="rfvRetail"
            InitialValue=""
            ErrorMessage="<br/>Please enter a valid price."
            ControlToValidate="tbRetailPrice"
            ValidationExpression="\d*.\d*"
            Display="Dynamic">
                *
            </asp:RegularExpressionValidator>
        </div>
        <div>
            <div>List Price:</div>
            <idea:TextBox
            runat="server"
            Width="100px"
            ID="tbListPrice">
            </idea:TextBox>
            <asp:RegularExpressionValidator
            runat="server"
            ID="rfvListPrice"
            InitialValue=""
            ErrorMessage="<br/>Please enter a valid price."
            ControlToValidate="tbListPrice"
            ValidationExpression="\d*.\d*"
            Display="Dynamic">
                *
            </asp:RegularExpressionValidator>
        </div>
        <div>
            <div>Sale Price:</div>
            <idea:TextBox
            runat="server"
            Width="100px"
            ID="tbSalePrice">
            </idea:TextBox>
            <asp:RegularExpressionValidator
            runat="server"
            ID="rfvSalePrice"
            InitialValue=""
            ErrorMessage="<br/>Please enter a valid price."
            ControlToValidate="tbSalePrice"
            ValidationExpression="\d*.\d*"
            Display="Dynamic">
                *
            </asp:RegularExpressionValidator>
        </div>
        <div>
            <div>Cost Price:</div>
            <idea:TextBox
            runat="server"
            Width="100px"
            ID="tbCostPrice">
            </idea:TextBox>
            <asp:RegularExpressionValidator
            runat="server"
            ID="rfvCostPrice"
            InitialValue=""
            ErrorMessage="<br/>Please enter a valid price."
            ControlToValidate="tbCostPrice"
            ValidationExpression="\d*.\d*"
            Display="Dynamic">
                *
            </asp:RegularExpressionValidator>
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
        </span>
    </div>
</div>
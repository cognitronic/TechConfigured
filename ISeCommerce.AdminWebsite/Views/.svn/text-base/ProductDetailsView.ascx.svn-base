<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailsView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductDetailsView" %>
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
            <span>
                Is Active?:
                <idea:CheckBox
                runat="server"
                ID="cbIsActive" />
            </span>&nbsp;&nbsp;
            <span>
                Is Featured?:
                <idea:CheckBox
                runat="server"
                ID="cbIsFeatured" />
            </span>
        </div>
        <div>
            <div>Category:</div>
            <idea:ProductCategoriesDDL
            runat="server"
            ID="ddlCategory">
            </idea:ProductCategoriesDDL>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvCategory"
            InitialValue=""
            ErrorMessage="<br/>Please select a category."
            ControlToValidate="ddlCategory"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Name:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbName">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvName"
            InitialValue=""
            ErrorMessage="<br/>Please enter a name for the category.  Remember, it must be unique!"
            ControlToValidate="tbName"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Short Description:</div>
            <idea:TextBox
            runat="server"
            Width="600px"
            Height="50px"
            TextMode="MultiLine"
            ID="tbShortDescription">
            </idea:TextBox>
        </div>
        <div>
            <div>Full Description:</div>
            <idea:TextBox
            runat="server"
            Width="600px"
            Height="100px"
            TextMode="MultiLine"
            ID="tbFullDescription">
            </idea:TextBox>
        </div>
        <div>
            <div>Manufacturer:</div>
            <idea:ManufacturerDDL
            runat="server"
            ID="ddlManufacturer">
            </idea:ManufacturerDDL>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvManufacturer"
            InitialValue=""
            ErrorMessage="<br/>Please select a manufacturer."
            ControlToValidate="ddlManufacturer"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Make:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbMake">
            </idea:TextBox>
        </div>
        <div>
            <div>Model:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbModel">
            </idea:TextBox>
        </div>
        <div>
            <div>Manufacturer Part #:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbManufacturerPartNumber">
            </idea:TextBox>
        </div>
        <div>
            <div>SKU:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbSKU">
            </idea:TextBox>
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

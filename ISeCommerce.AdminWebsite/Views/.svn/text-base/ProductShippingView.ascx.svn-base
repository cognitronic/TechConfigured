<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductShippingView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductShippingView" %>
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
        <table class="detailTable">
            <tr>
                <td>
                    <div>Weight ( lbs.):</div>
                    <idea:TextBox
                    runat="server"
                    Width="100px"
                    ID="tbWeight">
                    </idea:TextBox>    
                </td>
                <td>
                    <div>Height ( In.):</div>
                    <idea:TextBox
                    runat="server"
                    Width="100px"
                    ID="tbHeight">
                    </idea:TextBox>    
                </td>
                <td>
                    <div>Width ( In.):</div>
                    <idea:TextBox
                    runat="server"
                    Width="100px"
                    ID="tbWidth">
                    </idea:TextBox>    
                </td>
                <td>
                    <div>Length ( In.):</div>
                    <idea:TextBox
                    runat="server"
                    Width="100px"
                    ID="tbLength">
                    </idea:TextBox>
                </td>
            </tr>
        </table>
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
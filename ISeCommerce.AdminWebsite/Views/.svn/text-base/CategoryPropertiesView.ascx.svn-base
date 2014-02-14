<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryPropertiesView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.CategoryPropertiesView" %>
<telerik:RadAjaxManagerProxy ID="rampActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSaveCategory">
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
            <div>Parent Category:</div>
            <idea:ProductCategoriesDDL
            runat="server"
            ID="ddlParentCategory">
            </idea:ProductCategoriesDDL>
        </div>
        <div>
            <div>Description:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            Height="50px"
            TextMode="MultiLine"
            ID="tbDescription">
            </idea:TextBox>
        </div>
        <div>
            <div>SEO Title:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            Height="50px"
            TextMode="MultiLine"
            ID="tbSEOTitle">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="RequiredFieldValidator1"
            InitialValue=""
            ErrorMessage="<br/>Please enter a title for the search engines."
            ControlToValidate="tbSEOTitle"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>SEO Keywords: <span class="note">(comma separated list)</span></div>
            <idea:TextBox
            runat="server"
            Height="50px"
            Width="400px"
            TextMode="MultiLine"
            ID="tbSEOKeywords">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvKeywords"
            InitialValue=""
            ErrorMessage="<br/>Please enter at least one keyword."
            ControlToValidate="tbSEOKeywords"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>SEO Description:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            Height="50px"
            TextMode="MultiLine"
            ID="tbSEODescription">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfv"
            InitialValue=""
            ErrorMessage="<br/>Please enter a description for the search engines."
            ControlToValidate="tbSEODescription"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
    </div><br /><br />

    <div class="actionToolBar">
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbSaveCategory"
            OnClick="SaveCategoryClicked">
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
            ID="lbProducts"
            OnClick="ProductsClicked">
                View Products
            </idea:LinkButton>
        </span>
    </div>
</div>
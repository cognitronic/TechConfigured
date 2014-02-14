<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerDetailView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.BannerDetailView" %>
<div style="margin-top: 10px; margin-bottom: 50px;">
    <h3>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h3><br />
    <div class="propertyContainer">
        <div>
            <div>Title:</div>
            <idea:TextBox
            runat="server"
            ID="tbTitle"
            Width="400px">
            </idea:TextBox>
        </div>
        <div>
            <div>Tool Tip:</div>
            <idea:Textbox
            runat="server"
            Width="400px"
            ID="tbToolTip" />
        </div>
        <div>
            <div>URL To Photo:</div>
            <telerik:RadBinaryImage 
            runat="server" 
            ID="RadBinaryImage1" 
            AutoAdjustImageControlSize="false" 
            Height="338px" 
            Width="940px" 
            ToolTip='<%#Eval("Title", "Photo of {0}") %>'
            AlternateText='<%#Eval("Title", "Photo of {0}") %>' />
            <br /><br />
            <telerik:RadAsyncUpload 
            runat="server" 
            ID="radAsyncUpload" 
            AllowedFileExtensions="jpg,jpeg,png,gif"
            MaxFileSize="1048576"
            OverwriteExistingFiles="false" 
            OnValidatingFile="RadAsyncUpload1_ValidatingFile">
            </telerik:RadAsyncUpload>
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
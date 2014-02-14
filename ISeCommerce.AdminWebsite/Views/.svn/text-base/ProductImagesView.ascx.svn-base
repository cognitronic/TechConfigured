<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductImagesView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductImagesView" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script type="text/javascript">
        var uploadedFilesCount = 0;
        var isEditMode;
        function validateRadUpload(source, e)
        {
            // When the RadGrid is in Edit mode the user is not obliged to upload file.

            if (isEditMode == null || isEditMode == undefined)
            {
                e.IsValid = false;

                if (uploadedFilesCount > 0)
                {
                    e.IsValid = true;
                }
            }
            isEditMode = null;
        }

        function OnClientFileUploaded(sender, eventArgs)
        {
            uploadedFilesCount++;
        }
            
    </script>

</telerik:RadCodeBlock>

<div style="margin-top: 10px; margin-bottom: 50px;">
    <h4>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h4><br />
    <div>
        <telerik:RadGrid 
        runat="server" 
        ID="rgImages" 
        AllowPaging="True"
        AllowSorting="True" 
        AutoGenerateColumns="False" 
        AllowAutomaticInserts="false" 
        ShowStatusBar="True"
        GridLines="None" 
        OnItemCreated="ItemCreated" 
        PageSize="3" 
        OnNeedDataSource="ItemNeedDataSource" 
        onitemcommand="ItemCommand">
        <PagerStyle Mode="NumericPages" AlwaysVisible="true" />
        <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="ID">
            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton">
                    <HeaderStyle Width="3%" />
                </telerik:GridEditCommandColumn>
                <telerik:GridTemplateColumn 
                HeaderText="Title" 
                UniqueName="Title" 
                SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label 
                        runat="server" 
                        ID="lblTitle" 
                        Text='<%# Eval("Title") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox 
                        runat="server" 
                        Width="200px" 
                        ID="tbTitle" 
                        Text='<%# Eval("Title") %>' />
                        <asp:RequiredFieldValidator 
                        ID="Requiredfieldvalidator1" 
                        runat="server" 
                        ControlToValidate="tbTitle"
                        ErrorMessage="Please enter a title" 
                        Display="Dynamic" 
                        SetFocusOnError="true" />
                    </EditItemTemplate>
                    <HeaderStyle Width="30%" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                HeaderText="Is Default" 
                UniqueName="IsDefault" 
                DataField="IsDefault">
                    <ItemTemplate>
                        <asp:Label 
                        ID="IsDefault" 
                        runat="server" 
                        Text='<%# Eval("IsDefault") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:CheckBox
                        runat="server" 
                        ID="cbIsDefault" 
                        Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("IsDefault")) %>' />
                    </EditItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                HeaderText="ToolTip" 
                UniqueName="ToolTip" 
                DataField="ToolTip">
                    <ItemTemplate>
                        <asp:Label 
                        ID="lblToolTip" 
                        runat="server" 
                        Text='<%# Eval("ToolTip") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadTextBox 
                        runat="server" 
                        Width="200px" 
                        ID="tbToolTip" 
                        Text='<%# Eval("ToolTip") %>' />
                    </EditItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                HeaderText="Image Size" 
                UniqueName="ImageSizeTypeID" 
                DataField="ImageSizeTypeID">
                    <ItemTemplate>
                        <asp:Label 
                        ID="lblImageSizeType" 
                        runat="server" 
                        Text='<%# ((ISeCommerce.Core.Domain.ImageSizeType)Eval("ImageSizeTypeID")).ToString() %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:ImageSizeTypeDDL
                        runat="server"
                        SelectedValue='<%# (DBNull.Value.Equals(DataBinder.Eval(Container.DataItem,"ImageSizeTypeID")) || Convert.ToInt16(DataBinder.Eval(Container.DataItem,"ImageSizeTypeID")) == 0) ? "" : DataBinder.Eval(Container.DataItem,"ImageSizeTypeID") %>'
                        ID="ddlImageSizeType" />
                    </EditItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Path" 
                HeaderText="Image" 
                UniqueName="Upload">
                    <ItemTemplate>
                        <telerik:RadBinaryImage 
                        runat="server" 
                        ID="RadBinaryImage1" 
                        ImageUrl='<%#Eval("Path") %>'
                        AutoAdjustImageControlSize="false" 
                        Height="80px" 
                        Width="80px" 
                        ToolTip='<%#Eval("Title", "Photo of {0}") %>'
                        AlternateText='<%#Eval("Title", "Photo of {0}") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadAsyncUpload 
                        runat="server" 
                        ID="AsyncUpload1" 
                        OnClientFileUploaded="OnClientFileUploaded"
                        AllowedFileExtensions="jpg,jpeg,png,gif"
                        MaxFileSize="1048576"
                        OverwriteExistingFiles="false" 
                        OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                        </telerik:RadAsyncUpload>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn 
                Text="Delete"
                CommandName="Delete" 
                ButtonType="ImageButton">
                    <HeaderStyle Width="2%" />
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" />
            </EditFormSettings>
            <PagerStyle AlwaysVisible="True" />
        </MasterTableView>
    </telerik:RadGrid>
    </div>
</div>
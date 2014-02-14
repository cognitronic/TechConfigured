<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.SettingsListView" %>
<telerik:RadAjaxManagerProxy ID="rampCartActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
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
<div>
    <telerik:RadGrid 
    ID="rgList" 
    runat="server" 
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowSorting="True" 
    GridLines="None" 
    ShowStatusBar="true"
    OnItemCreated="ItemCreated"
    OnNeedDataSource="NeedDataSource"
    OnItemCommand="ItemCommand"
    ShowFooter="true"
    Skin="Windows7">
        <MasterTableView 
        DataKeyNames="ID"
        CommandItemDisplay="None"
        ItemStyle-VerticalAlign="Top"
        AlternatingItemStyle-VerticalAlign="Top"
        EnableNoRecordsTemplate="true"
        NoMasterRecordsText="No Settings Found.">
            <Columns>
                <telerik:GridTemplateColumn 
                DataField="Setting" 
                HeaderText="Setting" 
                SortExpression="Setting" 
                UniqueName="Setting">
                    <ItemTemplate>
                        <%# Eval("Setting")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Description" 
                HeaderText="Description" 
                SortExpression="Description" 
                UniqueName="Description">
                    <ItemTemplate>
                        <%# Eval("Description")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Value" 
                HeaderText="Setting Value (Optional)" 
                SortExpression="Value" 
                UniqueName="Value">
                    <ItemTemplate>
                        <%# Eval("Value")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:TextBox
                        runat="server"
                        Text='<%# Eval("Value") %>'
                        ID="tbValue"
                        Width="250px">
                        </idea:TextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="AltTag" 
                HeaderText="Tool Tip Text(Optional)" 
                SortExpression="AltTag" 
                UniqueName="AltTag">
                    <ItemTemplate>
                        <%# Eval("AltTag")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:TextBox
                        runat="server"
                        Text='<%# Eval("AltTag") %>'
                        ID="tbToolTip"
                        Width="250px">
                        </idea:TextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="URL" 
                HeaderText="URL(Optional)" 
                SortExpression="URL" 
                UniqueName="URL">
                    <ItemTemplate>
                        <%# Eval("URL")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:TextBox
                        runat="server"
                        Text='<%# Eval("URL") %>'
                        ID="tbURL"
                        Width="250px">
                        </idea:TextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="ImagePath" 
                HeaderText="Image(Optional)" 
                SortExpression="ImagePath"
                UniqueName="Upload">
                    <ItemTemplate>
                        <telerik:RadBinaryImage 
                        runat="server" 
                        ID="RadBinaryImage1" 
                        ImageUrl='<%#Eval("ImagePath") %>'
                        AutoAdjustImageControlSize="false" 
                        Height="80px" 
                        Width="80px" 
                        ToolTip='<%#Eval("AltTag", "Photo of {0}") %>'
                        AlternateText='<%#Eval("AltTag", "Photo of {0}") %>' />
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
                <telerik:GridTemplateColumn>
                <ItemTemplate>
                    <idea:LinkButton
                    runat="server"
                    ID="lbEdit"
                    CommandName="Edit"
                    itemID='<%# Eval("ID").ToString() %>'>
                        <img src="/images/pencil.png" border="0" alt="Edit Setting" />
                    </idea:LinkButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            </Columns>
            <ExpandCollapseColumn 
            Resizable="False" 
            Visible="False">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn 
            Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
        <PagerStyle Mode="NextPrevNumericAndAdvanced" AlwaysVisible="true" Position="Bottom"/>
    </telerik:RadGrid>
</div>
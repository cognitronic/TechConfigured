<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.BannerListView" %>
<div class="actionContainer">
    <span>
        <idea:LinkButton
        runat="server"
        CssClass="blueLink"
        ID="lbAddNewItem"
        OnClick="AddNewItemClicked">
            <asp:Image
            runat="server"
            ImageAlign="AbsMiddle"
            ID="imgAddNewItem"
            ToolTip="Add New Banner"
            ImageUrl="~/Images/add.png" />
            Add Banner
        </idea:LinkButton>
    </span>
</div>
<div>
    <telerik:RadGrid
    runat="server"
    ID="rgList"
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowSorting="True" 
    OnItemCommand="ItemCommand"
    GridLines="None" 
    ShowStatusBar="true"
    OnNeedDataSource="NeedDataSource"
    ShowFooter="true"
    Skin="Windows7">
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <MasterTableView 
        DataKeyNames="ID"
        CommandItemDisplay="None"
        EnableNoRecordsTemplate="true"
        NoMasterRecordsText="No Ads Found.">
            <Columns>
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
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Title" 
                HeaderText="Title" 
                SortExpression="Title"
                UniqueName="Title">
                    <ItemTemplate>
                        <%# Eval("Title")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="ToolTip" 
                HeaderText="Tool Tip" 
                SortExpression="ToolTip"
                UniqueName="ToolTip">
                    <ItemTemplate>
                        <%# Eval("ToolTip")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                HeaderStyle-Width="20px">
                    <ItemTemplate>
                        <idea:LinkButton
                        runat="server"
                        ID="lbEdit"
                        OnClick="ViewItemClicked"
                        itemid='<%# Eval("ID").ToString() %>'>
                            <asp:Image
                            runat="server"
                            ID="imgEdit"
                            ToolTip="View Banner"
                            ImageUrl="~/Images/pencil.png"
                            Style="border: none;" />
                        </idea:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                HeaderStyle-Width="20px">
                    <ItemTemplate>
                        <idea:LinkButton
                        runat="server"
                        ID="lbDelete"
                        CommandName="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this record?')"
                        itemid='<%# Eval("ID").ToString() %>'>
                            <asp:Image
                            runat="server"
                            ID="imgDelete"
                            ToolTip="Delete Banner"
                            ImageUrl="~/images/delete.png"
                            Style="border: none;" />
                        </idea:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
        </MasterTableView>
    </telerik:RadGrid>
</div>

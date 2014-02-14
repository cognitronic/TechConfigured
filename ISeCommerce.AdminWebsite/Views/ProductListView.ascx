<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductListView" %>
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
            ToolTip="Add New Product"
            ImageUrl="~/Images/add.png" />
            Add Product
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
    Width="100%"
    GridLines="None" 
    ShowStatusBar="true"
    OnNeedDataSource="NeedDataSource"
    OnItemCommand="ItemCommand"
    OnItemDataBound="ItemDataBound"
    ShowFooter="true"
    EnableEmbeddedSkins="true"
    Skin="Default">
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <MasterTableView 
        DataKeyNames="ID"
        CommandItemDisplay="None"
        EnableNoRecordsTemplate="true"
        NoMasterRecordsText="No categories found.">
            <Columns>
                <telerik:GridTemplateColumn 
                DataField="ID" 
                HeaderText="ID" 
                SortExpression="ID"
                UniqueName="ID">
                    <ItemTemplate>
                        <%# Eval("ID")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Name" 
                HeaderText="Name" 
                SortExpression="Name"
                UniqueName="Name">
                    <ItemTemplate>
                        <%# Eval("Name")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Category.Name" 
                HeaderText="Category" 
                SortExpression="Category.Name"
                UniqueName="Category.Name">
                    <ItemTemplate>
                        <%# Eval("Category.Name")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                HeaderStyle-Width="75px">
                    <ItemTemplate>
                        <div class="actionContainer">
                            <span>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                CssClass="blueLink"
                                OnClick="ViewItemClicked"
                                itemname='<%# Eval("name") %>'
                                itemid='<%# Eval("id").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="Edit Product"
                                    ImageUrl="~/Images/pencil.png" />
                                    Edit
                                </idea:LinkButton>&nbsp;
                            </span>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <PagerStyle Mode="NextPrevAndNumeric" 
            AlwaysVisible="false" 
            Position="Bottom" />
        </MasterTableView>
    </telerik:RadGrid>  
</div>

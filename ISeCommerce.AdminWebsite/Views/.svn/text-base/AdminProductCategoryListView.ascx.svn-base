<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminProductCategoryListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.AdminProductCategoryListView" %>
<div class="actionContainer">
    <span>
        <idea:LinkButton
        runat="server"
        CssClass="blueLink"
        ID="lbAddCategory"
        OnClick="AddCategoryClicked">
            <asp:Image
            runat="server"
            ImageAlign="AbsMiddle"
            ID="imgAddCategory"
            ToolTip="Add New Category"
            ImageUrl="~/Images/add.png" />
            Add Category
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
                DataField="ParentCategory.Name" 
                HeaderText="Parent Category" 
                SortExpression="ParentCategory.Name"
                UniqueName="ParentCategory.Name">
                    <ItemTemplate>
                        <%# Eval("ParentCategory.Name")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                HeaderStyle-Width="150px">
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
                                    ToolTip="Edit Product Category"
                                    ImageUrl="~/Images/pencil.png" />
                                    Edit
                                </idea:LinkButton>&nbsp;
                            </span>
                            <span>
                                <idea:LinkButton
                                runat="server"
                                CssClass="blueLink"
                                ID="lbProducts"
                                OnClick="ViewCategoryProductsClicked"
                                itemname='<%# Eval("name") %>'
                                itemid='<%# Eval("id").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="Image1"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="View Products"
                                    ImageUrl="~/Images/bricks.png" />
                                    Products
                                </idea:LinkButton>
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

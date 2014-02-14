<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.UserListView" %>
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
            ToolTip="Add New User"
            ImageUrl="~/Images/add.png" />
            Add User
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
        NoMasterRecordsText="No users found.">
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
                DataField="UserName" 
                HeaderText="UserName" 
                SortExpression="UserName"
                UniqueName="UserName">
                    <ItemTemplate>
                        <%# Eval("UserName")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="LastName" 
                HeaderText="Name" 
                SortExpression="LastName"
                UniqueName="LastName">
                    <ItemTemplate>
                        <%# Eval("FirstName").ToString() + " " + Eval("LastName").ToString()%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Email" 
                HeaderText="Email" 
                SortExpression="Email"
                UniqueName="Email">
                    <ItemTemplate>
                        <%# Eval("Email")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="IsActive" 
                HeaderText="Status" 
                SortExpression="IsActive"
                UniqueName="IsActive">
                    <ItemTemplate>
                        <%# Eval("IsActive").ToString().Equals("True") ? "Active" : "InActive" %>
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
                                itemname='<%# Eval("FirstName") %>'
                                itemid='<%# Eval("id").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="Edit User"
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

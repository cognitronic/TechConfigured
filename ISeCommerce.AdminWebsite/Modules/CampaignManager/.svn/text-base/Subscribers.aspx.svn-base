<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Subscribers.aspx.cs" Inherits="ISeCommerce.AdminWebsite.Modules.CampaignManager.Subscribers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowSubscriberModal(control, isAdd)
            {
                var oWnd = $find('<%= rwSubscribersModal.ClientID %>');
                oWnd.setUrl("Modals/SubscribersModal.aspx?id=" + $(control).attr("subscriberid") + "&isAdd=" + isAdd);
                oWnd.show();
            }
        </script>
    </telerik:RadCodeBlock>
    <div style="float: left; width: 500px; margin-bottom: 5px;">
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbAddTags"
            CommandName="AddTags"
            OnClick="AddTagsClicked"
            subscriberid='<%# Eval("id").ToString() %>'>
                <asp:Image
                runat="server"
                ID="imgAddSubscriber"
                ToolTip="Add tags to selected subscribers."
                ImageUrl="~/images/tag_blue_add.png"
                Style="border: none;" />
            </idea:LinkButton>
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbRemoveTags"
            CommandName="RemoveTags"
            OnClick="DeleteTagsClicked"
            subscriberid='<%# Eval("id").ToString() %>'>
                <asp:Image
                runat="server"
                ID="imgRemoveTags"
                ToolTip="Remove one or more tags from selected subscribers."
                ImageUrl="~/images/tag_blue_delete.png"
                Style="border: none;" />
            </idea:LinkButton>
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbImportSubscribers"
            OnClick="ImportSubscribersClicked">
                <asp:Image
                runat="server"
                ID="imgImportSubscribers"
                ToolTip="Import a comma separated list of subscribers."
                ImageUrl="~/images/database_add.png"
                Style="border: none;" />
            </idea:LinkButton>
        </span>
        <span>
            &nbsp;Search Column:&nbsp;
            <idea:DropDownList
            runat="server"
            EmptyMessage="Select"
            Width="75px"
            Height="30px"
            ID="ddlSearchColumn">
                <Items>
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text=""
                    Value="" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Email"
                    Value="Email" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="First Name"
                    Value="FirstName" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Last Name"
                    Value="LastName" />
                </Items>
            </idea:DropDownList>
        </span>
        <span>
            <idea:TextBox
            Width="250px"
            runat="server"
            ID="tbSearch">
            </idea:TextBox>
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbSearchSubscribers"
            OnClick="SearchSubscribersClicked">
                <asp:Image
                runat="server"
                ID="imgSearchSubscribers"
                ImageAlign="AbsMiddle"
                ToolTip="Search for subscribers."
                ImageUrl="~/images/smallzoom.png"
                Style="border: none;" />
            </idea:LinkButton>
        </span>
    </div>
    <div class="clear"></div>
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <div>
                <telerik:RadGrid 
                ID="rgSubscribers" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                ShowStatusBar="true"
                OnItemCommand="ItemCommand"
                OnNeedDataSource="NeedDataSource"
                PageSize="5"
                ShowFooter="true"
                Skin="Windows7">
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="Top"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No subscribers found."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            UniqueName="CheckBoxTemplateColumn">
                                <HeaderTemplate>
                                 <idea:CheckBox 
                                 ID="cbSelectAllRows" 
                                 style="cursor: default;"
                                 OnCheckedChanged="ToggleSelectedState" 
                                 AutoPostBack="True" 
                                 runat="server">
                                 </idea:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <idea:CheckBox 
                                    ID="cbSelectRow" 
                                    subscriberID='<%# Eval("ID")%>'
                                    runat="server">
                                    </idea:CheckBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderText="Status"
                            SortExpression="IsActive"
                            UniqueName="IsActive"
                            DataField="IsActive">
                                <ItemTemplate>
                                    <%# Eval("IsActive").ToString() == "True" ? "Active" : "False"%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsActive"
                                    Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("IsActive")) %>'>
                                    </idea:CheckBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Email" 
                            HeaderText="Email" 
                            SortExpression="Email"
                            UniqueName="Email">
                                <ItemTemplate>
                                    <%# Eval("Email")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbEmail"
                                    email='<%# Eval("Email") %>'
                                    Text='<%# Eval("Email").ToString() %>'
                                    width="400px">
                                    </idea:TextBox>
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="rfvEmail"
                                    InitialValue=""
                                    Display="Dynamic"
                                    ErrorMessage="<br />Please enter an email."
                                    ControlToValidate="tbEmail">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator 
                                    ID="valEmailAddress"
                                    ControlToValidate="tbEmail"
                                    ValidationGroup="vgSupport"
                                    ValidationExpression=".*@.*\..*" 
                                    ErrorMessage="<br />Email address is invalid." 
                                    Display="Dynamic" 
                                    EnableClientScript="true"
                                    Runat="server"/>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderText="First Name"
                            SortExpression="FirstName"
                            UniqueName="FirstName"
                            DataField="FirstName">
                                <ItemTemplate>
                                    <%# Eval("FirstName") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbFirstName"
                                    Text='<%# Eval("FirstName") %>'
                                    width="400px">
                                    </idea:TextBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderText="Last Name"
                            SortExpression="LastName"
                            UniqueName="LastName"
                            DataField="LastName">
                                <ItemTemplate>
                                    <%# Eval("LastName") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbLastName"
                                    Text='<%# Eval("LastName") %>'
                                    width="400px">
                                    </idea:TextBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbEdit"
                                    CommandName="Edit"
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgEdit"
                                        ToolTip="Edit Tag"
                                        ImageUrl="~/images/edit.gif"
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
                                    OnClientClick="return confirm('Are you sure you want to delete this item?');"
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgDelete"
                                        ToolTip="Delete Tag"
                                        ImageUrl="~/images/delete.png"
                                        Style="border: none;" />
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
                    <PagerStyle Position="Bottom" Mode="NextPrevNumericAndAdvanced"/>
                </telerik:RadGrid>
            </div>
        </div>
    </div><br />
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow 
            ID="rwSubscribersModal" 
            Title="Manage Subscriber Tags"
            Height="600px"
            Width="710px"
            VisibleStatusbar="false"
            ReloadOnShow="true"
            ShowContentDuringLoad="false"
            style="overflow-x: hidden;"
            Modal="true"
            runat="server" 
            Skin="Windows7">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

</asp:Content>

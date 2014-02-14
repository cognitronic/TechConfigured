<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderListView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.OrderListView" %>
<telerik:RadAjaxManagerProxy ID="rampActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" UpdatePanelRenderMode="Inline" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbUpdateItems">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" UpdatePanelRenderMode="Inline" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div class="actionContainer">
    <span>
        Status:
        <idea:OrderStatusDDL
        runat="server"
        CssClass="blueLink"
        style="vertical-align: bottom;"
        ID="ddlFilterOrderStatus"/>
    </span>&nbsp;&nbsp;&nbsp;&nbsp;
    <span>
        Email:
        <idea:TextBox
        runat="server"
        Skin="Windows7"
        Width="200px"
        ID="tbFilterEmail"/>
    </span>&nbsp;&nbsp;&nbsp;&nbsp;
    <span>
        Order ID#:
        <idea:TextBox
        runat="server"
        Skin="Windows7"
        ID="tbFilterOrderID"/>
    </span>&nbsp;&nbsp;
    <span>
        <idea:LinkButton
        runat="server"
        CssClass="simplebtn"
        style="height: 17px; vertical-align: bottom;"
        ID="lbSearch"
        OnClick="SearchClicked">
            <b>Search</b>
        </idea:LinkButton>
    </span>
</div>
<hr /><br />
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
            ToolTip="Add New Order"
            ImageUrl="~/Images/add.png" />
            New Order
        </idea:LinkButton>
    </span>
</div>
<div>
    <telerik:RadGrid
    runat="server"
    ID="rgList"
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowMultiRowSelection="true"
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
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <MasterTableView 
        DataKeyNames="ID"
        CommandItemDisplay="None"
        EnableNoRecordsTemplate="true"
        NoMasterRecordsText="No orders found.">
            <Columns>
                <telerik:GridClientSelectColumn 
                UniqueName="ClientSelectColumn" />
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
                DataField="Email" 
                HeaderText="Email" 
                SortExpression="Email"
                UniqueName="Email">
                    <ItemTemplate>
                        <%# Eval("Email")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="BillingLastName" 
                HeaderText="Name" 
                SortExpression="BillingLastName"
                UniqueName="BillingLastName">
                    <ItemTemplate>
                        <%# Eval("BillingFirstName").ToString() + " " + Eval("BillingLastName").ToString()%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="OrderTotal" 
                HeaderText="Total" 
                SortExpression="OrderTotal"
                UniqueName="OrderTotal">
                    <ItemTemplate>
                        <%# string.Format("{0:C}",Eval("OrderTotal"))%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="OrderStatusID" 
                HeaderText="Status" 
                SortExpression="OrderStatusID"
                UniqueName="OrderStatusID">
                    <ItemTemplate>
                        <%# Enum.GetName(typeof(ISeCommerce.Core.Domain.OrderStatus), Convert.ToInt16(Eval("OrderStatusID")))%>
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
                                itemname='<%# Eval("BillingFirstName") %>'
                                itemid='<%# Eval("id").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="View Order"
                                    ImageUrl="~/Images/view.png" />
                                    View
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
<div class="updateContainer">
    <span>
        Status:
        <idea:OrderStatusDDL
        runat="server"
        CssClass="blueLink"
        style="vertical-align: bottom;"
        ID="ddlUpdateOrderStatus"/>
    </span>&nbsp;&nbsp
    <span>
        <idea:LinkButton
        runat="server"
        CssClass="simplebtn"
        style="height: 17px; vertical-align: bottom;"
        ID="lbUpdateItems"
        OnClick="UpdateItemsClicked">
            <b>Update Items</b>
        </idea:LinkButton>
    </span>
</div>
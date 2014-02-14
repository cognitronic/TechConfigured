<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailsView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.OrderDetailsView" %>
<div style="margin-top: 10px; margin-bottom: 50px;">
    <h3>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h3><br />
    <h6>
        
    </h6><br />
    <div>
        <span><b>Status</b>:</span>
        <idea:Label
        runat="server"
        ID="lblStatus" />&nbsp;&nbsp;&nbsp;&nbsp;
        <span><b>Order Date</b>:</span>
        <idea:Label
        runat="server"
        ID="lblOrderDate" />
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
        ShowFooter="true"
        EnableEmbeddedSkins="true"
        Skin="Default">
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <MasterTableView 
            DataKeyNames="ID"
            CommandItemDisplay="None"
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="No orders found.">
                <Columns>
                    <telerik:GridTemplateColumn 
                    DataField="OrderID" 
                    HeaderText="OrderID" 
                    SortExpression="OrderID"
                    UniqueName="OrderID">
                        <ItemTemplate>
                            <%# Eval("OrderID")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Product.Name" 
                    HeaderText="Product" 
                    SortExpression="Product.Name"
                    UniqueName="Product.Name">
                        <ItemTemplate>
                            <%# Eval("Product.Name")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Price" 
                    HeaderText="Price" 
                    SortExpression="Price"
                    UniqueName="Price">
                        <ItemTemplate>
                            <%# Eval("Price")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Qty" 
                    HeaderText="Qty" 
                    SortExpression="Qty"
                    UniqueName="Qty">
                        <ItemTemplate>
                            <%# Eval("Qty")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Total" 
                    HeaderText="Total" 
                    SortExpression="Total"
                    UniqueName="Total">
                        <ItemTemplate>
                            <%# string.Format("{0:c}",(Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("Qty"))))%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevAndNumeric" 
                AlwaysVisible="false" 
                Position="Bottom" />
            </MasterTableView>
        </telerik:RadGrid>  
    </div>
    <div class="propertyContainer">
        <div style="float: left; width: 400px; padding: 5px 0px;">
        
            <h4><b>Billing</b></h4><br />
            <div>
                <span><b>Last Name</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingLastName" />
            </div>
            <div>
                <span><b>First Name</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingFirstName" />
            </div>
            <div>
                <span><b>Company</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingCompany" />
            </div>
            <div>
                <span><b>Address 1</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingAddress1" />
            </div>
            <div>
                <span><b>Address 2</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingAddress2" />
            </div>
            <div>
                <span><b>City</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingCity" />
            </div>
            <div>
                <span><b>State</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingState" />
            </div>
            <div>
                <span><b>Zip</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingZip" />
            </div>
            <div>
                <span><b>Phone</b>:</span>
                <idea:Label
                runat="server"
                ID="lblBillingPhone" />
            </div>
            <div>
                <span><b>Email</b>:</span>
                <idea:Label
                runat="server"
                ID="lblEmail" />
            </div>
        </div>
        <div style="float: left; margin-left: 25px; padding: 5px 0px;">
            <h4><b>Shipping</b></h4><br />
            <div>
                <span><b>Last Name</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingLastName" />
            </div>
            <div>
                <span><b>First Name</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingFirstName" />
            </div>
            <div>
                <span><b>Company</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingCompany" />
            </div>
            <div>
                <span><b>Address 1</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingAddress1" />
            </div>
            <div>
                <span><b>Address 2</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingAddress2" />
            </div>
            <div>
                <span><b>City</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingCity" />
            </div>
            <div>
                <span><b>State</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingState" />
            </div>
            <div>
                <span><b>Zip</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingZip" />
            </div>
            <div>
                <span><b>Phone</b>:</span>
                <idea:Label
                runat="server"
                ID="lblShippingPhone" />
            </div>
        </div>
    </div>
</div>

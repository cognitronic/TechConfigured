<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartListView.ascx.cs" Inherits="ISeCommerce.Website.Views.ShoppingCartListView" %>
 <div class="content_sec">
    	<div class="cont_top">&nbsp;</div>
        <div class="cont_center">
<h3 class="heading colr">Shopping Cart Details</h3>
<div class="shoppingcart">
    <telerik:RadListView 
    ID="dlList"  
    runat="server"
    AllowPaging="true"
    OnNeedDataSource="NeedDataSource"
    ItemPlaceholderID="phProducts">
        <LayoutTemplate>
            <ul class="tablehead">
                <li class="remove">Remove</li>
                <li class="thumb">&nbsp;</li>
                <li class="title">Product Name</li>
                <li class="price">Unit Price</li>
                <li class="qty">QTY</li>
                <li class="total">Sub Total</li>
            </ul>
                <asp:PlaceHolder
                runat="server"
                ID="phProducts" />
        </LayoutTemplate>
        <ItemTemplate>
            <ul class="cartlist">
                <li class="remove txt">
                    <idea:LinkButton
                    runat="server"
                    ID="lbDelete"
                    OnClientClick="return confirm('Are you sure you'd like to remove this item?');"
                    CausesValidation="false"
                    OnClick="DeleteClicked"
                    itemID='<%# Eval("ID") %>'>
                        <asp:Image
                        runat="server"
                        ID="imgDelete"
                        ToolTip="Remove Item From Cart"
                        ImageUrl="~/Images/Delete.gif" />
                    </idea:LinkButton>
                </li>
                <li class="thumb"><a href="<%# new ISeCommerce.Services.ProductServices()
                .GetProductURL(Eval("Product.Name").ToString(), 
                Convert.ToInt32(Eval("Product.ProductCategoryID")),
                (IList<ISeCommerce.Core.Domain.ProductCategory>)Cache[ISeCommerce.Core.ResourceStrings.Cache_ProductCategoryList]) %>"><img src="<%# Eval("Product.DefaultImage") == null ? ISeCommerce.Core.ResourceStrings.DummyImagePath.Replace("~","") :  Eval("Product.DefaultImage").ToString().Replace("~","") %>" height="42" width="42" alt="" /></a></li>
                <li class="title txt"><a href="<%# new ISeCommerce.Services.ProductServices()
                .GetProductURL(Eval("Product.Name").ToString(), 
                Convert.ToInt32(Eval("Product.ProductCategoryID")),
                (IList<ISeCommerce.Core.Domain.ProductCategory>)Cache[ISeCommerce.Core.ResourceStrings.Cache_ProductCategoryList]) %>"><%# Eval("Product.Name") %></a></li>
                <li class="price txt"><%# Eval("Price") %></li>
                <li class="qty"><asp:TextBox runat="server" ID="tbQty" Text='<%# Eval("Qty") %>' /></li>
                <li class="total txt"><%# string.Format("{0:c}", Convert.ToDecimal(Eval("Price")) * Convert.ToDecimal(Eval("Qty"))) %></li>
            </ul>
        </ItemTemplate>
        <EmptyDataTemplate>
            <br />
            <p class="price colr bold">
                There are no products that match this request.
            </p><br /><br />
        </EmptyDataTemplate>
    </telerik:RadListView>
    <div class="clear"></div>
    <div style="margin-bottom: 10px;">
        <telerik:RadDataPager  
        ID="rdpList" 
        runat="server" 
        PagedControlID="dlList">
            <Fields>
                <telerik:RadDataPagerButtonField FieldType="FirstPrev" />
                <telerik:RadDataPagerButtonField FieldType="Numeric" />
                <telerik:RadDataPagerButtonField FieldType="NextLast" />
                <telerik:RadDataPagerTemplatePageField HorizontalPosition="NoFloat">
                    <PagerTemplate>
                        <div style="float: right">
                            <b>Items
                                <asp:Label runat="server" ID="CurrentPageLabel" Text="<%# Container.Owner.StartRowIndex+1%>" />
                                to
                                <asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Container.Owner.StartRowIndex+Container.Owner.PageSize %>" />
                                of
                                <asp:Label runat="server" ID="TotalItemsLabel" Text="<%# Container.Owner.TotalRowCount%>" />
                                <br />
                            </b>
                        </div>
                    </PagerTemplate>
                </telerik:RadDataPagerTemplatePageField>
            </Fields>
        </telerik:RadDataPager>
    </div>
    <div class="clear"></div>
    </div>
    <div class="clear"></div>
    <div class="subtotal">
        <idea:LinkButton
        runat="server"
        ID="lbContinueShopping"
        CausesValidation="false"
        CssClass="simplebtn"
        OnClick="ContinueShoppingClicked">
            Continue Shopping
        </idea:LinkButton>
        <idea:LinkButton
        runat="server"
        ID="lbUpdateCart"
        CausesValidation="false"
        CssClass="simplebtn"
        OnClick="UpdateCartClicked">
            Update
        </idea:LinkButton>
    </div>
    <div class="clear"></div>
    </div>
    </div>
    <div class="clear"></div>
    
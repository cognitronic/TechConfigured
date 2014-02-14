<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListView.ascx.cs" Inherits="ISeCommerce.Website.Views.ProductListView" %>
<telerik:RadAjaxPanel
runat="server"
ID="rapProducts">
    <div class="sorting">
        <telerik:RadToolBar 
        ID="rtbList"
        Width="100%"
        OnButtonClick="ButtonClicked"
        Skin="Default"
        runat="server">
            <Items>
                <telerik:RadToolBarButton 
                CommandName="Sort">
                    <ItemTemplate>
                        <div style="padding-left:10px; padding-right:10px;">
                            Sort by: 
                            <telerik:RadComboBox
                            ID="ddlSort"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="SortIndexChanged"
                            Skin="Default"
                            runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem
                                    style="margin-left: 2px; padding: 0"
                                    Text="Lowest Price"
                                    Value="LowPrice" />
                                    <telerik:RadComboBoxItem
                                    style="margin-left: 2px; padding: 0"
                                    Text="Highest Price"
                                    Value="HiPrice" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton CommandName="GridPageSize">
                    <ItemTemplate>
                        <div style="padding-left:10px; padding-right:10px; margin-left: 345px;">
                            Page Size:&nbsp;
                            <idea:GridPageSizeDDL
                            Width="40px"
                            AutoPostBack="true"
                            Skin="Default"
                            OnSelectedIndexChanged="GridPageSizeChanged"
                            ID="ddlGridPageSize"
                            runat="server">
                            </idea:GridPageSizeDDL>
                        </div>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="clear"></div>
    <div class="listing">
    <h3 class="heading colr">Some Sort Of Title...Maybe??</h3>
    <telerik:RadListView 
    ID="dlList"  
    runat="server"
    AllowPaging="true"
    OnNeedDataSource="NeedDataSource"
    ItemPlaceholderID="phProducts">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder
                runat="server"
                ID="phProducts" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li <%# (Container.DataItemIndex + 1) % 4 == 0 ? "class='last'" : String.Empty %> >
                <idea:LinkButton
                runat="server"
                ID="lbProduct"
                categoryid='<%# Eval("ProductCategoryID") %>'
                productname='<%# Eval("Name") %>'
                OnClick="ProductClicked">
                    <asp:Image 
                    runat="server"
                    Height="160px"
                    Width="158px" 
                    ImageUrl='<%# Eval("DefaultImage") == null ? ISeCommerce.Core.ResourceStrings.DummyImagePath :  Eval("DefaultImage")%>' />
                </idea:LinkButton>
                <h6 class="colr"><%#Eval("Name") %></h6>
                <%--<div class="addwish">
                    <idea:LinkButton
                    runat="server"
                    ID="lbAddWish"
                    productid='<%# Eval("ID") %>'
                    OnClick="WishListClicked">
                        Wishlist
                    </idea:LinkButton>
                </div>--%>
                <p class="price colr bold"><%#Eval("ListPrice") %></p>
                <idea:LinkButton
                runat="server"
                CssClass="adcart"
                ToolTip="Add To Cart"
                ID="lbAddCart"
                itemid='<%# Eval("ID") %>'
                itemprice='<%# Eval("ListPrice") %>'
                OnClick="AddToCartClicked">
                </idea:LinkButton>
            </li>
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
</telerik:RadAjaxPanel>
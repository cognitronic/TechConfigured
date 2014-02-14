<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailImagesView.ascx.cs" Inherits="ISeCommerce.Website.Views.ProductDetailImagesView" %>
<div class="prod_detail">
    <h4 class="heading colr">
        <idea:Label
        runat="server"
        ID="lblProductTitle">
        </idea:Label>
    </h4>
<div class="big_thumb">
    <asp:PlaceHolder
    runat="server"
    ID="phSlider" />
    <a href="javascript:void(null)" class="prev"><img src="/images/prev.gif" alt="" /></a>
    <div runat="server" id="divSmallSlider" style="float:left; width:189px !important; overflow:hidden">
    </div>
    <a href="javascript:void(null)" class="next"><img src="/images/next.gif" alt="" /></a>
    <script type="text/javascript" src="/Scripts/cont_slidr.js"></script>
</div>
<div class="desc">
    <h2>
        <idea:Label
        runat="server"
        ID="lblListPrice">
        </idea:Label>
    </h2>
    <div class="clear"></div>
    <p>
        <span class="bold">Availability:</span> In stock
    </p>
    <div class="quickreview">
        <h6>Quick Overview</h6>
        <p>
            <idea:Label
            runat="server"
            ID="lblShortDescription">
            </idea:Label>
        </p>
    </div>
    <div class="addtocart">
        <h6>Add Items to Cart</h6>
        <ul class="left">
            <li class="bold qty">QTY</li>
            <li>
                <asp:TextBox
                runat="server"
                ID="qty"
                CssClass="bar" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvQty"
                Display="Dynamic"
                CssClass="error"
                ErrorMessage="<br />Please add qty."
                ControlToValidate="qty" />
                <asp:RegularExpressionValidator
                runat="server"
                ID="regQty"
                ControlToValidate="qty"
                CssClass="error"
                ErrorMessage="<br />Invalid qty"
                ValidationExpression="\d*">
                </asp:RegularExpressionValidator>
                <%--<input name="qty" type="text" class="bar" />--%>
            </li>
            <li>
                <idea:LinkButton
                runat="server"
                ID="lbAddToCart"
                CssClass="simplebtn"
                OnClick="AddToCartClicked">
                    Add to Cart
                </idea:LinkButton>
            </li>
        </ul>
        <%--<ul>
            <li class="bold or">OR</li>
            <li>
                <idea:LinkButton
                runat="server"
                ID="lbWishlist"
                CssClass="add clear"
                OnClick="AddToWishlistClicked">
                    Add to Wishlist
                </idea:LinkButton>
            </li>
        </ul>--%>
        <div class="clear"></div>
    </div>
</div>
</div>
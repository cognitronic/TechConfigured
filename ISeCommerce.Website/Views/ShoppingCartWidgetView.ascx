<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartWidgetView.ascx.cs" Inherits="ISeCommerce.Website.Views.ShoppingCartWidgetView" %>
<!-- My Cart Products -->
<div class="mycart">
    <div class="small_heading">
        <h5 class="colr">My Cart</h5>
        <div class="clear"></div>
        <span class="veiwitems">
        (<idea:Label
        runat="server"
        ID="lblCartItemsCount">
        </idea:Label>) Items - 
            <idea:LinkButton
            runat="server"
            ID="lbViewCart"
            CssClass="colr"
            CausesValidation="false"
            OnClick="ViewCartClicked">
                View Cart
            </idea:LinkButton>
        </span>
    </div>
    <div runat="server" id="divItems">
                        
    </div>
    <idea:LinkButton
    runat="server"
    ID="lbCheckOut"
    CssClass="simplebtn"
    CausesValidation="false"
    OnClick="CheckOutClicked">
        Check Out
    </idea:LinkButton>
</div>
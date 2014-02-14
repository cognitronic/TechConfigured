<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedProductCarouselView.ascx.cs" Inherits="ISeCommerce.Website.Views.FeaturedProductCarouselView" %>
<div class="content_sec">
    	<div class="cont_top">&nbsp;</div>
        <div class="cont_center">
    	<div id="prod_scroller">
        	<h3 class="colr">
                Featured Products
            </h3>
            <a href="javascript:void(null)" class="prev">&nbsp;</a>
        	<div class="anyClass scrol">
                <asp:PlaceHolder
                runat="server"
                ID="phProducts">
                </asp:PlaceHolder>
			</div>
            <a href="javascript:void(null)" class="next">&nbsp;</a>
        </div>
    <div class="clear"></div>
    </div>
    <div class="cont_botm">&nbsp;</div>
    </div>
    <div class="clear"></div>
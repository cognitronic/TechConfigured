<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ISeCommerce.Website.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h4 class="heading colr">Stylish chair</h4>
            <!-- Product Detail -->
            <div class="prod_detail">
            	<div class="big_thumb">
                	<div id="slider2">
                        <div class="contentdiv">
                        	<img src="images/detail_img1.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                      </div>
                        <div class="contentdiv">
                            <img src="images/detail_img2.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                        </div>
                        <div class="contentdiv">
                            <img src="images/detail_img3.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                        </div>
                        <div class="contentdiv">
                        	<img src="images/detail_img4.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                        </div>
                        <div class="contentdiv">
                        	<img src="images/detail_img5.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                        </div>
                      <div class="contentdiv">
                        	<img src="images/detail_img6.gif" alt="" />
                            <a rel="example_group" href="images/watch.jpg" title="Lorem ipsum dolor sit amet, consectetuer adipiscing elit." class="zoom">&nbsp;</a>
                      </div>
                    </div>
                    <a href="javascript:void(null)" class="prev"><img src="images/prev.gif" alt="" /></a>
                    <div style="float:left; width:189px !important; overflow:hidden;">
                    <div class="anyClass" id="paginate-slider2">
                        <ul>
                            <li><a href="#" class="toc"><img src="images/detail_img1_small.gif" alt="" /></a></li>
                            <li><a href="#" class="toc"><img src="images/detail_img2_small.gif" alt="" /></a></li>
                            <li><a href="#" class="toc"><img src="images/detail_img3_small.gif" alt="" /></a></li>
                            <li><a href="#" class="toc"><img src="images/detail_img4_small.gif" alt="" /></a></li>
                            <li><a href="#" class="toc"><img src="images/detail_img5_small.gif" alt="" /></a></li>
                            <li><a href="#" class="toc"><img src="images/detail_img6_small.gif" alt="" /></a></li>
                        </ul>
                    </div>
                    </div>
                    <a href="javascript:void(null)" class="next"><img src="images/next.gif" alt="" /></a>
                    <script type="text/javascript" src="js/cont_slidr.js"></script>
                </div>
                <div class="desc">
                	<h2>$13,237.97</h2>
                	<a href="#" class="email">Email to a Friend</a>
                    <div class="clear"></div>
                    <div class="rating left">
                        	<a href="#"><img src="images/star_brown.gif" alt="" /></a>
                            <a href="#"><img src="images/star_brown.gif" alt="" /></a>
                            <a href="#"><img src="images/star_brown.gif" alt="" /></a>
                            <a href="#"><img src="images/star_brown.gif" alt="" /></a>
                            <a href="#"><img src="images/star_drk_brown.gif" alt="" /></a>
                    </div>
                    <ul class="reviews margn">
                    	<li><a href="#">3 Review(s)</a></li>
                        <li class="last"><a href="#">Add Your Review</a></li> 
                    </ul>
                    <div class="clear"></div>
                    <p><span class="bold">Availability:</span> In stock</p>
                    <div class="quickreview">
                    	<h6>Quick Overview</h6>
                        <p>
                        	Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed elit. Nulla sem risus, vestibulum in, volutpat eget, dapibus ac, lectus. Curabitur dolor sapien, hendrerit non, suscipit bibendum, auctor ac, arcu. Vestibulum dapibus. Sed pede lacus, pretium in, condimentum sit amet, mollis dapibus, magna. 
                        </p>
                    </div>
                    <div class="addtocart">
                    	<h6>Add Items to Cart</h6>
                        <ul class="left">
                        	<li class="bold qty">QTY</li>
                            <li><input name="qty" type="text" class="bar" /></li>
                            <li><a href="cart.html" class="simplebtn">Add to Cart</a></li>
                        </ul>
                        <ul>
                        	<li class="bold or">OR</li>
                            <li>
                            	<a href="#" class="add clear">Add to Wishlist</a>
                                <a href="#" class="add clear">Add to Compare</a>
                            </li>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="prod_desc">
                	<div class="tab_menu_container">
                        <ul id="tab_menu">  
                            <li><a class="" rel="tab_sidebar_recent">Product Description</a></li>
                            <li><a class="" rel="tab_sidebar_comments">Additional Information</a></li>
                            <li><a class="" rel="tab_sidebar_popular">Similiar Products</a></li>
                            <li><a class="current" rel="tab_sidebar_tags">Tags</a></li>
                        </ul> <!-- END -->
                        <div class="clear"></div>
                    </div>
                    <div class="clear"></div>
                    <div class="tab_container">
                        <div class="tab_container_in">
                            <!-- Recent Articles --> 
                            <div id="tab_sidebar_recent" class="tab_sidebar_list">	
                            		<h4>Description</h4><br />				
                                   <p class="des">
                                   		Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed elit. Nulla sem risus, vestibulum in, volutpat eget, dapibus ac, lectus. Curabitur dolor sapien, hendrerit non, suscipit bibendum, auctor ac, arcu. Vestibulum dapibus. Sed pede lacus, pretium in, condimentum sit amet, mollis dapibus, magna. Ut bibendum dolor nec augue. Ut tempus luctus metus. Sed a velit. Pellentesque at libero elementum ante condimentum sollicitudin. Pellentesque lorem ipsum, semper quis.  interdum et, sollicitudin eu, purus. Vivamus fringilla ipsum vel orci. Phasellus vitae massa at massa pulvinar pellentesque. Fusce tincidunt libero vitae odio. Donec malesuada diam nec mi. Integer hendrerit pulvinar ante. Donec eleifend, nisl eget aliquam congue, justo metus venenatis neque, vel tincidunt elit augue sit amet velit. Nulla facilisi. Aenean suscipit. 
                                   </p>
                            </div> 
                            <!-- END -->
                            
                            
                            
                            <!-- Recent Comments -->
                            <div id="tab_sidebar_comments" class="tab_sidebar_list">  
                                <div class="aditional_info">
                                    <ul>
                                        <li class="bold title">Model</li>
                                        <li class="bold desc">810</li>
                                    </ul>
                                    <ul>
                                        <li class="bold title">In Depth</li>
                                        <li class="desc">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed elit. Nulla sem risus, vestibulum in, volutpat eget, dapibus ac, lectus. Curabitur dolor sapien, hendrerit non, suscipit bibendum, auctor ac, arcu. Vestibulum dapibus. Sed pede lacus, pretium in, condimentum sit amet, mollis dapibus, magna. Ut bibendum dolor nec augue. Ut tempus luctus metus. Sed a velit. Pellentesque at libero elementum ante condimentum sollicitudin. Pellentesque lorem ipsum, semper quis.  interdum et, sollicitudin eu, purus. Vivamus fringilla ipsum vel orci. Phasellus vitae massa at massa pulvinar pellentesque. Fusce tincidunt libero vitae odio. Donec 
                                            </p>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li class="bold title">Dimensions</li>
                                        <li class="desc">4.2 x 2 x 0.6 inches </li>
                                    </ul>
                                    <ul>
                                        <li class="bold title">Activation Information</li>
                                        <li class="desc">
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed elit. Nulla sem risus, vestibulum in, volutpat eget, dapibus ac, lectus. Curabitur dolor sapien, hendrerit non, suscipit bibendum, auctor ac, arcu. Vestibulum dapibus. Sed pede lacus, pretium in, condimentum sit amet, mollis dapibus, magna. Ut bibendum dolor nec augue. Ut tempus luctus metus. Sed a velit. Pellentesque at libero elementum ante condimentum sollicitudin. Pellentesque lorem ipsum, semper quis.  interdum et, sollicitudin eu, purus. Vivamus fringilla ipsum vel orci. Phasellus vitae massa at massa pulvinar pellentesque. Fusce tincidunt libero vitae odio. Donec 
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div> 
                            <!-- END -->
                            
                            
                            
                            <!-- Popular Articles -->
                            <div id="tab_sidebar_popular" class="tab_sidebar_list">
                                <div class="listing">
                                    <ul>
                                        <li>
                                                <a href="detail.html"><img src="images/prod1.gif" alt="" /></a>
                                                <h6 class="colr">Tsovet Watch</h6>
                                                <div class="addwish">
                                                    <a href="#">Wishlist</a>
                                                    <a href="#">Compare</a>
                                                </div>
                                                <p class="price colr bold">$510</p>
                                                <a href="#" class="adcart">&nbsp;</a>
                                            </li>
                                        <li>
                                                <a href="detail.html"><img src="images/prod2.gif" alt="" /></a>
                                                <h6 class="colr">Tsovet Watch</h6>
                                                <div class="addwish">
                                                    <a href="#">Wishlist</a>
                                                    <a href="#">Compare</a>
                                                </div>
                                                <p class="price colr bold">$510</p>
                                                <a href="#" class="adcart">&nbsp;</a>
                                            </li>
                                        <li>
                                                <a href="detail.html"><img src="images/prod3.gif" alt="" /></a>
                                                <h6 class="colr">Tsovet Watch</h6>
                                                <div class="addwish">
                                                    <a href="#">Wishlist</a>
                                                    <a href="#">Compare</a>
                                                </div>
                                                <p class="price colr bold">$510</p>
                                                <a href="#" class="adcart">&nbsp;</a>
                                            </li>
                                        <li class="last">
                                                <a href="detail.html"><img src="images/prod4.gif" alt="" /></a>
                                                <h6 class="colr">Tsovet Watch</h6>
                                                <div class="addwish">
                                                    <a href="#">Wishlist</a>
                                                    <a href="#">Compare</a>
                                                </div>
                                                <p class="price colr bold">$510</p>
                                                <a href="#" class="adcart">&nbsp;</a>
                                            </li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div> 
                            <!-- END -->
                            
                            
                            
                            <!-- Tags Widget -->
                            <div id="tab_sidebar_tags" class="tab_sidebar_list"> 
                                <div class="tags_big">
                                    <h4 class="heading colr">Product Tags</h4>
                                    <p>Add Your Tags:</p>
                                    <span><input name="tags" type="text" class="bar" /></span>
                                    <div class="clear"></div>
                                    <span><a href="#" class="simplebtn"><span>Add Tags</span></a></span>
                                    <p>Use spaces to separate tags. Use single quotes (') for phrases.</p>
                                </div>
                                <div class="clear"></div>
                            </div> <!-- END -->
                            
                            
                            <div class="clear"></div>
                            
                        </div>
                        
                    </div>
                    <script type="text/javascript" src="js/tabs.js"></script>
                </div>
            </div>
    </form>
</body>
</html>

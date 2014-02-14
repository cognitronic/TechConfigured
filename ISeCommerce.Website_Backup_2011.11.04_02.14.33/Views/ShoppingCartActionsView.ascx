<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartActionsView.ascx.cs" Inherits="ISeCommerce.Website.Views.ShoppingCartActionsView" %>
        
<%--<telerik:RadAjaxManagerProxy ID="rampCartActions" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbUpdateShipping">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divGrandTotal" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="cbSameAsShipping">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divBillingInfo" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbPurchase">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divGrandTotal" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lbUpdateShipping" />
                <telerik:AjaxUpdatedControl ControlID="lbPurchase" />
                <telerik:AjaxUpdatedControl ControlID="divConfirmation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />--%>
<div class="content_sec">
        <div class="cont_center">
    <div class="sections">
                	<div class="custinfo">
                    	<h6 class="colr">Shipping Information</h6>
                        <p>Enter your shipping address information.</p>
                          <ul>
                       	      <li class="bold">First Name</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingFirstName" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator5"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="tbShippingFirstName"
                                ErrorMessage="<br />Enter first name." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Last Name</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingLastName" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator6"
                                Display="Dynamic"
                                CssClass="error"
                                InitialValue=""
                                ControlToValidate="tbShippingLastName"
                                ErrorMessage="<br />Enter last name." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Email</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbEmail" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator7"
                                Display="Dynamic"
                                CssClass="error"
                                InitialValue=""
                                ControlToValidate="tbEmail"
                                ErrorMessage="<br />Enter email address." />
                                <asp:RegularExpressionValidator 
                                ID="valEmailAddress"
                                ControlToValidate="tbEmail"
                                CssClass="error"
                                ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
                                ErrorMessage="<br />Email address is invalid." 
                                Display="Dynamic" 
                                EnableClientScript="true"
                                Runat="server"/>
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Phone</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbPhone" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator8"
                                CssClass="error"
                                Display="Dynamic"
                                InitialValue=""
                                ControlToValidate="tbPhone"
                                ErrorMessage="<br />Enter phone." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Company</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbCompany" />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Address</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingAddress1" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator9"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="tbShippingAddress1"
                                ErrorMessage="<br />Enter Address." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Address2</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingAddress2" />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">City</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingCity" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator10"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="tbShippingCity"
                                ErrorMessage="<br />Enter city." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">State</li>
                              <li>
                          	    <idea:USStatesDDL
                                runat="server"
                                ID="ddlShippingState" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                CssClass="error"
                                ID="RequiredFieldValidator11"
                                Display="Dynamic"
                                InitialValue=""
                                ControlToValidate="ddlShippingState"
                                ErrorMessage="<br />Select state." />
                              </li>
                          </ul>
                          <ul>
                       	      <li class="bold">Zip</li>
                              <li>
                          	    <asp:TextBox
                                runat="server"
                                ID="tbShippingZip" />
                                <asp:RequiredFieldValidator
                                runat="server"
                                ID="RequiredFieldValidator12"
                                Display="Dynamic"
                                InitialValue=""
                                CssClass="error"
                                ControlToValidate="tbShippingZip"
                                ErrorMessage="<br />Enter Zip." />
                                <asp:RegularExpressionValidator
                                runat="server"
                                Display="Dynamic"
                                ID="RegularExpressionValidator1"
                                CssClass="error"
                                ControlToValidate="tbShippingZip"
                                ErrorMessage="<br />Invalid Zip Code"
                                ValidationExpression="\d{5}">
                                </asp:RegularExpressionValidator>
                              </li>
                          </ul>
                        <div class="clear"></div>
                    </div>
                    <div class="centersec">
                        <div class="custinfo" id="divBillingInfo" runat="server">
                    	    <h6 class="colr"><b>Billing Information</b></h6>
                            <p>Enter your billing address information.</p><br />
                            <ul>
                                <li class="bold">
                                    <idea:CheckBox 
                                    runat="server" 
                                    AutoPostBack="true"
                                    CausesValidation="false"
                                    OnCheckedChanged="SameAsShippingCheckChanged"
                                    ID="cbSameAsShipping" /> Same As Shipping
                                </li>
                            </ul>
                              <ul>
                       	          <li class="bold">First Name</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingFirstName" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator13"
                                    CssClass="error"
                                    Display="Dynamic"
                                    InitialValue=""
                                    ControlToValidate="tbBillingFirstName"
                                    ErrorMessage="<br />Enter first name." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Last Name</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingLastName" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator14"
                                    Display="Dynamic"
                                    InitialValue=""
                                    CssClass="error"
                                    ControlToValidate="tbBillingLastName"
                                    ErrorMessage="<br />Enter last name." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Email</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingEmail" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator15"
                                    CssClass="error"
                                    Display="Dynamic"
                                    InitialValue=""
                                    ControlToValidate="tbBillingEmail"
                                    ErrorMessage="<br />Enter email." />
                                    <asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator3"
                                    ControlToValidate="tbBillingEmail"
                                    CssClass="error"
                                    ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
                                    ErrorMessage="<br />Email address is invalid." 
                                    Display="Dynamic" 
                                    EnableClientScript="true"
                                    Runat="server"/>
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Phone</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingPhone" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator16"
                                    CssClass="error"
                                    Display="Dynamic"
                                    InitialValue=""
                                    ControlToValidate="tbBillingPhone"
                                    ErrorMessage="<br />Enter phone." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Address</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingAddress1" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator18"
                                    Display="Dynamic"
                                    InitialValue=""
                                    CssClass="error"
                                    ControlToValidate="tbBillingAddress1"
                                    ErrorMessage="<br />Enter address." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Address2</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingAddress2" />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">City</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingCity" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator19"
                                    Display="Dynamic"
                                    CssClass="error"
                                    InitialValue=""
                                    ControlToValidate="tbBillingCity"
                                    ErrorMessage="<br />Enter city." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">State</li>
                                  <li>
                          	        <idea:USStatesDDL
                                    runat="server"
                                    ID="ddlBillingState" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    CssClass="error"
                                    ID="RequiredFieldValidator20"
                                    Display="Dynamic"
                                    InitialValue=""
                                    ControlToValidate="ddlBillingState"
                                    ErrorMessage="<br />Select state." />
                                  </li>
                              </ul>
                              <ul>
                       	          <li class="bold">Zip</li>
                                  <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbBillingZip" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator21"
                                    Display="Dynamic"
                                    CssClass="error"
                                    InitialValue=""
                                    ControlToValidate="tbBillingZip"
                                    ErrorMessage="<br />Enter zip." />
                                    <asp:RegularExpressionValidator
                                    runat="server"
                                    Display="Dynamic"
                                    ID="RegularExpressionValidator2"
                                    CssClass="error"
                                    ControlToValidate="tbBillingZip"
                                    ErrorMessage="<br />Invalid Zip Code"
                                    ValidationExpression="\d{5}">
                                    </asp:RegularExpressionValidator>
                                  </li>
                              </ul>
                            <div class="clear"></div>
                        </div>
                    </div>
                    <div class="custinfo">
                    	<div>
                        <h6 class="colr">Credit Card Information</h6>
                        <p>Will use billing address to verify.</p>
                            <ul>
                       	        <li class="bold">
                                    Cardholder Name
                                </li>
                                <li>
                          	        <asp:TextBox
                                    runat="server"
                                    ID="tbCardholderName" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="rfvCardholderName"
                                    Display="Dynamic"
                                    InitialValue=""
                                    CssClass="error"
                                    ControlToValidate="tbCardholderName"
                                    ErrorMessage="<br />Enter name exactly as shown on card." />
                                </li>
                            </ul>
                            <ul>
                       	        <li class="bold">
                                    Card Number
                                </li>
                                <li>
                          	        <asp:TextBox
                                    ID="tbCardNumber" 
                                    runat="server" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    Display="Dynamic"
                                    CssClass="error"
                                    InitialValue=""
                                    ControlToValidate="tbCardNumber"
                                    ErrorMessage="<br />Enter card number." />
                                    <asp:RegularExpressionValidator
                                    runat="server"
                                    ID="RegularExpressionValidator23"
                                    Display="Dynamic"
                                    ControlToValidate="tbCardNumber"
                                    CssClass="error"
                                    ErrorMessage="<br />Invalid number.  Enter only card number with no spaces or dashes."
                                    ValidationExpression="\d*">
                                    </asp:RegularExpressionValidator>
                                </li>
                            </ul>
                            <ul>
                       	        <li class="bold">
                                    Expiration Date
                                </li>
                                <li>
                                    <span>
                          	        <idea:MonthsDDL
                                    runat="server"
                                    Width="60px"
                                    ID="ddlExpirationDate" />
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator2"
                                    CssClass="error"
                                    Display="Dynamic"
                                    InitialValue=""
                                    ControlToValidate="ddlExpirationDate"
                                    ErrorMessage="<br />Select expiration month." />
                                    </span>
                                    <span>
                                        <idea:DropDownList 
                                        ID="ddlExpirationYear" 
                                        runat="server" 
                                        Width="60px" 
                                        EnableScreenBoundaryDetection="false"
                                        MaxHeight="150px">
                                            <Items>
                                                <telerik:RadComboBoxItem Selected="true" Text="" Value="">
                                                </telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2011" Text="2011"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2012" Text="2012"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2013" Text="2013"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2014" Text="2014"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2015" Text="2015"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2016" Text="2016"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2017" Text="2017"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2018" Text="2018"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2019" Text="2019"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2020" Text="2020"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2021" Text="2021"></telerik:RadComboBoxItem>
                                            </Items>
                                        </idea:DropDownList>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator4"
                                        Display="Dynamic"
                                        CssClass="error"
                                        InitialValue=""
                                        ControlToValidate="ddlExpirationYear"
                                        ErrorMessage="<br />Select expiration year." />
                                    </span>
                                </li>
                            </ul>
                            <ul>
                       	        <li class="bold">
                                    CVV Code
                                </li>
                                <li>
                          	        <asp:TextBox
                                    ID="tbCvvCode"
                                    Width="40px" 
                                    runat="server" />
                                    <asp:RequiredFieldValidator 
                                    runat="server" 
                                    CssClass="error"
                                    ID="RequiredFieldValidator17" 
                                    ControlToValidate="tbCvvCode"
                                    ErrorMessage="<br />Please enter the CVV code on the back of your credit card.">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                    runat="server"
                                    Display="Dynamic"
                                    ID="regCVV"
                                    CssClass="error"
                                    ControlToValidate="tbCvvCode"
                                    ErrorMessage="<br />Invalid CVV Code"
                                    ValidationExpression="\d{3,4}">
                                    </asp:RegularExpressionValidator>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="custinfo">
                    	<div>
                        <h6 class="colr">Calculate Shipping</h6>
                        <p>Based on shipping address</p>
                            <div class="clear"></div>
                            <br />
                            <idea:LinkButton
                                runat="server"
                                ID="lbUpdateShipping"
                                OnClick="UpdateShippingClicked"
                                CssClass="proceed right">
                                    <b>Update Shipping Total</b>
                                </idea:LinkButton>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="grand_total" runat="server" id="divGrandTotal">
                    	<div>
                        <h6 class="colr"><b>Totals</b></h6>
                            <ul>
                        	    <li class="title">Items</li>
                                <li class="price bold">
                                    <idea:Label
                                    runat="server"
                                    ID="lblSubtotal" />
                                </li>
                            </ul>
                            <ul>
                        	    <li class="title">Shipping</li>
                                <li class="price bold">
                                    <idea:Label
                                    runat="server"
                                    ID="lblShippingTotal" />
                                </li>
                            </ul>
                            <ul>
                        	    <li class="title">Tax</li>
                                <li class="price bold">
                                    <idea:Label
                                    runat="server"
                                    ID="lblTaxTotal" />
                                </li>
                            </ul>
                            <ul>
                        	    <li class="title"><h5>Grand total</h5></li>
                                <li class="price bold">
                                    <idea:Label
                                    runat="server"
                                    ID="lblGrandTotal" />
                                </li>
                            </ul>
                            <div class="clear"></div>
                                <idea:LinkButton
                                runat="server"
                                ID="lbPurchase"
                                OnClick="PurchaseClicked"
                                CssClass="proceed right">
                                    <b>Purchase</b>
                                </idea:LinkButton>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div  runat="server" id="divConfirmation" class="custinfo" style="padding: 10px; float: right; margin-right: 22px; width: 245px;">
                        <h5 class="colr"><b>Your Order Is Being Processed!</b></h5>
                        <br /><br />
                        <p runat="server" id="pMessage">
                            
                        </p>
                    </div>
                </div>
            </div>
        <div class="clear"></div>
        </div>
    <div class="clear"></div>
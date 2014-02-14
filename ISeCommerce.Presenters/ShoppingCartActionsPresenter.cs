using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISeCommerce.Presenters.ViewInterfaces;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Security;
using IdeaSeed.Core;
using IdeaSeed.Core.eCommerce.PaymentProcessing.AuthorizeDotNet;
using ISeCommerce.Services;
using ISeCommerce.Core;
using ISeCommerce.Core.Domain.Interfaces;
using IdeaSeed.Core.eCommerce.Shipping;
using IdeaSeed.Core.eCommerce.Shipping.UPS;
using System.Configuration;

namespace ISeCommerce.Presenters
{
    public class ShoppingCartActionsPresenter : Presenter
    {
        IShoppingCartActionsView _view;
        bool orderSaved = false;

        public ShoppingCartActionsPresenter(IShoppingCartActionsView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IShoppingCartActionsView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnPurchase += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnPurchase);
            _view.OnUpdateShipping += new EventHandler<IdeaSeedLinkButtonArgs>(_view_OnUpdateShipping);
        }

        void _view_OnUpdateShipping(object sender, IdeaSeedLinkButtonArgs e)
        {
            _view.GrandTotal = CalculateGrandTotal(true);
        }

        void _view_OnPurchase(object sender, IdeaSeedLinkButtonArgs e)
        {
            SaveOrder();
            //SendConfirmation();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.GrandTotal = CalculateGrandTotal(false);
        }

        void _view_InitView(object sender, EventArgs e)
        {
            
        }

        private decimal CalculateSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                subtotal += (item.Qty * item.Price);
            }
            return subtotal;
        }

        private decimal CalculateShipping()
        {
            decimal shippingWeight = 0;
            foreach (var item in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                shippingWeight += ((decimal)item.Product.Weight * item.Qty);
            }
            if (shippingWeight < 2)
                shippingWeight = 2;

            ShippingRateRequest upsrequest = new ShippingRateRequest();
            ShippingRateResponse srr = upsrequest.GetGroundShippingRate(
                ResourceStrings.Shipping_ShipFromCountry,
                ResourceStrings.Shipping_ShipFromZip, 
                ResourceStrings.Shipping_ShipFromCountry, 
                _view.ShipToZip, 
                shippingWeight.ToString());

            if (srr.Description.Equals("Success"))
            {
                return decimal.Parse(srr.Rate);
            }
            return -2;
        }

        //TODO: Figure out tax calculation
        private decimal CalculateTax()
        {
            var setting = new ApplicationSettingServices().GetBySetting("State Tax", Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            decimal tax = (decimal)(CalculateSubtotal() * Convert.ToDecimal(setting.Value));
            return tax;
        }

        private decimal CalculateGrandTotal(bool withShipping)
        {
            if (withShipping)
            {
                _view.ItemsTotal = CalculateSubtotal();
                _view.ShippingTotal = CalculateShipping();
                _view.TaxTotal = CalculateTax();
                return CalculateSubtotal() + CalculateShipping() + CalculateTax();
            }
            else
            {
                _view.ItemsTotal = CalculateSubtotal();
                _view.TaxTotal = CalculateTax();
                return CalculateSubtotal() + CalculateTax();
            }
        }

        private void SendConfirmation()
        {
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append("<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=840 style='width:7.0in;margin-left:-4.5pt;border-collapse:collapse;mso-yfti-tbllook: 1184;mso-padding-alt:0in 0in 0in 0in'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes'>  <td width=840 style='width:7.0in;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal style='margin-top:12.0pt;margin-right:0in;margin-bottom:  12.0pt;margin-left:0in'><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>Thank you for placing an order  with TechConfigured! Your order reference number is <b><span  style='color:#FF6600'>100001</span></b>. Please save this email for your  records, as it contains important purchase information. If you have any  questions regarding your order please contact <a  href='http://www.techconfigured.com/Customer-Support'><span style='text-decoration:  none;text-underline:none'>Customer Support</span></a> and use the order  reference number above. <o:p></o:p></span></p>  </td> </tr></table><p class=MsoNormal><span style='mso-fareast-font-family:Arial;display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=840 style='width:7.0in;margin-left:-4.5pt;border-collapse:collapse;mso-yfti-tbllook: 1184;mso-padding-alt:0in 0in 0in 0in'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:.25in'>  <td width=503 style='width:301.5pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt;  height:.25in'>  <p class=MsoNormal><b><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>Product</span></b><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'> <o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt;  height:.25in'>  <p class=MsoNormal align=center style='text-align:center'><b><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Qty</span></b><span style='font-size:7.0pt;font-family:  Arial;mso-fareast-font-family:Arial'> <o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt;  height:.25in'>  <p class=MsoNormal align=right style='text-align:right'><b><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Price</span></b><span style='font-size:7.0pt;font-family:  Arial;mso-fareast-font-family:Arial'> <o:p></o:p></span></p>  </td> </tr>");
            foreach (var item in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                sb.Append(" <tr style='mso-yfti-irow:1'>  <td width=503 style='width:301.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>");
                sb.Append(item.Product.Name);
                sb.Append("<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=center style='text-align:center'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
                sb.Append(item.Qty.ToString());
                sb.Append("<o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
                sb.Append(string.Format("{0:C}", item.Price));
                sb.Append("<o:p></o:p></span></p>  </td> </tr>");
            }
            sb.Append(" <tr style='mso-yfti-irow:2'>  <td width=503 style='width:301.5pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;background:#dddddd;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:3'>  <td width=503 style='width:301.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Items:<o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
            //sb.Append("<tr><td>&nbsp;</td><td align='right'>");
            //sb.Append("Items:</td><td align='right'>");
            sb.Append(string.Format("{0:C}",CalculateSubtotal()));
            sb.Append("<o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:4'>  <td width=503 style='width:301.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Shipping:<o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
            sb.Append(string.Format("{0:C}",CalculateShipping()));
            sb.Append("<o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:5'>  <td width=503 style='width:301.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Tax:<o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
            sb.Append(string.Format("{0:C}",CalculateTax()));
            sb.Append("<o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:6;mso-yfti-lastrow:yes'>  <td width=503 style='width:301.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-size:7.0pt;font-family:Arial;  mso-fareast-font-family:Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=255 style='width:153.0pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><b><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>Grand Total:</span></b><span style='font-size:7.0pt;  font-family:Arial;mso-fareast-font-family:Arial'> <o:p></o:p></span></p>  </td>  <td width=83 style='width:49.5pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal align=right style='text-align:right'><b><span  style='font-size:7.0pt;font-family:Arial;mso-fareast-font-family:  Arial'>");
            sb.Append(string.Format("{0:C}",CalculateGrandTotal(true)));
            sb.Append("</span></b><span style='font-size:7.0pt;font-family:  Arial;mso-fareast-font-family:Arial'> <o:p></o:p></span></p>  </td> </tr></table>");
            sb.Append(EmailHTMLEnd());

            var success = IdeaSeed.Core.Mail.EmailUtils.SendEmail("dschreiber@mydatapath.com,cognitronic@gmail.com", "eCommerce@mydatapath.com","","", "Thank you for your order!", sb.ToString(),true,"");
        }

        private string EmailHTMLStart()
        {
            string cssstyle = @"<style><!-- /* Font Definitions */ Table{border-collapse: collapse;}@font-face	{font-family:'Arial';	panose-1:2 4 5 3 5 4 6 3 2 4;	mso-font-charset:1;	mso-generic-font-family:roman;	mso-font-format:other;	mso-font-pitch:variable;	mso-font-signature:0 0 0 0 0 0;}@font-face	{font-family:Tahoma;	panose-1:2 11 6 4 3 5 4 4 2 4;	mso-font-charset:0;	mso-generic-font-family:swiss;	mso-font-pitch:variable;	mso-font-signature:-520081665 -1073717157 41 0 66047 0;} /* Style Definitions */ p.MsoNormal, li.MsoNormal, div.MsoNormal	{mso-style-unhide:no;	mso-style-qformat:yes;	mso-style-parent:'';	margin:0in;	margin-bottom:.0001pt;	mso-pagination:widow-orphan;	font-size:12.0pt;	font-family:'Arial','serif';	mso-fareast-font-family:'Arial';	mso-fareast-theme-font:minor-fareast;}p.MsoAcetate, li.MsoAcetate, div.MsoAcetate	{mso-style-noshow:yes;	mso-style-priority:99;	mso-style-link:'Balloon Text Char';	margin:0in;	margin-bottom:.0001pt;	mso-pagination:widow-orphan;	font-size:8.0pt;	font-family:'Tahoma','sans-serif';	mso-fareast-font-family:'Arial';	mso-fareast-theme-font:minor-fareast;}span.BalloonTextChar	{mso-style-name:'Balloon Text Char';	mso-style-noshow:yes;	mso-style-priority:99;	mso-style-unhide:no;	mso-style-locked:yes;	mso-style-link:'Balloon Text';	mso-ansi-font-size:8.0pt;	mso-bidi-font-size:8.0pt;	font-family:'Tahoma','sans-serif';	mso-ascii-font-family:Tahoma;	mso-fareast-font-family:'Arial';	mso-fareast-theme-font:minor-fareast;	mso-hansi-font-family:Tahoma;	mso-bidi-font-family:Tahoma;}.MsoChpDefault	{mso-style-type:export-only;	mso-default-props:yes;	font-size:10.0pt;	mso-ansi-font-size:10.0pt;	mso-bidi-font-size:10.0pt;}@page WordSection1	{size:8.5in 11.0in;	margin:1.0in 1.0in 1.0in 1.0in;	mso-header-margin:.5in;	mso-footer-margin:.5in;	mso-paper-source:0;}div.WordSection1	{page:WordSection1;}--></style>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title> Order Confirmation </title>");
            sb.Append(cssstyle);
            sb.Append("</head>");
            sb.Append("<body lang=EN-US link=blue vlink=purple style='tab-interval:.5in'><div class=WordSection1><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=845 style='width:506.7pt;margin-left:-.1in;border-collapse:collapse;mso-yfti-tbllook: 1184;mso-padding-alt:0in 0in 0in 0in'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes;  page-break-inside:avoid;height:1.0pt'>  <td width=845 style='width:506.7pt;background:black;padding:0in 0in 0in 0in;  height:1.0pt'>  <p class=MsoNormal><a href='http://www.techconfigured.com/'><span  style='font-family:Arial;mso-fareast-font-family:Arial';  mso-no-proof:yes;text-decoration:none;text-underline:none'><img border=0  width=375 height=70 id='_x0000_i1031'  src='http://www.techconfigured.com/images/logo.png'  alt='http://www.techconfigured.com/images/logo.png'></span></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td> </tr></table><p class=MsoNormal><span style='mso-fareast-font-family:Arial;display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=780 style='width:6.5in;margin-left:-.2in; margin-top: -15px;border-collapse:collapse;mso-yfti-tbllook: 1184;mso-padding-alt:0in 0in 0in 0in'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes;  page-break-inside:avoid;height:1.0pt'>  <td width=167 style='width:100.2pt;padding:0in 0in 0in 0in;height:1.0pt'>  <p class=MsoNormal align=center style='text-align:center'><a  href='http://www.techconfigured.com/Networking'><b style='mso-bidi-font-weight:  normal'><span style='font-size:9.5pt;font-family:Arial;  mso-fareast-font-family:Arial;color:white;mso-no-proof:yes;  text-decoration:none;text-underline:none'><img border=0 width=134 height=33  id='_x0000_i1030' src='http://www.techconfigured.com/images/networkingtab.gif'  alt='http://www.techconfigured.com/images/networkingtab.gif'></span></b></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td>  <td style='padding:0in 0in 0in 0in;height:1.0pt'>  <p class=MsoNormal align=center style='text-align:center'><a  href='http://www.techconfigured.com/Cables'><b style='mso-bidi-font-weight:  normal'><span style='font-size:9.5pt;font-family:Arial;  mso-fareast-font-family:Arial;color:white;mso-no-proof:yes;  text-decoration:none;text-underline:none'><img border=0 width=96 height=33  id='_x0000_i1029' src='http://www.techconfigured.com/images/cablestab.gif'  alt='http://www.techconfigured.com/images/cablestab.gif'></span></b></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td>  <td style='padding:0in 0in 0in 0in;height:1.0pt'>  <p class=MsoNormal align=center style='text-align:center'><a  href='http://www.techconfigured.com/Computers'><b style='mso-bidi-font-weight:  normal'><span style='font-size:9.5pt;font-family:Arial;  mso-fareast-font-family:Arial;color:white;mso-no-proof:yes;  text-decoration:none;text-underline:none'><img border=0 width=130 height=33  id='_x0000_i1028' src='http://www.techconfigured.com/images/computerstab.gif'  alt='http://www.techconfigured.com/images/computerstab.gif'></span></b></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td>  <td width=245 style='width:147.0pt;padding:0in 0in 0in 0in;height:1.0pt'>  <p class=MsoNormal align=center style='text-align:center'><a  href='http://www.techconfigured.com/Computer-Hardware'><b style='mso-bidi-font-weight:  normal'><span style='font-size:9.5pt;font-family:Arial;  mso-fareast-font-family:Arial;color:white;mso-no-proof:yes;  text-decoration:none;text-underline:none'><img border=0 width=196 height=33  id='_x0000_i1027'  src='http://www.techconfigured.com/images/computerhardwaretab.gif'  alt='http://www.techconfigured.com/images/computerhardwaretab.gif'></span></b></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td>  <td width=162 style='width:1.35in;padding:0in 0in 0in 0in;height:1.0pt'>  <p class=MsoNormal align=center style='text-align:center'><a  href='http://www.techconfigured.com/Software'><b style='mso-bidi-font-weight:  normal'><span style='font-size:9.5pt;font-family:Arial;  mso-fareast-font-family:Arial;color:white;mso-no-proof:yes;  text-decoration:none;text-underline:none'><img border=0 width=129 height=33  id='_x0000_i1026' src='http://www.techconfigured.com/images/softwaretab.gif'  alt='http://www.techconfigured.com/images/softwaretab.gif'></span></b></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td> </tr></table><p class=MsoNormal><span style='mso-fareast-font-family:Arial;display:none;mso-hide:all'><o:p>&nbsp;</o:p></span></p>");
            return sb.ToString();
        }

        private string EmailHTMLEnd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<p class=MsoNormal style='margin-bottom:12.0pt'><span style='mso-fareast-font-family:Arial'><o:p>&nbsp;</o:p></span></p><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=840 style='width:7.0in;margin-left:-4.5pt;background:black;border-collapse:collapse; mso-yfti-tbllook:1184;mso-padding-alt:0in 0in 0in 0in' padding=0px> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:24.0pt'>  <td width=425 style='width:254.75pt;padding:.75pt .75pt .75pt .75pt;  height:24.0pt'>  <p class=MsoNormal><a href='http://www.techconfigured.com/'><span  style='font-family:Arial;mso-fareast-font-family:Arial;  mso-no-proof:yes;text-decoration:none;text-underline:none'><img border=0  width=214 height=40 id='_x0000_i1025'  src='http://www.techconfigured.com/images/smalllogo.png'  alt='http://www.techconfigured.com/images/smalllogo.png'></span></a><span  style='font-family:Arial;mso-fareast-font-family:Arial'><o:p></o:p></span></p>  </td>  <td width=295 valign=bottom style='width:177.25pt;padding:.75pt .75pt .75pt .75pt;  height:24.0pt' color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/RSS'><b><span style='font-size:7.0pt;  color:white;text-decoration:none;text-underline:none'>RSS Feeds </span></b></a><o:p></o:p></span></p>  </td>  <td width=120 valign=bottom style='width:1.0in;padding:.75pt 3.0pt .75pt .75pt;  height:24.0pt' color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/About-Us'><b><span style='font-size:7.0pt;  color:white;text-decoration:none;text-underline:none'>About Us </span></b></a><o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:1'>  <td width=425 style='width:254.75pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-family:Arial;mso-fareast-font-family:  Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=295 style='width:177.25pt;padding:.75pt .75pt .75pt .75pt'  color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/Return-Policy'><b><span style='font-size:  7.0pt;color:white;text-decoration:none;text-underline:none'>Return Policy  Information </span></b></a><o:p></o:p></span></p>  </td>  <td width=120 style='width:1.0in;padding:.75pt 3.0pt .75pt .75pt'  color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/Contact-Us'><b><span style='font-size:  7.0pt;color:white;text-decoration:none;text-underline:none'>Contact Us </span></b></a><o:p></o:p></span></p>  </td> </tr> <tr style='mso-yfti-irow:2;mso-yfti-lastrow:yes'>  <td width=425 style='width:254.75pt;padding:.75pt .75pt .75pt .75pt'>  <p class=MsoNormal><span style='font-family:Arial;mso-fareast-font-family:  Arial'>&nbsp;<o:p></o:p></span></p>  </td>  <td width=295 style='width:177.25pt;padding:.75pt .75pt .75pt .75pt'  color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/Track-Orders'><b><span style='font-size:  7.0pt;color:white;text-decoration:none;text-underline:none'>Track Orders </span></b></a><o:p></o:p></span></p>  </td>  <td width=120 style='width:1.0in;padding:.75pt 3.0pt .75pt .75pt'  color='#ffffff'>  <p class=MsoNormal align=right style='text-align:right'><span  style='font-family:Arial;mso-fareast-font-family:Arial'><a  href='http://www.techconfigured.com/Office-Hours'><b><span style='font-size:  7.0pt;color:white;text-decoration:none;text-underline:none'>Office Hours </span></b></a><o:p></o:p></span></p>  </td> </tr></table><p class=MsoNormal><span style='mso-fareast-font-family:Arial'><o:p>&nbsp;</o:p></span></p></div></body></html>");
            return sb.ToString();
        }

        private void SaveOrder()
        {
            var o = new Order();
            o.BillingAddress1 = _view.BillingAddress1;
            o.BillingAddress2 = _view.BillingAddress2;
            o.BillingCity = _view.BillingCity;
            o.BillingCompany = _view.BillingCompany;
            o.BillingFirstName = _view.BillingFirstName;
            o.BillingLastName = _view.BillingLastName;
            o.BillingPhone = _view.BillingPhone;
            o.BillingState = _view.BillingState;
            o.BillingZip = _view.BillingZip;
            if (SecurityContextManager.Current.CurrentCustomer != null && SecurityContextManager.Current.CurrentCustomer.ID > 0)
            {
                o.CustomerID = SecurityContextManager.Current.CurrentCustomer.ID;
            }
            o.DateCreated = DateTime.Now;
            o.CreditCardTypeID = 1;
            if (!string.IsNullOrEmpty(_view.ShippingEmail))
            {
                o.Email = _view.ShippingEmail;
            }
            else
            {
                o.Email = _view.BillingEmail;
            }
            o.IsShoppingCart = false;
            o.LastUpdated = DateTime.Now;
            o.OrderStatusID = (int)OrderStatus.OPEN;
            o.OrderTotal = CalculateGrandTotal(true);
            if (!string.IsNullOrEmpty(_view.ShippingPhone))
            {
                o.Phone = _view.ShippingPhone;
            }
            else
            {
                o.Phone = _view.BillingPhone;
            }
            o.ShippingAddress1 = _view.ShippingAddress1;
            o.ShippingAddress2 = _view.ShippingAddress2;
            o.ShippingCity = _view.ShippingCity;
            o.ShippingCompany = _view.ShippingCompany;
            o.ShippingCost = CalculateShipping();
            o.ShippingFirstName = _view.ShippingFirstName;
            o.ShippingLastName = _view.ShippingLastName;
            o.ShippingPhone = _view.ShippingPhone;
            o.ShippingState = _view.ShipToState;
            o.ShippingZip = _view.ShipToZip;
            o.SubTotal = CalculateSubtotal();
            o.Tax = CalculateTax();
            new OrderServices().Save(o);
            foreach (var item in SecurityContextManager.Current.CurrentShoppingCart.CartItems)
            {
                var i = new OrderItem();
                i.OrderID = o.ID;
                i.Price = item.Price;
                i.ProductID = item.ProductID;
                i.Qty = item.Qty;
                new OrderItemServices().Save(i);
            }
            orderSaved = true;
            if (ProcessOrder(o))
            {

                _view.ShowConfirmation = true;
                _view.PurchaseEnabled = false;
                _view.UpdateShippingEnabled = false;
                SendConfirmation();
            }
            else
            {
                _view.ShowConfirmation = true;
            }
        }

        private bool ProcessOrder(Order order)
        {
            bool retval = false;
            TransactionRequestInfo request = new TransactionRequestInfo();
            request.DelimitedDataResponse = "TRUE";
            request.RelayResponse = "FALSE";
            request.DelimiterCharacter = "|";
            request.FirstName = _view.BillingFirstName.Trim();
            request.LastName = _view.BillingLastName.Trim();
            request.Address = _view.BillingAddress1.Trim();
            request.City = _view.BillingCity.Trim();
            request.State = _view.BillingState.Trim();
            request.Zip = _view.BillingZip.Trim();
            request.Country = ConfigurationManager.AppSettings["DEFAULT_BILLING_COUNTRY"];
            request.CreditCardNumber = _view.CreditCardNumber.Trim();
            request.CreditCardExpirationDate = _view.CreditCardExpirationDate;
            request.TransactionMethodOfPayment = TransactionRequestInfo.MethodOfPayment.CC.ToString();
            request.CreditCardTransactionType = TransactionRequestInfo.TransactionType.AUTH_CAPTURE.ToString();
            request.TestRequest = ConfigurationManager.AppSettings["AUTHORIZENETTESTMODE"];
            request.Email = _view.BillingEmail;
            request.Phone = _view.BillingPhone;
            request.TotalAmount = order.OrderTotal.ToString();
            request.Description = "Online purchase ran at: " + DateTime.Now.ToString();
            request.CreditCardCodeNumber = _view.CreditCardCodeNumber;
            var response = new TransactionResponseInfo();
            response = Transaction.ProcessPayment(request);
            if (response.ResponseCode.Equals("1"))
            {
                retval = true;
                var log = new ApplicationLog();
                log.ApplicationLogTypeID = (int)ApplicationLogType.SUCCESSFUL_TRANSACTION;
                log.Description = request.RelayResponse + "<br /><br />RESPONSE Code: " + response.ResponseCode + "<br /> Response Code Reason: " + response.ResponseReasonCode + "<br /> Response Text: " + response.ResponseReasonText + "<br />Sub Code: " + response.ResponseSubCode;
                log.LogDate = DateTime.Now;
                if (SecurityContextManager.Current.CurrentCustomer != null && SecurityContextManager.Current.CurrentCustomer.ID > 0)
                {
                    log.UserInfo = "Customer ID: " +
                        SecurityContextManager.Current.CurrentCustomer.ID.ToString() + "<br />" +
                        SecurityContextManager.Current.CurrentCustomer.FirstName + " " +
                        SecurityContextManager.Current.CurrentCustomer.LastName;
                }
                else
                {
                    log.UserInfo = _view.BillingFirstName + " " + _view.BillingLastName;
                }
                new ApplicationLogServices().Save(log);

                if (order != null && order.ID > 0)
                {
                    order.OrderStatusID = (int)OrderStatus.PROCESSED;
                    new OrderServices().Save(order);
                    retval = true;
                }
                _view.Message = "Thank you for your purchase!  A confirmation of your order has been sent to the email addresses provided above.  If you have any problems or question please call us toll free at 800-555-5555.";
                return retval;
            }
            else
            {
                _view.Message = response.Description;
                _view.Message += "<br />" + response.CardCodeResponse;
                _view.Message += "<br />" + response.ResponseCode;
                _view.Message += "<br />" + response.ResponseReasonText;
                _view.Message += "<br />" + response.AuthorizationCode;
                _view.Message += "<br /><br />Please call to complete your order at: 800.555.5555";
                
                var log = new ApplicationLog();
                log.ApplicationLogTypeID = (int)ApplicationLogType.PROCESSING_ORDER_EXCEPTION;
                log.Description = request.RelayResponse + "<br /><br />RESPONSE Code: " + response.ResponseCode + "<br /> Response Code Reason: " + response.ResponseReasonCode + "<br /> Response Text: " + response.ResponseReasonText + "<br />Sub Code: " + response.ResponseSubCode;
                log.LogDate = DateTime.Now;
                if (SecurityContextManager.Current.CurrentCustomer != null && SecurityContextManager.Current.CurrentCustomer.ID > 0)
                {
                    log.UserInfo = "Customer ID: " +
                        SecurityContextManager.Current.CurrentCustomer.ID.ToString() + "<br />" +
                        SecurityContextManager.Current.CurrentCustomer.FirstName + " " +
                        SecurityContextManager.Current.CurrentCustomer.LastName;
                }
                else
                {
                    log.UserInfo = _view.BillingFirstName + " " + _view.BillingLastName;
                }
                return retval;
            }
        }
    }
}

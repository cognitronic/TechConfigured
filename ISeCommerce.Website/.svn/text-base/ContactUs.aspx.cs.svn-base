using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ISeCommerce.Core.Security;
using System.Text;

namespace ISeCommerce.Website
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divError.Visible = false;

        }

        protected void SendClicked(object o, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append(EmailHTMLStart());
            sb.Append("<div style='margin-bottom: 150px; margin-top: 50'>");
            sb.Append("<b>Name:</b>&nbsp;");
            sb.Append(tbName.Text);
            sb.Append("<br /><br />");
            sb.Append("<b>Email:</b>&nbsp;");
            sb.Append(tbEmail.Text);
            sb.Append("<br /><br />");
            sb.Append("<b>Phone:</b>&nbsp;");
            sb.Append(tbPhone.Text);
            sb.Append("<br /><br />");
            sb.Append("<b>Message:</b>&nbsp;");
            sb.Append(tbMessage.Text);
            sb.Append("<br /><br />");
            sb.Append("</div>");
            sb.Append(EmailHTMLEnd());

            var success = IdeaSeed.Core.Mail.EmailUtils.SendEmail("dschreiber@mydatapath.com,cognitronic@gmail.com," + tbEmail.Text, "eCommerceInfo@mydatapath.com", "", "", "Customer Inquiry", sb.ToString(), true, "");

            if (success)
            {
                divSuccess.Visible = true;
            }
            else
            {
                divError.Visible = true;
            }
        }

        private string EmailHTMLStart()
        {
            string cssstyle = @"<style>td a{font-family: arial;color: #333;font-size: 12px;}td{font-family: arial;color: #0f6ca1;padding: 5px 10px;}table{padding: 10px;} body{font-family: arial;color: #333;font-size: 14px;} </style>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title> Order Confirmation </title>");
            sb.Append(cssstyle);
            sb.Append("</head>");
            sb.Append("<BODY>  <div><a href='http://www.techconfigured.com/'><img border=0  width=375 height=70 src='http://www.techconfigured.com/images/logo.png'  alt='http://www.techconfigured.com/images/logo.png'></a>  </div>  <hr />");
            return sb.ToString();
        }

        private string EmailHTMLEnd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<hr />  <table width='100%'><tr><td>Product Categories</td><td>Tools & Resources</td><td>Customer Services</td></tr><tr><td><a href='http://www.techconfigured.com/Networking'>Networking</a></td><td><a href='http://www.techconfigured.com/Return-Policy'>Return Policy</a></td><td><a href='http://www.techconfigured.com/About-Us'>About Us</a></td></tr><tr><td><a href='http://www.techconfigured.com/Cables'>Cables</a></td><td><a href='http://www.techconfigured.com/Privacy-Policy'>Privacy Policy</a></td><td><a href='http://www.techconfigured.com/Contact-Us'>Contact Us</a></td></tr><tr><td><a href='http://www.techconfigured.com/Computers'>Computers</a></td><td><a href='http://www.techconfigured.com/Security-Policy'>Security Policy</a></td><td><a href='http://www.techconfigured.com/Shipping-Policy'>Shipping Policy</a></td></tr><tr><td><a href='http://www.techconfigured.com/Computer-Hardware'>Computer Hardware</a></td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td><a href='http://www.techconfigured.com/Software'>Software</a></td><td>&nbsp;</td><td>&nbsp;</td></tr>  </table> </BODY></HTML>");
            return sb.ToString();
        }
    }
}
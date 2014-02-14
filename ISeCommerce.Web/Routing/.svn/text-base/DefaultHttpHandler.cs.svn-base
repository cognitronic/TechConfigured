using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.SessionState;

namespace ISeCommerce.Web.Routing
{
    public class DefaultHttpHandler : IHttpHandler, IRequiresSessionState
    {
        internal readonly IHttpHandler OriginalHandler;


        public DefaultHttpHandler(IHttpHandler originalHandler)
        {
            OriginalHandler = originalHandler;
        }


        public void ProcessRequest(HttpContext context)
        {         // do not worry, ProcessRequest() will not be called, but let's be safe         
            throw new InvalidOperationException("MyHttpHandler cannot process requests.");
        }


        public bool IsReusable
        {         // IsReusable must be set to false since class has a member!         
            get { return false; }
        }
    }
}

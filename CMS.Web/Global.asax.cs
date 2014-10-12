using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 讓Web API只回傳JSON格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpCookie cLang = Request.Cookies["Lang"];

            if (cLang != null)
            {

                System.Threading.Thread.CurrentThread.CurrentCulture
                    = new System.Globalization.CultureInfo(cLang.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture
                    = new System.Globalization.CultureInfo(cLang.Value);
            }
            else
            {
                // 如果判斷不出來，預設就改為簡體中文網站吧
                cLang = new HttpCookie("Lang");
                cLang.Value = "zh-CN";
                System.Threading.Thread.CurrentThread.CurrentCulture
                   = new System.Globalization.CultureInfo(cLang.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture
                    = new System.Globalization.CultureInfo(cLang.Value);
            }
        }

    }
}

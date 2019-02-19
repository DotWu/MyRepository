using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TE.AspDotNetMvc
{
    //注意：有关启用IIS6或IIS7经典模式的说明
    //请访问：http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 在系统启动时调用的方法
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();   //注册APS.NET-MVC应用程序中的所有区域

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);  //全局过滤器

            RouteConfig.RegisterRoutes(RouteTable.Routes);   //注册路由

            BundleConfig.RegisterBundles(BundleTable.Bundles);  //用于绑定CS和JS
        }
    }
}

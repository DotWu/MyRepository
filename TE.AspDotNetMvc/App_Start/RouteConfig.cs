using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TE.AspDotNetMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            //测试{table}/Deails.apsx
            routes.MapRoute(
               name: "Test9",
               url: "{table}/Deails.aspx",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
           );

            //测试{name}-{age}   会以其他路由起冲突，所以放到前面来
            routes.MapRoute(
              name: "Test4",
              url: "{name}-{age}",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Test1",
                url: "{first}/{second}/{third}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Test2",
             url: "blogs/{author}/{category}/{id}",
             defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Test3",
              url: "{subject}/{year}/{month}/{day}/{name}-{age}",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            //测试{action}/{year}/{month}/{day}/index.aspx
            routes.MapRoute(
              name: "Test5",
              url: "{year}/{month}/{day}/index.aspx",
              defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
              constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
            );
            //测试{action}/{year}/{month}/{day}/index.aspx
            routes.MapRoute(
              name: "Test15",
              url: "{aa}/{year}/{month}/{day}/index.aspx",
              defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
              constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
            );

            //测试{year}/{month}/{day}/Details.aspx
            routes.MapRoute(
              name: "Test6",
              url: "{year}/{month}/{day}/Details",
              defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
              constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
            );
            //测试包含一个action的url
            routes.MapRoute(
              name: "Test7",
              url: "{action}/{author}/{year}/{month}/{day}",
              defaults: new { controller = "Home", action = "About" }
            );

            //测试包含一个controller的url
            routes.MapRoute(
              name: "Test8",
              url: "{author}/{year}/{month}/{controller}",
              defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            //测试{table}/Deails.apsx  放这会出错
           // routes.MapRoute(
           //    name: "Test9",
           //    url: "{table}/Deails.apsx",
           //    defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
           //);
        }
    }
}

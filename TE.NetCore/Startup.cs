using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TE.NetCore.Data;
using TE.NetCore.Models;
using TE.NetCore.Services;

namespace TE.NetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");
            Configuration = configuration;
        }
        public IConfiguration Configuration { get;  }
 
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireLowercase = false;//需要小写
            //    options.Password.RequireNonAlphanumeric = false;//需要字母
            //    options.Password.RequireUppercase = false;//需要大写
            //    //User settings
            //    options.User.RequireUniqueEmail = true;
            //});

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.LoginPath = "/Account/Login"; });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    //Cookies settings
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromDays(150);
            //    //If the LoginPath isn't set,ASP.NET Core defaults
            //    //the path to  /Account/Login.
            //    options.LoginPath = "/Account/Login";
            //    //If the AccessDeniedPath isn't set,ASP.NET Core defaults
            //    //the path to  /Account /AccessDenied.
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});


            //services.AddEntityFrameworkSqlite().AddDbContext<HelpDBContext>(options => options.UseSqlite(Configuration["database:connection"]));


            services.AddDbContext<Models.HelpDBContext>(options => options.UseSqlServer("Data Source=123.207.1.223,55972;Initial Catalog=kongheydb;User ID=konghey;Password=konghey518")); //在Startup类中配置数据库连接
            //services.AddEntityFrameworkSqlite().AddDbContext<HelpDBContext>();  //在HelpDBContext类中配置数据库连接


            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<HelpDBContext>();//配置Identity框架


            services.AddTransient<Sys_User>();
            //Add appliction services.
            services.AddTransient<IEmailSender, EmailSender>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();   //相当于中间件UseDefaultFiles和UseStaticFiles
            //app.UseAuthentication();  //配置Identity中间件

            app.UseMvc(ConfigureRoute);  //配置MVC中间件路由
            //app.UseMvcWithDefaultRoute();  ///默认路由
            //app.UseWelcomePage();
            //app.UseDefaultFiles();    //寻找文件下的默认文件
            //app.UseStaticFiles();     //寻找文件下的静态文件
            //app.Run(async (context) =>
            //{
            //    //throw new System.Exception("Throw Exception");
            //    var msg = Configuration["message"];
            //    await context.Response.WriteAsync(msg);
            //});
        }
        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

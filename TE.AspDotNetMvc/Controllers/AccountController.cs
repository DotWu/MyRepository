using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TE.Models;
using TE.Services;

namespace TE.AspDotNetMvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string loginName,string password)
        {
            if (string.IsNullOrEmpty(loginName) && string.IsNullOrEmpty(password))
                return View();

            //获取数据
            Sys_User sysUser = new Sys_User()
            {
                UserID = loginName,
                PassWord=password
            };
            //业务处理
            sysUser =new SysUserService().CheckUserLogin(sysUser);

            if (sysUser != null)
            {
                ViewBag.info = $"欢迎您：{sysUser.UserName}";
            }
            else
            {
                ViewBag.info = $"用户信息有误";
            }

            //返回视图
            return View();
        }
    }
}
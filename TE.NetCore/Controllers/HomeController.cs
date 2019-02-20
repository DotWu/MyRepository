using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TE.NetCore.Models;

namespace TE.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelpDBContext _context;

        public HomeController(HelpDBContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            SQLEmployeeDate sqlData = new SQLEmployeeDate(_context);
            model.sys_User = sqlData.GetAll();
            return View(model);
        }
        #region
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ViewResult Detail(int Id)
        {
            SQLEmployeeDate sqlData = new SQLEmployeeDate(_context);
            var sys_u = sqlData.Get(Id);
            return View(sys_u);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            SQLEmployeeDate sqlData = new SQLEmployeeDate(_context);
            var sys_u = sqlData.Get(Id);
            if (sys_u == null)
            {
                return RedirectToAction("Index");
            }
            return View(sys_u);
        }
        [HttpPost]
        public IActionResult Edit(int Id, sys_UserEditViewModel input)
        {
            SQLEmployeeDate sqlData = new SQLEmployeeDate(_context);
            var sys_u = sqlData.Get(Id);
            if (sys_u != null && ModelState.IsValid)
            {
                sys_u.UserName = input.UserName;
                _context.SaveChanges();
                return RedirectToAction("Detail", new { Id = sys_u.Id });
            }
            return View(sys_u);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(sys_UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sys_u = new Sys_User();
                sys_u.UserName = model.UserName;
                sys_u.UserId = model.UserId;
                sys_u.PassWord = model.PassWord;
                sys_u.Sex = model.Sex;
                sys_u.UserType = 1;
                sys_u.IsEnable = 1;
                sys_u.LoginTimes = 0;
                sys_u.AddOn = DateTime.Now;
                sys_u.AddBy = "caohui";
                sys_u.GlobalPageSize = 10;
                SQLEmployeeDate sqlData = new SQLEmployeeDate(_context);
                sqlData.Add(sys_u);
                return RedirectToAction("Detail", new { id = sys_u.Id });
            }
            return View();
        }
        #endregion
        public ViewResult DeclaredData()
        {
            var model = new VM_DeclaredData();
            //DeclaredDataService ds = new DeclaredDataService(_context);
            return View();
        }
    }

    #region   //Sys_User
    public class SQLEmployeeDate
    {
        private HelpDBContext _context { get; set; }

        public SQLEmployeeDate(HelpDBContext context)
        {
            _context = context;
        }
        public void Add(Sys_User sys_User)
        {
            _context.Add(sys_User);
            _context.SaveChanges();
        }

        public Sys_User Get(int Id)
        {
            return _context.sys_User.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Sys_User> GetAll()
        {
            return _context.sys_User.ToList<Sys_User>();
        }

    }
    public class HomePageViewModel
    {
        public IEnumerable<Sys_User> sys_User { get; set; }
    }
    public class sys_UserEditViewModel
    {
        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(40)]
        public string UserId { get; set; }

        [Required, MaxLength(40)]
        public string PassWord { get; set; }
        
        public int Sex { get; set; }
    }
    #endregion

    #region
    public class SQLDeclaredData
    {
    }
    public class VM_DeclaredData
    {
        /// <summary>
        /// 累计出借人数
        /// </summary>
        public int Lenders { get; set; }
        /// <summary>
        /// 当前出借人数
        /// </summary>
        public int Lender { get; set; }

    }
    #endregion
}

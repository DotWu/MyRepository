using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TE.NetCore.Controllers
{
    public class AboutController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult WebOne()
        {
            return View();
        }
        public ViewResult JQueryUI()
        {
            return View();
        }
        public ViewResult Backbone()
        {
            return View();
        }
    }
}

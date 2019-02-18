using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TE.NetCore.Controllers
{
    public class WebFrameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult AngularJS()
        {
            return View();
        }
        public ViewResult ReactJS()
        {
            return View();
        }
        public ViewResult VueJS()
        {
            return View();
        }
        public ViewResult Bootstrap(string name,string url)
        {
            return View();
        }
    }
}
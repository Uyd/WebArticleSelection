using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ArticleSelection.Controllers
{
    public class SelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(int a,int b)
        {
            ViewBag.A = a;
            ViewBag.B = b;
            
            return View();
        }
        //public IActionResult Welcome()
        //{
        //    var tx1 = HttpContext.GetRouteValue("Conteroller");
        //    var tx2 = HttpContext.GetRouteValue("Action");
        //    return View();
        //}
    }
}
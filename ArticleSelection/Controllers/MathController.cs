using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleSelection.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArticleSelection.Controllers
{
    public class MathController : Controller
    {
        //public IActionResult add(int left, int right)
        //{
        //    var value = left + right;
        //    ViewBag.Value = value;
        //    return View();
        //}
        public IActionResult add([FromQuery] MathInput input)
        {
            //验证失败
            if (!ModelState.IsValid)
                return Content(string.Join("\r\n", ModelState.Values.SelectMany
                    (t => t.Errors.Select(x => x.ErrorMessage))));

            ViewBag.Value = input.Left + input.Right;
            return View(input);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DanielWambura.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Bio()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Kimenyithia kia gikuu kia Daniel Wambura.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Donate()
        {
            ViewData["Message"] = "Help bid Mwalimu Mburu the best farewell.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

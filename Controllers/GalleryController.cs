using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DanielWambura.Controllers
{
    //[Authorize]
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Gallery.";

            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}

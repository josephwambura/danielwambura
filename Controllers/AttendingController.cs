using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DanielWambura.Controllers
{
    [Authorize]
    public class AttendingController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Attendance confirmation.";

            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}

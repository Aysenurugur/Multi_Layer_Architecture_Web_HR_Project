using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Companies()
        {
            return View();
        }

        public IActionResult EditCompany()
        {
            return View();
        }

        public IActionResult Describing()
        {
            return View();
        }
    }
}

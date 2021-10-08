using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
    public class GuessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult CommentDetail()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}

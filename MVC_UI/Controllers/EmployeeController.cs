using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult DayOffs()
        {
            return View();
        }

        public IActionResult Debits()
        {
            return View();
        }

        public IActionResult Expanses()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}

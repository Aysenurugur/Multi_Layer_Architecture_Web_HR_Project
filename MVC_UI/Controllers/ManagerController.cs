using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult DayOffs()
        {
            return View();
        }

        public IActionResult ShiftBreak()
        {
            return View();
        }

        public IActionResult AssignShiftBreak()
        {
            return View();
        }

        public IActionResult Comment()
        {
            return View();
        }

        public IActionResult EditEmployee()
        {
            return View();
        }

        public IActionResult EmployeeRequests()
        {
            return View();
        }

        public IActionResult EmployeeDebits()
        {
            return View();
        }

        public IActionResult EmployeeBonuses()
        {
            return View();
        }

        public IActionResult EmployeeFiles()
        {
            return View();
        }

        public IActionResult EmployeeShiftBreak()
        {
            return View();
        }
    }
}

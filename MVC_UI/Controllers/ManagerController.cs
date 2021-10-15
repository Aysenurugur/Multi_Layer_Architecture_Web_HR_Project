using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index(Guid id)
        {
            ViewBag.CompanyId = id;
            HttpContext.Session.SetString("id",id.ToString());
            return View();
        }

        public IActionResult Employees(Guid id)
        {
            return View();
        }

        public IActionResult Settings(Guid id)
        {
            return View();
        }

        public IActionResult DayOffs(Guid id)
        {
            return View();
        }

        public IActionResult ShiftBreak(Guid id)
        {
            return View();
        }

        public IActionResult AssignShiftBreak(Guid id)
        {
            return View();
        }

        public IActionResult Comment(Guid id)
        {
            return View();
        }

        public IActionResult EditEmployee(Guid id)
        {
            HttpContext.Session.SetString("employeeId", id.ToString());
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

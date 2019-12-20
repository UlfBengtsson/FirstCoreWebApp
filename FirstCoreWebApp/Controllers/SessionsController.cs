using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;    // Need to use Session GetString
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebApp.Controllers
{
    public class SessionsController : Controller
    {
        public IActionResult LookAt()
        {
            ViewBag.Msg = HttpContext.Session.GetString("KeyName");
            return View();
        }

        public IActionResult SaveSession(string message)
        {
            HttpContext.Session.SetString("KeyName", message);

            return RedirectToAction("LookAt");
        }
    }
}
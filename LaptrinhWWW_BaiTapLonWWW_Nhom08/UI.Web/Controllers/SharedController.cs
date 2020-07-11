using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class SharedController : Controller
    {
        public static int Role;
        public static string Email;
        public static string UserName;
        // GET: Shared
        public SharedController()
        {
            Role = 0;
            Email = "";
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Layout()
        {
            ViewBag.Role = Role;
            return View();
        }
    }
}
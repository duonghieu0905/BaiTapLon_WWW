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
        // GET: Shared
        public SharedController()
        {
            Role = 0;
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
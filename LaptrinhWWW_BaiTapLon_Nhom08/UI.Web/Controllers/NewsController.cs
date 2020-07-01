using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
namespace UI.Web.Controllers
{
   
    public class NewsController : Controller
    {
        Services.NewspaperService ser = new NewspaperService();
        // GET: News
        public ActionResult Index(int id)
        {
           
            return View();
        }
        public ActionResult GetView()
        {
          
            return View();
        }
    }
}
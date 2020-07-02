using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
using EntityFrameworks.Model;
namespace UI.Web.Controllers
{
   
    public class NewsController : Controller
    {
        
        // GET: News
        public ActionResult Index(int id)
        {
           
            return View();
        }
        public ActionResult GetView()
        {
          
            return View();
        }
        //Get
        public ActionResult CreateNews()
        {
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult CreateNews(Newspaper news)
        {
            NewspaperService ser = new NewspaperService();
            news.Active =0;
            news.PublicationDate = DateTime.Now;
            ser.AddNewspaper(news);
            return RedirectToAction("CreateNews");
        }
        [HttpPost]
        public ActionResult GetNewsByTitle(int id)
        {
            return View();
        }
    }
}
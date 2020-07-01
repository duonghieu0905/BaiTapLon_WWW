using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        NewspaperService serNews = new NewspaperService();
        public ActionResult Index()
        {
            var list = serNews.GetAll();
            List<eNewspaper> lst = new List<eNewspaper>();
            foreach (var item in list)
            {
                lst.Add(new eNewspaper() { Active = item.Active, Description = item.Description, Image = item.Image, Journalist = item.Journalist, NewsId = item.NewsId, PublicationDate = (DateTime)item.PublicationDate, Title = item.Title });
            }
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
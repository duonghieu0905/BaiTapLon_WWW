using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using EntityFrameworks.Model;
using Services;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {

        MappingService sermap = new MappingService();
        NewspaperService serNews = new NewspaperService();
        TopicService sertop = new TopicService();

        public ActionResult Index(string SearchString)
        {

            ViewBag.Right = serNews.GetAll().Take(4);
            ViewBag.Top = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(1);
            ViewBag.Bot = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(3);
            ViewBag.Topic = sertop.GetAll();
            ViewBag.GetAllBao = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(4);
            if ((AccountLogin)Session["account"] != null)
            { 
                var account = (AccountLogin)Session["account"]; 
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewBag.Right = serNews.GetAll().Take(4).Where(x => x.Title.ToLower().Contains(SearchString.ToLower()) || x.Description.ToLower().Contains(SearchString.ToLower())).ToList();
                ViewBag.Top = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(1).Where(x => x.Title.ToLower().Contains(SearchString.ToLower()) || x.Description.ToLower().Contains(SearchString.ToLower())).ToList();
                ViewBag.Bot = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(3).Where(x => x.Title.ToLower().Contains(SearchString.ToLower()) || x.Description.ToLower().Contains(SearchString.ToLower())).ToList();
                ViewBag.Topic = sertop.GetAll();
                ViewBag.GetAllBao = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(4).Where(x => x.Title.ToLower().Contains(SearchString.ToLower()) || x.Description.ToLower().Contains(SearchString.ToLower())).ToList();
            }
            var list = serNews.GetAll();
            List<eNewspaper> lst = new List<eNewspaper>();
            foreach (var item in list)
            {
                //lst.Add(new eNewspaper() { Active = item.Active, Description = item.Description, Image = item.Image, Journalist = item.Journalist, NewsId = item.NewsId, PublicationDate = (DateTime)item.PublicationDate, Title = item.Title });
            }
            return View(lst);
        }

        public JsonResult getNew(int id)
        {

            var query = (from tp in sertop.GetAll()
                         join
map in sermap.GetAll() on tp.TopicId equals map.TopicId
                         join
news in serNews.GetAll() on map.NewsId equals news.NewsId
                         where tp.TopicId == id
                         select new
                         {
                             news.Image,
                             news.Title,
                             tp.TopicName,
                             news.NewsId

                         }).ToList();
            ViewBag.getbaotheoIDTopic = query;

            return Json(query, JsonRequestBehavior.AllowGet);
        }

    }
}
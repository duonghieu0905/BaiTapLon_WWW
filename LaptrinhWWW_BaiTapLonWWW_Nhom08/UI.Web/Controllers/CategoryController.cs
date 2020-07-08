using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            TopicService sertop = new TopicService();
            List<eTopic> lst = new List<eTopic>();
            List<eNewspaper> listbao = new List<eNewspaper>();
            NewspaperService serbao = new NewspaperService();
            foreach (var item in serbao.GetAll())
            {
                listbao.Add(new eNewspaper()
                {
                    Title = item.Title,
                    Active = item.Active,
                    Description = item.Description,
                    Image = item.Image,
                    Journalist = item.Journalist,
                    NewsId = item.NewsId,
                    PublicationDate = (DateTime)item.PublicationDate
                });
            }
            ViewBag.ALlBao = listbao;
            foreach (var item in sertop.GetAll())
            {
                eTopic top = new eTopic() { TopicId = item.TopicId, TopicName = item.TopicName };
                lst.Add(top);
            }
            return View(lst);
        }
        public JsonResult getNew(int id)
        {
            TopicService sertop = new TopicService();
            MappingService sermap = new MappingService();
            NewspaperService sernews = new NewspaperService();
            if (id == 0)
            {
                return Json(sernews.GetAll(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var query = (from tp in sertop.GetAll()
                             join
    map in sermap.GetAll() on tp.TopicId equals map.TopicId
                             join
    news in sernews.GetAll() on map.NewsId equals news.NewsId
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
}
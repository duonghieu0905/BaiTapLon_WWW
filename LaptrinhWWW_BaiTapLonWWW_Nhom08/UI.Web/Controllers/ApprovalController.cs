using EntityFrameworks.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class ApprovalController : Controller
    {
        private NewspaperService _newspaperService;
        public ApprovalController()
        {
            _newspaperService = new NewspaperService();
        }
        // GET: Approval
        public ActionResult Index()
        {
            var listNews = _newspaperService.GetAll().Where(x => x.Active == 0).ToList();
            return View(listNews);
        }
        [HttpGet]
        public ActionResult ReviewNews(int id)
        {
            var news = _newspaperService.GetById(id);
            if (news != null)
                return View(news);
            return View("Index");
        }
        [HttpGet]
        public ActionResult ReviewNews(Newspaper newspaper)
        {

            return View();
        }
        public ActionResult ApprovalNews(int id)
        {
            var news = _newspaperService.GetById(id);
            if (news != null)
            {
                news.Active = 1;
                var newsupdate = _newspaperService.UpdateNewspaper(news);
                if (newsupdate.Active == 1)
                {

                    //success
                    return RedirectToAction("Index", "Approval");
                }
                else
                {
                    //Fail
                }
            }
            else
            {
                //Null
            }
                
            return View("Index");
        }
    }
}
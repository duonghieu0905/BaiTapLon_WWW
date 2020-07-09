using EntityFrameworks.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class JournalistController : Controller
    {

        private NewspaperService _newsService;
        private UserService _userService;
        private AccountService _accountService;
        public JournalistController()
        {
            _newsService = new NewspaperService();
            _userService = new UserService();
            _accountService = new AccountService();
        }
        // GET: Journalist
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetAllNews(int id)
        {
           
            var listNews = (from us in _userService.GetAll()
                            join acc in _accountService.GetAll() on us.UserId equals acc.UserId
                            join
news in _newsService.GetAll() on acc.AccountName equals news.Journalist
                            where (us.UserId == id)
                            select new
                            {
                                newid = news.NewsId,
                                day = Convert.ToDateTime(news.PublicationDate),
                                image = news.Image,
                                title = news.Title,
                                active = news.Active,
                                description = news.Description

                            }).ToList();
            return Json(listNews, JsonRequestBehavior.AllowGet);
        }
    }
}
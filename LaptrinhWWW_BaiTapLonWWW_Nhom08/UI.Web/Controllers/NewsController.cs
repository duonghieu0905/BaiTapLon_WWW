using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
using EntityFrameworks.Model;
using UI.Web.Models;

namespace UI.Web.Controllers
{
   
    public class NewsController : Controller
    {
        private CommentService _commentService;
        public NewsController()
        {
            _commentService = new CommentService();
        }
        // GET: News
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetView()
        {
          
            return View();
        }
        //Get
        
        [HttpPost]
        public ActionResult GetNewsByTitle()
        {
            return View();
        }
        public ActionResult CreateNews()
        {
            if (Session["account"] is null)
                return RedirectToAction("Login", "Login");
            else
            {
                TopicService sv = new TopicService();
                NewInfo s = new NewInfo();
                s.Topic = sv.GetAll().ToList();
                return View(s);
            }
            
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult CreateNews(NewInfo info,FormCollection f)
        {
            if (Session["account"] is null)
                return RedirectToAction("Login", "Login");
            else
            {
                var account = Session["account"] as Account;
                var listtopic = f["topicstring"].ToString().Split(new char[] { ',' });
                Newspaper news = new Newspaper();
                NewspaperService svn = new NewspaperService();
                news.Active = 0;
                news.PublicationDate = DateTime.Now;
                news.Journalist = account.AccountName;
                news.Title = info.Title;
                news.Image = info.Image;
                news.Description = info.Description;
                svn.AddNewspaper(news);
                var result = svn.GetAll().Last();
                MappingService svm = new MappingService();
                foreach (var item in listtopic)
                {
                    svm.AddMapping(new Mapping { NewsId = result.NewsId, TopicId = Int32.Parse(item) });
                }
                return RedirectToAction("CreateNews");
            }
            
        }
        public ActionResult UpdateNews(int newsid=11)
        {
            if (Session["account"] is null)
                return RedirectToAction("Login", "Login");
            else
            {
                var account = Session["account"] as Account;
                NewspaperService svn = new NewspaperService();
                var result = svn.GetById(newsid);
                MappingService svm = new MappingService();
                var mapresult = svm.GetAll().Where(x => x.NewsId == result.NewsId).ToList();
                List<Topic> lsttopic = new List<Topic>();
                TopicService svt = new TopicService();
                foreach (var item in mapresult)
                {
                    lsttopic.Add(svt.GetById(item.TopicId));
                }
                string str = "";
                foreach (var item in lsttopic)
                {
                    str += item.TopicId + ",";
                }
                str = str.Substring(0, str.Length - 1);

                ViewBag.GetTopic = str;
                NewInfo newinfo = new NewInfo();
                newinfo.Title = result.Title;
                newinfo.NewsId = result.NewsId;
                newinfo.Image = result.Image;
                newinfo.Journalist = account.AccountName;
                newinfo.Description = result.Description;
                newinfo.Topic = svt.GetAll().ToList();
                return View(newinfo);
            }
            
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateNews(NewInfo info, FormCollection f)
        {

            if (Session["account"] is null)
                return RedirectToAction("Login", "Login");
            else
            {
                var account = Session["account"] as Account;
                var listtopic = f["topicstring"].ToString().Split(new char[] { ',' });
                Newspaper news = new Newspaper();
                NewspaperService svn = new NewspaperService();
                news.PublicationDate = DateTime.Now;
                news.Active = 0;
                news.NewsId = info.NewsId;
                news.Title = info.Title;
                news.Image = info.Image;
                news.Description = info.Description;
                news.Journalist =account.AccountName;
                svn.UpdateNewspaper(news);
                MappingService svm = new MappingService();
                var getm = svm.GetAll().Where(x => x.NewsId == news.NewsId);
                var s = getm.ToList().Count;
                foreach (var item in getm.ToList())
                {
                    svm.DeleteMapping(item.MappingId);
                }
                foreach (var item in listtopic)
                {
                    svm.AddMapping(new Mapping { NewsId = info.NewsId, TopicId = Int32.Parse(item) });
                }
                return RedirectToAction("UpdateNews");
            } 
        }
        [ChildActionOnly]
        public ActionResult GetListComment(int newsid)
        {
            List<CommentViewModel> lst = new List<CommentViewModel>();
            CommentService sv = new CommentService();
            var result = sv.GetAll().Where(x => x.NewsId == newsid && x.Role == 0);
            ViewBag.NewID = newsid;
            foreach (var item in result)
            {
                lst.Add(new CommentViewModel { CommentId = item.CommentId, Description = item.Description, Image = item.Image, AccountName = item.AccountName });
            }
            foreach (var item in lst)
            {
                var resultsub = sv.GetAll().Where(x => x.NewsId == newsid && x.Role == item.CommentId).ToList();
                item.Comments = resultsub;
            }
            return PartialView(lst);
        }
        public ActionResult getComment(int id = 1)
        {
            var s = Json(_commentService.GetById(id), JsonRequestBehavior.AllowGet);
            return s;

        }
        [HttpPost]
        public ActionResult AddComment(Comment comment/*, HttpPostedFileBase uploadFile*/)
        {
            var fHinh = Request.Files["myFileImage"];
            if (fHinh != null)
            {
                var pathHinh = Server.MapPath("~/Images/Comments/" + fHinh.FileName);
                fHinh.SaveAs(pathHinh);
                comment.Image = fHinh.FileName;
            }
            else
                comment.Image = null;
            comment.Time = DateTime.Now;
            var cmt = _commentService.AddComment(comment);
            if (cmt != null)
                return RedirectToAction("DetailNews");
            return View();
        }



    }
}
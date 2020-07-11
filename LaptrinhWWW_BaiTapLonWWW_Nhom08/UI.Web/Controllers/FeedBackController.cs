using EntityFrameworks.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class FeedBackController : Controller
    {
        private FeedbackService _feedback;
        private AccountService _account;
        IEnumerable<Feedback> ListFeedBack;
        public FeedBackController()
        {
            _feedback = new FeedbackService();
            _account = new AccountService();
        }
        // GET: FeddBack
        public ActionResult Index()
        {
            ListFeedBack = _feedback.GetAll();
            //if (!String.IsNullOrEmpty(SearchString))
            //    ListFeedBack = ListFeedBack.Where(x => x.Email.Contains(SearchString));
            return View(ListFeedBack);
        }

        public ActionResult CreateFeedBack()
        {
            return View();
        }

        // POST: FeddBack/Create
        [HttpPost]
        public ActionResult CreateFeedBack(Feedback f)
        {
            try
            {
                if (Session["account"] == null)
                    f.AccountId = null;
                else
                {
                    var account = Session["account"] as AccountLogin;
                    f.AccountId = account.AccountName;
                    f.Time = DateTime.Now;
                    f.Email = account.Email;
                }
                if (_feedback.AddFeedback(f) != null)
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View("CreateFeedBack");
            }
            return View("CreateFeedBack");
        }
    }
}
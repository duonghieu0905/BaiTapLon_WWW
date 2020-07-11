﻿using EntityFrameworks.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class JournalistController : Controller
    {
        private NewspaperService _newsService;
        // GET: Journalist
        private UserService _userService;
        private AccountService _accountService;
        public JournalistController()
        {
            _newsService = new NewspaperService();
            _userService = new UserService();
            _accountService = new AccountService();
        }
        public ActionResult Index()
        {
            if (UI.Web.Controllers.SharedController.Role == 3)
            {
                var list = _userService.ListJournalist(2);
                return View(list);
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddJournalist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddJournalist(JournalistViewmodel journalist)
        {
            User user = new User();
            Account account = new Account();
            user.UserId = journalist.UserId;
            user.UserName = journalist.UserName;
            user.Email = journalist.Email;
            user.DateOfBirth = journalist.DateOfBirth;
            user.Gender = journalist.Gender;
            user.Role = 2;
            user.Phone = journalist.Phone;

            
            try
            {
                var temp = _userService.AddUser(user);
                if (temp != null)
                {
                    account.AccountName = journalist.AccountName;
                    account.Password = journalist.Password;
                    account.UserId = temp.UserId;
                    account.Active = 1;
                    var acc = _accountService.AddAccount(account);
                    if (acc != null)
                        return View("Index");
                }
            }catch(Exception)
            {
                return View("AddJournalist");
            }
            return View("AddJournalist");
        }

        public ActionResult Edit(int id)
        {
            User user = _userService.GetJournalist(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User s)
        {
            // List<User> users = new List<User>();
            // User temp = _userService.GetJournalist(s.UserId);
            if (s != null)
            {
                //temp.UserName = s.UserName;
                //temp.Email = s.Email;
                //temp.DateOfBirth = s.DateOfBirth;
                //temp.Gender = s.Gender;
                //temp.Role = 2;
                //temp.Phone = s.Phone;
                _userService.UpdateUser(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult DeleteJournalist(int id)
        {
            User s = _userService.GetJournalist(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }
        public ActionResult DeleteJournalistConfirm(int id)
        {
            User s = _userService.GetJournalist(id);
            _userService.DeleteUser(s);
            return RedirectToAction("Index");
        }


        public ActionResult JournalistDetails(int id)
        {
            User s = _userService.GetJournalist(id);
            Account account = _accountService.GetAccountByJournalist(s.UserId);
            JournalistViewmodel journalist = new JournalistViewmodel();
            journalist.UserId = s.UserId;
            journalist.UserName = s.UserName;
            journalist.Email = s.Email;
            journalist.DateOfBirth = s.DateOfBirth;
            journalist.Gender = s.Gender;
            journalist.Role = s.Role;
            journalist.Phone = s.Phone;

            journalist.AccountName = account.AccountName;
            journalist.Password = account.Password;
            journalist.Active = account.Active;
            if (s == null)
                return HttpNotFound();
            return View(journalist);
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
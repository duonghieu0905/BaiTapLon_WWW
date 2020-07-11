using EntityFrameworks.Model;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class LoginController : Controller
    {
        private UserService _userService;
        private AccountService _acccountService;
        public LoginController()
        {
            _userService = new UserService();
            _acccountService = new AccountService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login(string username, string password)
        {
            if (username != null || password != null)
            {
                var account = _acccountService.GetAll().FirstOrDefault(x => x.AccountName == username);
                if (account != null)
                {
                    if (account.Password == password)
                    {
                        var user = _userService.GetUserById(account.UserId);
                        if (user != null)
                        {
                            var accountLogin = new AccountLogin()
                            {
                                AccountName = account.AccountName,
                                Active = account.Active,
                                UserId = account.UserId,
                                Role = user.Role,
                                Email = user.Email
                            };
                            SharedController.Role = user.Role;
                            SharedController.Email = user.Email;
                            SharedController.UserName = account.AccountName;
                            //success
                            Session["account"] = accountLogin;
                            Response.Write("<script>alert('Login Success!');</script>"); //works great
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Sai Password');</script>"); //works great
                        return View();
                    }
                }
                else
                {
                    //Sai tên tài khoản
                    Response.Write("<script>alert('Không tìm thấy tài khoản');</script>"); //works great
                    return View();
                }
            }
            return View();
        }
        public ActionResult SignUp()
        {
            SharedController.Role = 0;
            SharedController.Email = "";
           Session["account"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            SharedController.Role = 0;
            SharedController.Email = "";
            SharedController.UserName = null;
            Session["account"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChangePass(string passold,string passnew)
        {
            if (passold != null && passnew != null)
            {
                if ((AccountLogin)Session["account"] != null)
                {
                    var account = (AccountLogin)Session["account"];
                    var accountchange = _acccountService.GetAll().FirstOrDefault(x => x.AccountName == account.AccountName);
                    if (accountchange.Password == passold)
                    {
                        accountchange.Password = passnew;
                        var model = _acccountService.UpdateAccount(accountchange);
                        if (model.Password != passold)
                        {
                            Session["account"] = null;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            Response.Write("<script>alert('Thay đổi password lỗi!');</script>"); //works great
                            return View();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Sai mật khẩu!');</script>"); //works great
                        return View();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Chưa login!');</script>"); //works great
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
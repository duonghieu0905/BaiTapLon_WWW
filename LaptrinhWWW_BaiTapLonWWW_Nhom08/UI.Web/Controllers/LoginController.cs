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

namespace UI.Web.Controllers
{
    public class LoginController : Controller
    {
        private AccountService _acccountService;
        public LoginController()
        {
            _acccountService = new AccountService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Login()
        //{
        //    return View();
        //}
        public ActionResult login(string username, string password)
        {
            if (username != null || password != null)
            {
                var account = _acccountService.GetAll().FirstOrDefault(x => x.AccountName == username);
                if (account != null)
                {
                    if (account.Password == password)
                    {
                        //success
                        var active = account.Active;
                        Response.Write("<script>alert('Login Success!');</script>"); //works great
                        return RedirectToAction("Index", "Home");
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
            return View();
        }
    }
}
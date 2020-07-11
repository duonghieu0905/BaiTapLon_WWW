using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class AccountLogin
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public int Active { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
    }
}
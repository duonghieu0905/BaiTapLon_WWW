using EntityFrameworks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class NewInfo
    {
        public int NewsId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Journalist { get; set; }
        public List<Topic> Topic { get; set; }
           
    }
}
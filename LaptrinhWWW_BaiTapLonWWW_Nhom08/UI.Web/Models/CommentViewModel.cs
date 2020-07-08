using EntityFrameworks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class CommentViewModel
    {
        public CommentViewModel() { }
        public CommentViewModel(Comment comment)
        {
            Comment = comment;
        }
        public IList<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }
        public int NewsId { get; set; }
        public string AccountName { get; set; }
        public int Active { get; set; }
    }
}
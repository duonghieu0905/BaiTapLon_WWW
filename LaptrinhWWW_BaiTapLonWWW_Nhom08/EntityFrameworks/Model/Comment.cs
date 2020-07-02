using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworks.Model
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime? Time { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }
        [ForeignKey("Newspaper")]
        public int NewsId { get; set; }
        [ForeignKey("Account")]
        public string AccountName { get; set; }
        public int Active { get; set; }
        public virtual Account Account { get; set; }
        public virtual Newspaper Newspaper { get; set; }
    }
}

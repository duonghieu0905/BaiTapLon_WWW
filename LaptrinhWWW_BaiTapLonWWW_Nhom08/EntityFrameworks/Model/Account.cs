using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworks.Model
{
    public class Account
    {
        [Key]
        public string AccountName { get; set; }
        public string Password { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int Active { get; set; }
        public virtual User User { get; set; }
        public virtual List<Newspaper> Newspapers { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}

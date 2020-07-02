using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworks.Model
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }

        public virtual Account Account { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworks.Model
{
    public class Newspaper
    {
        [Key]
        public int NewsId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        [ForeignKey("Account")]
        public string Journalist { get; set; }
        public int Active { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Mapping> Mappings { get; set; }
        
    }
}

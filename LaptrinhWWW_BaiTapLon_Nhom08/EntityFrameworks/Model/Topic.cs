using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworks.Model
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public virtual List<Mapping> Mappings { get; set; }
        
    }
}

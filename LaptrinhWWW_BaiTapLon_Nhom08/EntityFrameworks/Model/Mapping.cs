using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworks.Model
{
    public class Mapping
    {
        [Key]
        public int MappingId { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        [ForeignKey("Newspaper")]
        public int NewsId{ get; set; }
        public virtual Newspaper Newspaper { get; set; }
        public virtual Topic Topic { get; set; }
    }
}

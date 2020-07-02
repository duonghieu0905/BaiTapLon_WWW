using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eTopic
    {
        [Required(ErrorMessage ="Vui lòng không để trống mã chủ đề")]
        [Display(Name ="Mã chủ đề")]
        public int TopicId { get; set; }
        [Required(ErrorMessage = "Không để trống tên chủ đề")]
        [Display(Name = "Tên chủ đề")]
        public string TopicName { get; set; }
        
    }
}

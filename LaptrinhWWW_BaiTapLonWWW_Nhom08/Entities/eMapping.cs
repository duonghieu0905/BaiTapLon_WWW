using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eMapping
    {
        [Required(ErrorMessage = "Vui lòng không để trống mã chủ đề")]
        [Display(Name = "Mã Mapping")]
        public int MappingId { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống mã chủ đề")]
        [Display(Name = "Mã chủ đề")]
        public int TopicId { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống mã bài viết")]
        [Display(Name = "Mã bài viết")]
        public int NewsId{ get; set; }

    }
}

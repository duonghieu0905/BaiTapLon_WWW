using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eComment
    {
        [Required(ErrorMessage ="Vui lòng không để trống Mã bình luận")]
        [Display(Name ="Mã bình luận")]
        public int CommentId { get; set; }
        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "Vui lòng không để trống thời gian")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        [Display(Name = "Nội dung bình luận")]
        [Required(ErrorMessage = "Vui lòng không để trống nội dung bình luận")]
        public string Description { get; set; }
        [Display(Name = "Hình ảnh bình luận")]
        public string Image { get; set; }
        [Display(Name = "Vai trò")]
        public int Role { get; set; }
        [Display(Name = "Mã bài viết")]
        public int NewsId { get; set; }
        [Display(Name = "Người bình luận")]
        public string AccountName { get; set; }
        [Display(Name = "Trạng thái")]
        public int Active { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eNewspaper
    {
        [Required(ErrorMessage = "Vui lòng không để trống mã bài viết")]
        [Display(Name = "Mã bài viết")]
        public int NewsId { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống thời gian thời gian phát hành")]
        [Display(Name = "Thời gian phát hành")]
        [DataType(DataType.DateTime,ErrorMessage ="Vui lòng nhập đúng định dạng thời gian")]
        public DateTime PublicationDate { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống nội dung bài báo")]
        [Display(Name = "Nội dung")]
        public string Description { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống tiêu đề bài báo")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống nhà báo")]
        [Display(Name = "Nhà báo")]
        public string Journalist { get; set; }
        [Display(Name =("Trạng thái"))]
        [Required(ErrorMessage ="Vui lòng không để trống trạng thái")]
        public int Active { get; set; }

        
    }
}

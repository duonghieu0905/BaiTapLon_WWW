using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eFeedback
    {
        [Required(ErrorMessage = "Vui lòng không để trống mã phản hồi")]
        [Display(Name ="Mã phản hồi")]
        public int FeedbackId { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống nội dung phản hồi")]
        [Display(Name = "Nội dung phản hồi")]
        public string Description { get; set; }
        [Display(Name = "Người phản hồi")]
        public string AccountId { get; set; }
        [Display(Name = "Thời gian phản hồi")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

    }
}

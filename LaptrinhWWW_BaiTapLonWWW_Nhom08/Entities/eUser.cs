using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eUser
    {
        [Required(ErrorMessage ="Vui lòng không để trống mã thành viên")]
        [Display(Name = "Mã thành viên")]
        public int UserId { get; set; }
        [Display(Name = "Họ tên thành viên")]
        [Required(ErrorMessage = "Vui lòng không để trống tên thành viên")]
        [RegularExpression(@"^([A-Z][a-z]{1,7})(\s([A-Z][a-z]{1,7}){1,7})+$")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date, ErrorMessage ="Vui lòng nhập đúng định dạng ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Giới tính")]
        public int Gender { get; set; }
        [Display(Name = "Vai trò")]
        public int Role { get; set; }
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Vui lòng nhập đúng định dạng số điện thoại")]
        public string Phone { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworks.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="khong duoc bo trong")]
        [RegularExpression(@"^([A-Z][a-z]{1,7})(\s([A-Z][a-z]{1,7}){1,7})+$", ErrorMessage = "Vui lòng không để trống tên thành viên")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"^[1-3]$")]
        public int Gender { get; set; }
        [RegularExpression(@"^[1-3]$")]
        public int Role { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Vui lòng nhập đúng định dạng số điện thoại")]
        public string Phone { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class JournalistViewmodel
    {
       
        public int UserId { get; set; }
        [DisplayName("Tên nhà báo")]
        [RegularExpression(@"^([A-Z][a-z]{1,7})(\s([A-Z][a-z]{1,7}){1,7})+$", ErrorMessage = "Vui lòng không để trống tên thành viên")]
        public string UserName { get; set; }
        [DisplayName("Địa chỉ email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Năm sinh")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Giới tính")]
        public int Gender { get; set; }
        public int Role { get; set; }
        [DisplayName("Số điện thoại")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Vui lòng nhập đúng định dạng số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string AccountName { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        public int Active { get; set; }
    }
}
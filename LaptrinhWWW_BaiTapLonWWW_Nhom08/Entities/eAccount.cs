using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class eAccount
    {
        [Required(ErrorMessage = "Vui lòng không để trống Tên đăng nhập")]
        [RegularExpression(@"^([A-Z][a-z][0-9]){10,60}$",ErrorMessage ="Vui lòng nhập đúng định dạng . Tên đăng nhập chỉ chứa (A-Z)(a-z)(0-9). Từ 10 đến 50 kí tự")]
        [Display(Name ="Tên đăng nhập")]
        public string AccountName { get; set; }
        [Required(ErrorMessage ="Không để trống Mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Mã khách hàng")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public int Active { get; set; }
    }
}

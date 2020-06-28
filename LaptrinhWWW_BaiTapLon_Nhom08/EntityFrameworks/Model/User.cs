using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworks.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public string Phone { get; set; }
    }
}

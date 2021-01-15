using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.MVCSite.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [Required]
        [StringLength(50,MinimumLength =6)]
        [DataType(dataType:DataType.Password)]
        [Display(Name = "密码")]
        public string LoginPwd { get; set; }

        [Display(Name = "记住我")]
        public bool RemeberMe { get; set; }
    }
}
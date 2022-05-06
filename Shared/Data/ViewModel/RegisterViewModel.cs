using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public   class RegisterViewModel
    {
        [Required(ErrorMessage ="لطفا ایمیل را وارد نمائید .")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد نمائید .")]
        [StringLength(100, ErrorMessage = "رمز عبور نباید کمتر از {2} کاراکتر  باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "لطفا تکرار رمز عبور را درست وارد کنید")]
        public string ConfirmPassword { get; set; }
    }
}


using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{ 
    public class PersonDto : BaseEntityDto<int>
    {


        //*****************************************************************//
        [Display(Name = "نام ")]
        [MaxLength(100, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }
        //*****************************************************************//
        [Display(Name = "نام خانوادگی ")]
        [MaxLength(100, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string LastName { get; set; }
        //*****************************************************************//
        [Display(Name = "موبایل ")]
        [MaxLength(11, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Mobile { get; set; }
        //*****************************************************************//
        [Display(Name = "تلفن ")]
        [MaxLength(11, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Tellphone { get; set; }
        //*****************************************************************//
        [Display(Name = "آدرس ")]
        [DataType(DataType.MultilineText)]

        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Address { get; set; }
        //*****************************************************************//
        [Display(Name = "توضیح مختصر ")]
        [DataType(DataType.MultilineText)]

        [MaxLength(450, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }
        //*****************************************************************//
        [Display(Name = "توضیح کامل ")]
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }
        //*****************************************************************//
        [Display(Name = "تصویرآواتار ")]
        public IFormFile AvatarImage { get; set; }
        //*****************************************************************//
        [Display(Name = "ایکن ")]
        public IFormFile IconImage { get; set; }
        //*****************************************************************//
        [Display(Name = "ایمیل ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Email { get; set; }
        //*****************************************************************//
        [Display(Name = "واتس اپ ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string WhatsApp { get; set; }
        //*****************************************************************//
        [Display(Name = "تلگرام ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Telegram { get; set; }
        //*****************************************************************//
        [Display(Name = "اینستاگرام ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Instagram { get; set; }
        //*****************************************************************//
        [Display(Name = "لینکدین ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Linkdin { get; set; }
        //*****************************************************************//
        [Display(Name = "یوتوب ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Youtube { get; set; }
        //*****************************************************************//
        [Display(Name = "توضیح مختصر برای آموزش ")]
        [MaxLength(250, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]

        public string Learn { get; set; }

    }

}

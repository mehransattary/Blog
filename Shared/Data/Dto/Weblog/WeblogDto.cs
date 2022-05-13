using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Data.Dto
{
    public  class WeblogDto: BaseMetaTagDto
    {
        #region properties
        //***====================================================================================***//
        [Display(Name = "عنوان اول")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required]
        public string Weblog_Title_One { get; set; }
        //***====================================================================================***//
        [Display(Name = "عنوان دوم")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required]
        public string Weblog_Title_Two { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public IFormFile Weblog_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر کوچک")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public IFormFile Weblog_Thumbnail_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "توضیح مختصر ")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Weblog_Short_Description { get; set; }
        //***====================================================================================***//
        [Display(Name = "متن ")]
        public string Weblog_Text { get; set; }
        //***====================================================================================***//
        [Display(Name = "نویسنده  ")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Weblog_Writer { get; set; }           
        //***====================================================================================***//
        [Display(Name = " وضعیت نمایش")]
        public bool Weblog_IsShow { get; set; }
        //***====================================================================================***//
        [Display(Name = "گروه  ")]
        public int Weblog_GroupId { get; set; }
        //***====================================================================================***//
        [Display(Name = "زمان تقریبی مطالعه  ")]
        public ushort Weblog_StudyTime { get; set; }
        //***====================================================================================***//
        [Display(Name = "امتیاز  ")]
        public StarType Weblog_Star { get; set; }
        //***====================================================================================***//
        [Display(Name = "لینک کوتاه  ")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Weblog_ShortLink { get; set; }
        //***====================================================================================***//
        #endregion
    

    }
   
  
}

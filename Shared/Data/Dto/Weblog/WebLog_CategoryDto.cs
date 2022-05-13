using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Data.Dto
{
    public class WebLog_CategoryDto : BaseMetaTagDto
    {
        #region Properties
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        [Display(Name = "عنوان اول")]
        public string WebLog_Category_Title_One { get; set; }
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "عنوان دوم")]
        public string WebLog_Category_Title_Two { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر")]
        public IFormFile WebLog_Category_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویرکوچک")]
        public IFormFile WebLog_Category_ThumbnaillImage { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر برای صفحه اصلی")]
        public IFormFile WebLog_Category_ImageHome { get; set; }
        //***====================================================================================***//
        [Display(Name = "مرتب سازی  ")]
        public short? WebLog_Category_Order { get; set; }
        //***====================================================================================***//
        [Display(Name = "نمایش |غیر نمایش  ")]
        public bool WebLog_Category_IsShow { get; set; }
        //***====================================================================================***//
        [Display(Name = "توضیحات مختصر")]
        [MaxLength(1000, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Category_ShortDescription { get; set; }
        //***====================================================================================***//      
        [Display(Name = "توضیح کامل  ")]
        public string WebLog_Category_Description { get; set; }
        //***====================================================================================***//
        [Display(Name = "لینک کوتاه  ")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string WebLog_Category_ShortLink { get; set; }
        //***====================================================================================***//
        #endregion
        


    }
 
}

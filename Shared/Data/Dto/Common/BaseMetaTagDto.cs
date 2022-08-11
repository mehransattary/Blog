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
 

    public abstract class BaseMetaTagDto<TKey> : BaseEntityDto<TKey>
    {

        //***====================================================================================***//
        [Display(Name = "عنوان  متا")]
        [MaxLength(80, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "اجباری است")]
        public string Title_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string TitleEnglish_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "آدرس اینترنتی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "اجباری است")]
        public string Url_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "توضیحات متاتگ")]
        [MaxLength(185, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "اجباری است")]
        public string Desc_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "تگ کنونیکال")]
        [MaxLength(500)]
        public string Canonical_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "کلمات کلیدی متا تگ")]
        [MaxLength(400)]
        public string Keyword_Meta { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر متا تگ")]
        public IFormFile Image_Meta { get; set; }
        //***====================================================================================***//
    }

    public abstract class BaseMetaTag : BaseMetaTagDto<int>
    {

    }
}

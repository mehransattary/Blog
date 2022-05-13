using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Label : BaseMetaTag
    {


        #region Properties
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "عنوان اول")]
        public string WebLog_Label_Title_One { get; set; }
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "عنوان دوم")]
        public string WebLog_Label_Title_Two { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Label_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویرکوچک")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Label_ThumbnaillImage { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر برای صفحه اصلی")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Label_ImageHome { get; set; }
        //***====================================================================================***//
        [Display(Name = "مرتب سازی  ")]
        public short? WebLog_Label_Order { get; set; }
        //***====================================================================================***//
        [Display(Name = "نمایش |غیر نمایش  ")]
        public bool WebLog_Label_IsShow { get; set; }
        //***====================================================================================***//
        [Display(Name = "توضیحات مختصر")]
        [MaxLength(1000, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Label_ShortDescription { get; set; }
        //***====================================================================================***//      
        [Display(Name = "توضیح کامل  ")]
        public string WebLog_Label_Description { get; set; }
        //***====================================================================================***//
        [Display(Name = "لینک کوتاه  ")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string WebLog_Label_ShortLink { get; set; }
        //***====================================================================================***//

        #endregion

     

    }
    public class Configuration_WebLog_Label : IEntityTypeConfiguration<WebLog_Label>
    {
        public void Configure(EntityTypeBuilder<WebLog_Label> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }


}

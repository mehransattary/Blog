using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Group: BaseMetaTag
    {
        #region Properties
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        [Display(Name = "عنوان اول")]
        public string WebLog_Group_Title_One { get; set; }
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(100, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        [Display(Name = "عنوان دوم")]
        public string WebLog_Group_Title_Two { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string WebLog_Group_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویرکوچک")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string WebLog_Group_ThumbnaillImage { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر برای صفحه اصلی")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string WebLog_Group_ImageHome { get; set; }
        //***====================================================================================***//
        [Display(Name = "مرتب سازی  ")]
        public short? WebLog_Group_Order { get; set; }
        //***====================================================================================***//
        [Display(Name = "نمایش |غیر نمایش  ")]
        public bool WebLog_Group_IsShow { get; set; }
        //***====================================================================================***//
        [Display(Name = "توضیحات مختصر")]
        [MaxLength(1000, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string WebLog_Group_ShortDescription { get; set; }
        //***====================================================================================***//      
        [Display(Name = "توضیح کامل  ")]
        public string WebLog_Group_Description { get; set; }
        //***====================================================================================***//
        [Display(Name = "لینک کوتاه  ")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string WebLog_Group_ShortLink { get; set; }
        //***====================================================================================***//
        [Display(Name = "دسته   ")]
        public int WebLog_Group_CategoryId { get; set; }
        #endregion

        #region Relations
        //***====================================================================================***//
        public ICollection<WebLog> WebLogs { get; set; }
        //***====================================================================================***//
        [ForeignKey(nameof(WebLog_Group_CategoryId))]
        public WebLog_Category WebLog_Category { get; set; }
        //***====================================================================================***//
        #endregion



    }
    public class Configuration_WebLog_Group : IEntityTypeConfiguration<WebLog_Group>
    {
        public void Configure(EntityTypeBuilder<WebLog_Group> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog : BaseMetaTag
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
        public string Weblog_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر کوچک")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از{1}کاراکتر وارد شه")]
        public string Weblog_Thumbnail_Image { get; set; }
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
        #region Relations
        [ForeignKey(nameof(Weblog_GroupId))]
        public WebLog_Group WebLog_Groups { get; set; }

        #endregion

    }
    public enum StarType
    {
        [Display(Name = "بسیار عالی")]
        VeryExcellent = 1,
        [Display(Name = "عالی")]
        Excellent = 2,
        [Display(Name = "خوب")]
        Good = 2,
        [Display(Name = "متوسط")]
        Medium = 2,
        [Display(Name = "ضعیف")]
        Weak = 2,
    }
    public class Configuration_WebLog : IEntityTypeConfiguration<WebLog>
    {
        public void Configure(EntityTypeBuilder<WebLog> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }


}

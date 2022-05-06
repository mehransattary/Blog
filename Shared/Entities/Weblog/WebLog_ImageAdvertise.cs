using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_ImageAdvertise : BaseEntity
    {

        #region Properties
        //***====================================================================================***//  
        [MaxLength(100, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "عنوان تبلیغ")]
        public string WebLog_ImageAdvertise_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = "دسته")]
        public int WebLog_ImageAdvertise_CategoryId { get; set; }
        //***====================================================================================***//
        public bool WebLog_ImageAdvertise_Category_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "گروه")]
        public int WebLog_ImageAdvertise_GroupId { get; set; }
        //***====================================================================================***//
        public bool WebLog_ImageAdvertise_Group_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "بلاگ")]
        public int WebLog_ImageAdvertise_BlogId { get; set; }
        //***====================================================================================***//
        public bool WebLog_ImageAdvertise_Blog_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "برچسب")]
        public int WebLog_ImageAdvertise_LabelId { get; set; }
        //***====================================================================================***//
        public bool WebLog_ImageAdvertise_Label_IsActive { get; set; }
        //***====================================================================================***//
        [MaxLength(250, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "لینک")]
        public string WebLog_ImageAdvertise_Link { get; set; }
        //***====================================================================================***//  
        [Display(Name = "تصویر")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_ImageAdvertise_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "مرتب سازی")]
        public int WebLog_ImageAdvertise_Order { get; set; }
        //***====================================================================================***//        
        [Display(Name = "فعال/غیر فعال")]
        public bool WebLog_ImageAdvertise_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در بالا صفحه")]
        public bool WebLog_ImageAdvertise_IsActive_TopPage { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در وسط صفحه")]
        public bool WebLog_ImageAdvertise_IsActive_MiddlePage { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در پایین صفحه")]
        public bool WebLog_ImageAdvertise_IsActive_BottomPage { get; set; }
        //***====================================================================================***//
        public string WebLog_ImageAdvertise_HtmlRaw { get; set; }

        #endregion
        #region Relation
        //***====================================================================================***//

        [ForeignKey(nameof(WebLog_ImageAdvertise_LabelId))]
        public WebLog_Label  webLog_Label { get; set; }
        //***====================================================================================***//

        [ForeignKey(nameof(WebLog_ImageAdvertise_GroupId))]
        public WebLog_Group WebLog_Group { get; set; }
        //***====================================================================================***//

        [ForeignKey(nameof(WebLog_ImageAdvertise_CategoryId))]
        public WebLog_Category webLog_Category { get; set; }
        //***====================================================================================***//

        [ForeignKey(nameof(WebLog_ImageAdvertise_BlogId))]
        public WebLog webLog { get; set; }
        //***====================================================================================***//

        #endregion


    }
    public class Configuration_WebLog_WebLog_ImageAdvertise : IEntityTypeConfiguration<WebLog_ImageAdvertise>
    {
        public void Configure(EntityTypeBuilder<WebLog_ImageAdvertise> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

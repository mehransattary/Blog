using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Comment : BaseEntity
    {

        #region Properties
        //***====================================================================================***//  
        [Display(Name = "بلاگ")]
        public int WeblogId { get; set; }
        //***====================================================================================***//    
        [Display(Name = "نظر")]
        public int? ParentId { get; set; }
        //***====================================================================================***//
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [MaxLength(150, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شود")]
        [Display(Name = "نام کاربری")]
        public string Comment_UserName { get; set; }
    
        //***====================================================================================***//        
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [Display(Name = "متن نظر")]
        [DataType(DataType.MultilineText)]
        public string Comment_Text { get; set; }     
        //***====================================================================================***//
        [Display(Name = "فعال")]
        public bool Comment_IsShow { get; set; }
        //***====================================================================================***//
        [Display(Name = "پاسخ داده شده")]
        public bool Comment_OkAnswer { get; set; }
        //***====================================================================================***//
        #endregion
        #region Relations
        [ForeignKey(nameof(WeblogId))]
        public WebLog WebLog { get; set; }

        #endregion

    }
    public class Configuration_WebLog_Comment : IEntityTypeConfiguration<WebLog_Comment>
    {
        public void Configure(EntityTypeBuilder<WebLog_Comment> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

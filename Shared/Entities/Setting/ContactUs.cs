using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class ContactUs : BaseMetaTag
    {
        #region Properties
        //***====================================================================================***//
        [Display(Name = "تماس با ما")]
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [DataType(DataType.MultilineText)]
        public string ContactUs_Text { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویرتماس با ما")]
        [MaxLength(500, ErrorMessage = "لطفا نام تصویر بیش از 500  کاراکتر نباشد")]
        public string ContactUs_Image { get; set; }
        //***====================================================================================***//
        #endregion



    }
    public class Configuration_ContactUs : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

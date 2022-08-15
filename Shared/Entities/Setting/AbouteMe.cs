using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class AbouteMe : BaseMetaTag
    {
        #region Properties
        //***====================================================================================***//
        [Display(Name = "متن درباره ما ")]
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [DataType(DataType.MultilineText)]
        public string AbouteMe_Text { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویردرباره ما")]
        [MaxLength(500, ErrorMessage = "لطفا نام تصویر بیش از 500  کاراکتر نباشد")]
        public string AbouteMe_Image { get; set; }
        //***====================================================================================***//
        #endregion


    }
    public class Configuration_AbouteMe : IEntityTypeConfiguration<AbouteMe>
    {
        public void Configure(EntityTypeBuilder<AbouteMe> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

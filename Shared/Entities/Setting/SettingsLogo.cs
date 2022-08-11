using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class SettingsLogo : BaseEntity<byte>
    {
        #region Logo
        //***====================================================================================***//
        [Display(Name = "تصویر لوگو")]
        public string Settings_Image_Logo { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر لوگوفوتر")]
        public string Settings_Image_Logo_Footer { get; set; }
        //***====================================================================================***//
        [Display(Name = "alt لوگو")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_alt_Logo { get; set; }
        //***====================================================================================***//
        [Display(Name = "title لوگو")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_title_Logo { get; set; }
        //***====================================================================================***//
        [Display(Name = " آیکون  ")]
        public string Settings_Icon_Path { get; set; }
        //***====================================================================================***//

        #endregion
    }
    public class Configuration_SettingsLogo : IEntityTypeConfiguration<SettingsLogo>
    {
        public void Configure(EntityTypeBuilder<SettingsLogo> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

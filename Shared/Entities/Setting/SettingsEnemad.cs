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
    public  class SettingsEnemad : BaseEntity
    {
        #region Enemad
        //***====================================================================================***//
        [Display(Name = "    تصویر ای نماد")]
        public string Settings_Image_Enemad { get; set; }
        //***====================================================================================***//
        [Display(Name = "    عنوان ای نماد")]
        [MaxLength(200, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Title_Enemad { get; set; }
        //***====================================================================================***//
        [Display(Name = "    href ای نماد")]
        [MaxLength(400, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_href_Enemad { get; set; }
        //***====================================================================================***//
        [Display(Name = " وجود ای نماد ")]
        public bool Settings_IsExist_Enemad { get; set; }
        //***====================================================================================***//
        #endregion
    }
    public class Configuration_SettingsEnemad : IEntityTypeConfiguration<SettingsEnemad>
    {
        public void Configure(EntityTypeBuilder<SettingsEnemad> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

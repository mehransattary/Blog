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
     public  class SettingAdvertising : BaseEntity
    {

        #region Advertising
        //***====================================================================================***//
        [Display(Name = "عنوان لینک تبلیغ ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Advertising_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = " href تبلیغ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_href_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = " alt تبلیغ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_alt_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = " title تبلیغ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_title_Title { get; set; }
        //***====================================================================================***//
        #endregion
    }
    public class Configuration_SettingAdvertising : IEntityTypeConfiguration<SettingAdvertising>
    {
        public void Configure(EntityTypeBuilder<SettingAdvertising> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}


using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public  class SettingAdvertisingDto: BaseDto
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
}

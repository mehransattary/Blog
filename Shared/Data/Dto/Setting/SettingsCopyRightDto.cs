using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class SettingsCopyRightDto : BaseDto
    {
        #region @CopyRight


        //***====================================================================================***//
        [Display(Name = "  عنوان طراح  ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Tarah_Title { get; set; }
        //***====================================================================================***//
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        [Display(Name = "  لینک طراح  ")]
        public string Settings_Tarah_Href { get; set; }
        //***====================================================================================***//
        [Display(Name = "  نام طراح  ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Tarah_FullName { get; set; }
        //***====================================================================================***//
        [Display(Name = "  تصویر لوگویی برای طراح  ")]
        public IFormFile Settings_Tarah_Logo_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "  Title لوگویی برای طراح  ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Tarah_Logo_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = "  alt لوگویی برای طراح  ")]
        [MaxLength(150, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Tarah_Logo_alt { get; set; }
        //***====================================================================================***//
        #endregion
    }
}

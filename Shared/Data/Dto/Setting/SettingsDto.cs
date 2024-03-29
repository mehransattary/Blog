﻿

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class SettingsDto : BaseEntityDto<int>
    {
        #region Properties

        //***====================================================================================***//
        [Display(Name = "عنوان سایت")]
        [MaxLength(200, ErrorMessage = "بیشتر از  {0} کاراکترنباشد ")]
        public string Settings_Sitename { get; set; }
        //***====================================================================================***//
        [Display(Name = "سوالات متداول")]
        [DataType(DataType.MultilineText)]
        public string Settings_Questions { get; set; }
        //***====================================================================================***//
        [Display(Name = "راهنمای ثبت سفارش")]
        [DataType(DataType.MultilineText)]
        public string Settings_HelperSell { get; set; }
        //***====================================================================================***//
        [Display(Name = " آدرس مرکزی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(450, ErrorMessage = "بیشتر از {0} کاراکتر نباشد ")]
        public string Settings_Address { get; set; }

        //***====================================================================================***//
        [Display(Name = "تلفن")]
        [MaxLength(50, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Tell { get; set; }
        //***====================================================================================***//
        [Display(Name = "موبایل")]
        [MaxLength(50, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Mobile { get; set; }
        //***====================================================================================***//
        [Display(Name = "ایمیل")]
        [MaxLength(50, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_Email { get; set; }
        //***====================================================================================***//
        [Display(Name = "عکس  فوتر")]
        public IFormFile Settings_ImageFooter { get; set; }
        //***====================================================================================***//
        [Display(Name = "عکس  بالا صفحه اصلی")]
        public IFormFile Settings_ImageTopMain { get; set; }
        //***====================================================================================***//

        #endregion



    }

}

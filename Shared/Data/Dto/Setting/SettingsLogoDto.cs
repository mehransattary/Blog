﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public  class SettingsLogoDto : BaseEntityDto<int>
    {
        #region Logo

        //***====================================================================================***//
        [Display(Name = "تصویر لوگو")]
        public IFormFile Settings_Image_Logo { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویر لوگوفوتر")]
        public IFormFile Settings_Image_Logo_Footer { get; set; }
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
        public IFormFile Settings_Icon_Path { get; set; }
        //***====================================================================================***//

        #endregion
    }
}

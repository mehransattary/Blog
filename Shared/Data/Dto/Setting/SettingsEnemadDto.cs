using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class SettingsEnemadDto : BaseEntityDto<byte>
    {
        #region Enemad
   

        //***====================================================================================***//
        [Display(Name = "    تصویر ای نماد")]
        public IFormFile Settings_Image_Enemad { get; set; }
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
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class ContactUsDto : BaseMetaTagDto<byte>
    {
        #region Properties
        //***====================================================================================***//
        [Display(Name = "تماس با ما")]
        [Required(ErrorMessage = "لطفا{0}راواردکنید")]
        [DataType(DataType.MultilineText)]
        public string ContactUs_Text { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویرتماس با ما")]
        public IFormFile ContactUs_Image { get; set; }
        //***====================================================================================***//
        #endregion
    }
}

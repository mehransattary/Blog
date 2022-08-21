using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class AbouteMeDto : BaseMetaTagDto<int>
    {
        #region Properties
        //***====================================================================================***//
        [Display(Name = "متن درباره ما ")]
        [Required(ErrorMessage = "لطفا {0} راواردکنید")]
        [DataType(DataType.MultilineText)]
        public string AbouteMe_Text { get; set; }
        //***====================================================================================***//
        [Display(Name = "تصویردرباره ما")]
        public IFormFile AbouteMe_Image { get; set; }
        //***====================================================================================***//
        #endregion
    }
}

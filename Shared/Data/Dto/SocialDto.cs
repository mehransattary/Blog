
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Data.Dto
{
    public class SocialDto : BaseDto
    {


        //*****************************************************************//
        [Display(Name = "نام شبکه ")]
        [MaxLength(100, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //*****************************************************************//
        [Display(Name = "لینک پروژه ")]
        public string Link { get; set; }
        //*****************************************************************//
        [Display(Name = "تصویر پروژه ")]
        public IFormFile Image { get; set; }
        //*****************************************************************//
        [Display(Name = "فونت آسوم ")]
        [MaxLength(100, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string FontAwseome { get; set; }
        //*****************************************************************//

    }
   
}

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Data.Dto
{
    public class WebLog_SliderDto : BaseDto
    {


        #region Properties
        //***====================================================================================***//  
        [MaxLength(100, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "عنوان ")]
        public string WebLog_Slider_Title { get; set; }
        //***====================================================================================***//
        [Display(Name = "دسته")]
        public int WebLog_Slider_CategoryId { get; set; }
        //***====================================================================================***//
        public bool WebLog_Slider_Category_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "گروه")]
        public int WebLog_Slider_GroupId { get; set; }
        //***====================================================================================***//
        public bool WebLog_Slider_Group_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "بلاگ")]
        public int WebLog_Slider_BlogId { get; set; }
        //***====================================================================================***//
        public bool WebLog_Slider_Blog_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "برچسب")]
        public int WebLog_Slider_LabelId { get; set; }
        //***====================================================================================***//
        public bool WebLog_Slider_Label_IsActive { get; set; }
        //***====================================================================================***//
        [MaxLength(250, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        [Display(Name = "لینک")]
        public string WebLog_Slider_Link { get; set; }
        //***====================================================================================***//  
        [Display(Name = "تصویر")]
        [MaxLength(700, ErrorMessage = "نباید بیشتر از {1} کاراکتر وارد شه")]
        public string WebLog_Slider_Image { get; set; }
        //***====================================================================================***//
        [Display(Name = "مرتب سازی")]
        public int WebLog_Slider_Order { get; set; }
        //***====================================================================================***//        
        [Display(Name = "فعال/غیر فعال")]
        public bool WebLog_Slider_IsActive { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در بالا صفحه")]
        public bool WebLog_Slider_IsActive_TopPage { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در وسط صفحه")]
        public bool WebLog_Slider_IsActive_MiddlePage { get; set; }
        //***====================================================================================***//
        [Display(Name = "جایگاه در پایین صفحه")]
        public bool WebLog_Slider_IsActive_BottomPage { get; set; }
        //***====================================================================================***//


        #endregion
   

    }
 
}

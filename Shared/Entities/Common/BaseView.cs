using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public  class BaseView : BaseEntity
    {

        [Display(Name = "تعداد بازدید")]
        public int Count_Views { get; set; }
        [Display(Name = "تاریخ بازدید")]
        public DateTime DateTime_Views { get; set; }
        [Display(Name = "آی پی بازدید کننده")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string IP_Views { get; set; }
        [Display(Name = "موبایل/دسکتاپ")]
        public bool IsMobile_Views { get; set; }
        [Display(Name = "مرورگربازدید کننده")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Browser_Views { get; set; }

    }
  
}

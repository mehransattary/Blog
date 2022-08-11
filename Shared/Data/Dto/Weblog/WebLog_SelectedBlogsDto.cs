using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Data.Dto
{
    public class WebLog_SelectedBlogsDto : BaseEntity<int>
    {

        //***====================================================================================***//    
        [Display(Name = "بلاگ ")]
        public string WebLog_BlogId { get; set; }
        //***====================================================================================***//    
        [Display(Name = "مرتب سازی ")]
        public string WebLog_Orddr { get; set; }
        //***====================================================================================***//    


    }

}

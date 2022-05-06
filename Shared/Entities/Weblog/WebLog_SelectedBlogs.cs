using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Entities
{
    public class WebLog_SelectedBlogs : BaseEntity
    {

        //***====================================================================================***//    
        [Display(Name = "بلاگ ")]
        public string WebLog_BlogId { get; set; }
        //***====================================================================================***//    
        [Display(Name = "مرتب سازی ")]
        public string WebLog_Orddr { get; set; }
        //***====================================================================================***//    


    }
    public class Configuration_WebLog_SelectedBlogs : IEntityTypeConfiguration<WebLog_SelectedBlogs>
    {
        public void Configure(EntityTypeBuilder<WebLog_SelectedBlogs> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

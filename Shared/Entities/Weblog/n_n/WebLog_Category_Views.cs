using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Category_Views : BaseEntity
    {
        public int ViewId { get; set; }
        public int WebLog_CategoryId { get; set; }


        [ForeignKey(nameof(ViewId))]
        public BaseView  BaseView { get; set; }
        [ForeignKey(nameof(WebLog_CategoryId))]
        public WebLog_Category WebLog_Category { get; set; }


    }
    public class Configuration_WebLog_Category_Views : IEntityTypeConfiguration<WebLog_Category_Views>
    {
        public void Configure(EntityTypeBuilder<WebLog_Category_Views> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

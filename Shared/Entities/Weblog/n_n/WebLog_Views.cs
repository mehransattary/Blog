using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Views : BaseEntity
    {
        public int ViewId { get; set; }
        public int WebLogId { get; set; }


        [ForeignKey(nameof(ViewId))]
        public BaseView BaseView { get; set; }
        [ForeignKey(nameof(WebLogId))]
        public WebLog WebLog_Category { get; set; }

    }
    public class Configuration_WebLog_Views : IEntityTypeConfiguration<WebLog_Views>
    {
        public void Configure(EntityTypeBuilder<WebLog_Views> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Label_Views : BaseEntity
    {
        public int ViewId { get; set; }
        public int WebLog_LabelId { get; set; }


        [ForeignKey(nameof(ViewId))]
        public BaseView BaseView { get; set; }
        [ForeignKey(nameof(WebLog_LabelId))]
        public WebLog_Label WebLog_Category { get; set; }

    }
    public class Configuration_WebLog_Label_Views : IEntityTypeConfiguration<WebLog_Label_Views>
    {
        public void Configure(EntityTypeBuilder<WebLog_Label_Views> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

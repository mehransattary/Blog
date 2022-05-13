using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Group_Views : BaseEntity
    {

        public int ViewId { get; set; }
        public int WebLog_GroupId { get; set; }


        [ForeignKey(nameof(ViewId))]
        public BaseView BaseView { get; set; }

        [ForeignKey(nameof(WebLog_GroupId))]
        public WebLog_Group  WebLog_Group { get; set; }

    }
    public class Configuration_WebLog_Group_Views : IEntityTypeConfiguration<WebLog_Group_Views>
    {
        public void Configure(EntityTypeBuilder<WebLog_Group_Views> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

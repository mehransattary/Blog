using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Entities
{
    public class WebLog_Label_Blog : BaseEntity<int>
    {
        //***====================================================================================***//
        [Display(Name = "  بلاگ")]
        public int WeblogId { get; set; }
        //***====================================================================================***//
        [Display(Name = " برچسب  ")]
        public int LabelId { get; set; }
        //***====================================================================================***//
        #region Relationship
        //***====================================================================================***//
        [ForeignKey(nameof(WeblogId))]
        public WebLog webLog { get; set; }
        //***====================================================================================***//
        [ForeignKey(nameof(LabelId))]
        public WebLog_Label webLog_Label { get; set; }
        //***====================================================================================***//
        #endregion

    }
    public class Configuration_WebLog_Label_Blog : IEntityTypeConfiguration<WebLog_Label_Blog>
    {
        public void Configure(EntityTypeBuilder<WebLog_Label_Blog> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

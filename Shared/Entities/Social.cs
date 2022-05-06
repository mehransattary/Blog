using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Entities
{
    public class Social : BaseEntity
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
        public string Image { get; set; }
        //*****************************************************************//
        [Display(Name = "فونت آسوم ")]
        [MaxLength(100, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string FontAwseome { get; set; }
        //*****************************************************************//

    }
    public class Configuration_Social : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}

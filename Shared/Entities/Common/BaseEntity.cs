using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
   
        public TKey Id { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
        [Display(Name = "آی دی یوزر ")]
        [MaxLength(450, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string UserId { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
      
    }
}

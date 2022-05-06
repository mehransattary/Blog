using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
   public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        [Display(Name = "آی دی یوزر ")]
        [MaxLength(450, ErrorMessage = "نباید بیش تر از {1} کاراکتر باشد")]
        public string UserId { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class HeaderNotification
    {
        [Key]
        public int HeaderNotofocationID { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        public string Text { get; set; }
        [Display(Name = "فعال / غیرفعال")]
        public bool IsAviable { get; set; }

        public HeaderNotification()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }
        [Display(Name = "فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ShopID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Tittle { get; set; }
        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string URL { get; set; }

        // Navigation Property :
        public virtual Shop Shop { get; set; }

        public Link()
        {

        }
    }
}

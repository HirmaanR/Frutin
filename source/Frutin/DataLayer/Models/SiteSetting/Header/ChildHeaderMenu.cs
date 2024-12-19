using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class ChildHeaderMenu
    {
        [Key]
        public int ChildMenuID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "آیدی منو پدر")]
        public int HeaderMenuID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "لینک")]
        [MaxLength(350)]
        public string Link { get; set; }

        public HeaderMenu HeaderMenu { get; set; }

        public ChildHeaderMenu()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class HeaderMenu
    {
        [Key]
        public int HeaderMenuID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Display(Name = "آیا دارای زیر مجموعه است؟")]
        public bool IsMenuHasChild { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        public string Link { get; set; }

        public List<ChildHeaderMenu> ChildHeaderMenus { get; set; }

        public HeaderMenu()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        [Display(Name = "مدیر فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserID { get; set; }
        [Display(Name = "مقام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RoleID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string ShortDes { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Display(Name = "سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Site { get; set; }
        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        public string Address { get; set; }

        // Navigation Property :
        public virtual List<Link> Links { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Blog> Blogs { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

        public Shop()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "دسنه بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryID { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "نام تصویر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string ImageName { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public double Price { get; set; }
        [Display(Name = "فعال / غیر قعال")]
        public bool IsAvailable { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Count { get; set; }
        [Display(Name = "درصد تخفیف")]
        public double OffPercent { get; set; }
        [Display(Name = "آیا محصول دارای تخفیف است؟")]
        public bool IsOffer { get; set; }

        // Navigation Property :
        public virtual List<ProductTag> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Shop Shops { get; set; }
        public virtual Category Category { get; set; }

        public Product()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Display(Name = "خریدار")]
        public int UserID { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string City { get; set; }
        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        public string Address { get; set; }
        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PostCode { get; set; }
        [Display(Name = "جمع قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public double SumPrice { get; set; }
        [Display(Name = "وضعیت سفارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Status { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }



        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual User User { get; set; }
        public Order()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductID { get; set; }

        [Display(Name = "شماره کالا")]
        public int ProductID { get; set; }
        [Display(Name = "شماره سفارش")]
        public int OrderID { get; set; }
        [Display(Name ="تعداد کالا")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int ProductCount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public OrderProduct()
        {

        }
    }
}

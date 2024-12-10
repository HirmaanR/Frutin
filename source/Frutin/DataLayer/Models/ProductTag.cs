using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class ProductTag
    {
        [Key]
        public int ProductTagID { get; set; }
        [Display(Name = "برچسب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TagID { get; set; }
        [Display(Name = "محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductID { get; set; }


        public virtual Tag Tag { get; set; }
        public virtual Product Product { get; set; }

        public ProductTag()
        {

        }
    }
}

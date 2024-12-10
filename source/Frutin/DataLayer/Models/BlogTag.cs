using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class BlogTag
    {
        [Key]
        public int BlogTagID { get; set; }
        [Display(Name = "مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int BlogID { get; set; }
        [Display(Name = "برچسب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TagID { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }

        public BlogTag()
        {

        }
    }
}

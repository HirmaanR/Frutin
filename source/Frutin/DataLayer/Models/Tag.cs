using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Tittle { get; set; }

        // Navigation Property :
        public virtual List<ProductTag> ProductTags { get; set; }
        public virtual List<BlogTag> BlogTags { get; set; }

        public Tag()
        {

        }
    }
}

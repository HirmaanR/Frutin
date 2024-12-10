using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataLayer
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ShopID { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Tittle { get; set; }
        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string ShortDes { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Text { get; set; }
        [Display(Name = "نام تصویر کاور")]
        [MaxLength(150)]
        public string CoverImage { get; set; }
        [Display(Name = "تصویر توضیحات")]
        [MaxLength(150)]
        public string DesImage { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "فعال / غیرفعال")]
        public bool IsAvailable { get; set; }

        // Navigation Property :
        public virtual List<BlogTag> BlogTags { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Shop Shop { get; set; }

        public Blog()
        {

        }
    }
}

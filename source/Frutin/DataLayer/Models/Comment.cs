using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "مقاله / کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TowardID { get; set; }

        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserID { get; set; }
        [Display(Name = "کامنت پدر")]
        public int ParentID { get; set; }
        [Display(Name = "پاسخ")]
        public bool IsReplay { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Tittle { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Text { get; set; }

        public virtual User User { get; set; }

        public Comment()
        {

        }
    }
}

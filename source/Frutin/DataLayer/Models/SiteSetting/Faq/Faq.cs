using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class Faq
    {
        [Key]
        public int FaqID { get; set; }
        [Display(Name = "سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Question { get; set; }
        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Answer { get; set; }
        [Display(Name = "قعال / غیرفعال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsAviable { get; set; }

    }
}

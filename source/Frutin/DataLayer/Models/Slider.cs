using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Label { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کپشن")]
        [MaxLength(200)]
        public string Caption { get; set; }
        [Display(Name = "فعال / غیر فعال")]
        public bool IsAviable { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تصویر")]
        [MaxLength(300)]
        public string ImageName { get; set; }
        [Display(Name = "لینک")]
        [MaxLength(300)]
        public string Link { get; set; }
        [Display(Name = "آیا اولین اسلاید است؟")]
        public bool IsActive { get; set; }
    }
}

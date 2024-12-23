using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class NewsEmail // subscribe news email table -> _SubscribeEmailcontroller/SendMail
    {
        [Key]
        public int NewsEmailID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(300)]
        public string Email { get; set; }
    }
}

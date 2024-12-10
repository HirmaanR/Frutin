using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Tittle { get; set; }

        // Navigation Property :
        public virtual List<Shop> Shops { get; set; }

        public Role()
        {

        }
    }
}

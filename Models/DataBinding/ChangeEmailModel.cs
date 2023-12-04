using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class ChangeEmailModel
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassord { get; set; }


        [Display(Name = "New Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }



        [Display(Name = "Cornfirm Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("NewPassword")]
        public string ConfirmEmail { get; set; }
    }
}

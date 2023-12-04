using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class ChangePasswordModel
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Current Password")]
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassord { get; set; }


        [Display(Name = "New Password")]
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }



        [Display(Name = "Cornfirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}

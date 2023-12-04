using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class UserModel : IdentityUser
    {
        [Display(Name = "Fist Name")]
        [Required]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CellNo { get; set; }      

    }
}

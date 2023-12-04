using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class RegisterUserModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        [Required]
      
        public string Name { get; set; }
        [Display(Name = "LastName")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "EmailIsInUsE", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CellNo { get; set; }

    }
}

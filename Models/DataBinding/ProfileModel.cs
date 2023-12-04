using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class ProfileModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile")]
        public byte[] Profile { get; set; }
        [Display(Name = "FirstName")]
        [Required]

        public string Name { get; set; }
        [Display(Name = "LastName")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]     
        public string Email { get; set; }
        ///
        [Required]
        [Display(Name = "Centre Name")]
        public string CentreName { get; set; }
        [Required]
        [Display(Name = " Centre Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CentreNo { get; set; }
        [Required]
        [Display(Name = "Centre Email")]
        [DataType(DataType.EmailAddress)]
        public string CentraEmail { get; set; }

        [Required]
        [Display(Name = " Centre Fax Number")]
        [DataType(DataType.PhoneNumber)]
        public string CentreFaxNo { get; set; }

        public int SuburbId { get; set; }
       // [ForeignKey("SuburbId")]
       // public SuburbModel SuburbModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Del;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class RegTeacherModel
    {
        [Key]
        public int teacherId { get; set; }

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
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        //public int CentreId { get; set; }
        //[ForeignKey("CentreId")]
        [Required]
        [Display(Name = "Centre")]
        public CenterDel CentreModel { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
        
        public TittleModel tittleModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Algorithm_3rd_Year_Project.Models.DataModel;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class EnroleMode
    {
        [Key]
        public int PupilId { get; set; }
        [Display(Name = "Fist Name")]
        [Required]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Lname { get; set; }
        [Display(Name = "Identity Number")]
        [Required]
        [MaxLength(13)]
        public string IdentityNo { get; set; }
        [Display(Name = "Programe")]
        public int ProgrameOfferdId { get; set; }
        [ForeignKey("ProgrameOfferdId")]
        public ProgrameOfferdModel ProgrameOfferdModel { get; set; }
        public int CentreId { get; set; }
        public int CentreProgramId { get; set; }
    }
}

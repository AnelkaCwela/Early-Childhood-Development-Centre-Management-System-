using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class ProgrameOfferdModel
    {
        [Key]
        public int ProgrameOfferdId { get; set; }

      
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public int CentreProgramId { get; set; }
        [ForeignKey("CentreProgramId")]
        public CentreProgramModel  CentreProgramModel { get; set; }

        public int teacherId { get; set; }
        [ForeignKey("teacherId")]
        public TeacherModel TeacherModel { get; set; }
    }
}

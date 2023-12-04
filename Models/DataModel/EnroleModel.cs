using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class EnroleModel
    {
        [Key]
        public int EnroleId { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public bool Enrole { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Year of Enrollment")]
        public DateTime EnroleYear { get; set; }
        public int PupilId { get; set; }
        [ForeignKey("PupilId")]
        public PupilModel PupilModel { get; set; }
        public int ProgrameOfferdId { get; set; }
        [ForeignKey("ProgrameOfferdId")]
        public ProgrameOfferdModel ProgrameOfferdModel { get; set; }
    }
}

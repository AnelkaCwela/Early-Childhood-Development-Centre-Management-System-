using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class CentreProgramModel
    {
        [Key]
        public int CentreProgramId { get; set; }
        [Required]
        [Display(Name = "Programe Description")]
        public string ProgramDescr { get; set; }
        //public int ProgramId { get; set; }
        //[ForeignKey("ProgramId")]
        //public ProgrameModel ProgrameModel { get; set; }
        public int CentreId { get; set; }
        [ForeignKey("CentreId")]
        public CentreModel CentreModel { get; set; }

        [Display(Name = "Year Offerd")]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-mm-dd}")]
        public DateTime YearOferd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class ProgrameModel
    {
        [Key]
        public int ProgramId { get; set; }
        [Required]
        [Display(Name ="Programe Description")]
        public string ProgramDescr { get; set; }
    }
}

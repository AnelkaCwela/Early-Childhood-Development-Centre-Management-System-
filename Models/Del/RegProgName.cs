using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.Del
{
    public class RegProgName
    {
        [Key]
        public int teacherId { get; set; }

        [Display(Name = "Program Name")]
        [Required]
        public string Programname { get; set; }
        [Display(Name = "Program Discrption")]
        [Required]
        public string ProgramDiscrption { get; set; }
        [Required]
        [Display(Name = "Program Cost")]
        [DataType(DataType.Currency)]
        public decimal ProgramCost { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public durationDel durationDe { get; set; }
        [Required]
        [Display(Name = "Centre")]
        public CenterDel CentreModel { get; set; }
    }
}

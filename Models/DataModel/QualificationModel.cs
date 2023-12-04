using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class QualificationModel
    {
        [Key]
        public int QualificationId { get; set; }
        [Required]
        [Display(Name ="Qualification Name")]
        public string QualificationName { get; set; }
    }
}

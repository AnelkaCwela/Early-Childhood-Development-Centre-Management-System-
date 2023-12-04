using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class GanderModel
    {
        [Key]
        public int GanderId { get; set; }
        [Required]
        [Display(Name = "Gander")]
        public string Gander { get; set; }
        
    }
}

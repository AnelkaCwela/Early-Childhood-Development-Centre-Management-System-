using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Enter  Statuse")]
        [Display(Name = "Statuse")]
        public string Statuse { get; set; }
        
    }
}

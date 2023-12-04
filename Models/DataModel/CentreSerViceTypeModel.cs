using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class CentreSerViceTypeModel
    {
        [Key]
        public int CentreServiceTypeId { get; set; }
        [Required]
        [Display(Name ="Type")]
        public string ServiceType { get; set; }
    }
}

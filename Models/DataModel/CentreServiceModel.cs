using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class CentreServiceModel
    {
        [Key]
        public int CentreServiceId { get; set; }

        [Display(Name = "Price")]
        [Required]
        public double ServicePrice { get; set; }
        [Display(Name = "Service Name")]
        [Required]

        public string serviceName { get; set; }

        public int CentreServiceTypeId { get; set; }
        [ForeignKey("CentreServiceTypeId")]
        public CentreSerViceTypeModel CentreSerViceTypeModel { get; set; }
        
        public int CentreId { get; set; }
        [ForeignKey("CentreId")]
        public CentreModel CentreModel { get; set; }
    }
}

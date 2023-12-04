using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class ServeModel
    {
        [Key]
        public int ServeId { get; set; }
        [Display(Name ="Date")]
        public DateTime serveDate { get; set; }
        public int CentreServiceId { get; set; }
        [ForeignKey("CentreServiceId")]
        public CentreServiceModel CentreServiceModel { get; set; }
        public int PupilId { get; set; }
        [ForeignKey("PupilId")]
        public PupilModel PupilModel { get; set; }
    }
}

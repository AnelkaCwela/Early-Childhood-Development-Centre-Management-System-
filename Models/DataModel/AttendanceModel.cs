using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class AttendanceModel
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        [Display(Name = "Yes /No")]
        public bool attend { get; set; }
        public int PupilId { get; set; }
            
        [Required]
        [Display(Name = "Date")]
        public DateTime AttanceDate { get; set; }
        public int EnroleId { get; set; }
        [ForeignKey("EnroleId")]
        public EnroleModel EnroleModel { get; set; }
    }
}

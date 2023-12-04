using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class MarksModel
    {
        [Key]
        public int MarksId { get; set; }
        [Display(Name = "Mark")]
        [Required]
        public decimal Mark { get; set; }
        public int PupilId { get; set; }
        public int EnroleId { get; set; }
        [ForeignKey("EnroleId")]
        public EnroleModel enroleModel { get; set; }
        public int taskId { get; set; }
        [ForeignKey("taskId")]
        public TaskModel TaskModel { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class TaskModel
    {
        [Key]
        public int taskId { get; set; }
        [Display(Name = "Task Name")]
        [Required]
        public string  taskName { get; set; }//Test/Assgement
        [Display(Name = "Surbmtion Date")]
        [Required]
        public DateTime TaskDate { get; set; }
        [Required]
        [Display(Name = "Mark")]
        public int Mark { get; set; }

        public int CentreId { get; set; }

    }
}

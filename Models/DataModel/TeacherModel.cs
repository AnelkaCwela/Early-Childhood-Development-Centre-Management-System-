using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class TeacherModel
    {
        [Key]
        public int teacherId { get; set; }
        public string UserName { get; set; }
     
        public byte[] Profile { get; set; }
        public int CentreId { get; set; }
        [Required]
        [Display(Name ="Qualification")]
        public int QualificationId { get; set; }
        [ForeignKey("QualificationId")]
        public QualificationModel Qualification { get; set; }
        [Display(Name = " Tittle")]
        [Required]
        public TittleModel tittleModel { get; set; }
    }
}

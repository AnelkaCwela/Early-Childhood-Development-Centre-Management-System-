using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class PupilModel
    {
        [Key]
        public int PupilId { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name ="Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public DateTime ApplicationDate { get; set; }
        [Display(Name = "Fist Name")]
        [Required]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Lname { get; set; }
        [Display(Name = "Identity Number")]
        [Required]
        [MaxLength(13)]
        public string IdentityNo { get; set; }
        [Display(Name = "Birth Certificate Document(PDF)")]
        public byte[] birthDocument { get; set; }
        [Required]
        public int CentreId { get; set; }
        [Required]
        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public ParentModel ParentModel { get; set; }
        [Required]
        public int GanderId { get; set; }
        [ForeignKey("GanderId")]
        public GanderModel GanderModel { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public StatusModel StatusModel { get; set; }

    }
}

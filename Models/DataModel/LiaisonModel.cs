using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class LiaisonModel
    {
        [Key]
        public int LiaisonId { get; set; }
        [Required]
        public string UserName { get; set; }
       public byte[] Profile { get; set; }

        //[Required]
        //[Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        //public string CellNo { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //[DataType(DataType.EmailAddress)]
        //public string EmailAddress { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public ProvinceModel ProvinceModel { get; set; }
        [Required]
        public TittleModel tittleModel { get; set; }
    }
}

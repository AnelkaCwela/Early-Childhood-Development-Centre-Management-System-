using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class ProvinceModel
    {
        [Key]
        public int ProvinceId { get; set; }
        [Display(Name = "Province")]
        [Required]
        public string ProvinceName { get; set; }
    }
}

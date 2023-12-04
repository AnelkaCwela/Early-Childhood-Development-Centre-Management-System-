using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class RegionModel
    {
        [Key]
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
     public   ProvinceModel ProvinceModel { get; set; }
    }
}

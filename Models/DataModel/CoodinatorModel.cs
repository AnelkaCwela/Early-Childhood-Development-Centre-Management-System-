using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class CoodinatorModel
    {
        [Key]
        public int CoodinatorId { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public byte[] Profile { get; set; }
      [Required]
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public RegionModel RegionModel { get; set; }
        [Required]
        public TittleModel tittleModel { get; set; }
    }
}

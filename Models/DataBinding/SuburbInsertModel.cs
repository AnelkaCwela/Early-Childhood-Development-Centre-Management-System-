using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Algorithm_3rd_Year_Project.Models.DataModel;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class SuburbInsertModel
    {
        [Key]
        public int SuburbId { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Required]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Required]
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public RegionModel RegionModel { get; set; }
        [Required]
        public int ProvinceId { get; set; }
    }
}

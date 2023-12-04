using Algorithm_3rd_Year_Project.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class RegionsViewModel
    {
        public int ProvinceId { get; set; }
        public  SuburbModel suburbModel { get; set; }
        public  RegionModel regionModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm_3rd_Year_Project.Models.DataModel;
namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class ProfileViewModel
    {
    public ParentModel ParentModel { get; set; }
        public IEnumerable<PupilModel> pupilModels { get; set; }
    
    }
    
}

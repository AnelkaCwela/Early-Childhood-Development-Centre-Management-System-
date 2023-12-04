using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class CoodinatorViewModel
    {
        public int CoodinatorId { get; set; }
        [Display(Name = "Fist Name")]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Phone Number")]
        public bool Active { get; set; }
        public string CellNo { get; set; }
        public string UserName { get; set; }
        public byte[] Profile { get; set; }
        public int RegionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class RoleModel
    {

        [Key]
        public int RoleId
        {
            get; set;
        }
        public string RoleName
        {
            get
; set;
        }
    }
}

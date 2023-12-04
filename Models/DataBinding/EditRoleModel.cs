using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Algorithm_3rd_Year_Project.Models.DataBinding
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users = new List<string>();
        }
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Enter Role")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}

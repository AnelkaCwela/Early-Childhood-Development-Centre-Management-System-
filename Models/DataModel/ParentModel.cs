using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class ParentModel
    {
        [Key]
       public int ParentId { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Guardian Identy Number")]
        public string IdNo { get; set; }
        [Required]
        [Display(Name = "RelationShip with Children")]
        public RelationShip relationShip { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Required]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        [DataType(DataType.PostalCode)]
        
        public string PostalCode { get; set; }
        //public byte[] Profile { get; set; }

    }
}

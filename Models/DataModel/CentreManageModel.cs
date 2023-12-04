using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm_3rd_Year_Project.Models.DataModel
{
    public class CentreManageModel
    {
        [Key]
        public int CentreManagerId { get; set; }

        public byte[] Profile { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public int CentreId { get; set; }
        [ForeignKey("CentreId")]
        public CentreModel CentreModel { get; set; }
        [Required]
        public TittleModel tittleModel { get; set; }

    }
}

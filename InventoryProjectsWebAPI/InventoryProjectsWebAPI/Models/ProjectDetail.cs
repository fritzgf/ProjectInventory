using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace InventoryProjectsWebAPI.Models
{
    public class ProjectDetail
    {
        [Key]
        public int PMId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProjectOwnerName { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string ProjectName { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string StartDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string EndDate { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessMVC.Models
{
    public class Program
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ProgramType ProgramType { get; set; }
        public byte ProgramTypeId { get; set; }
    }
}
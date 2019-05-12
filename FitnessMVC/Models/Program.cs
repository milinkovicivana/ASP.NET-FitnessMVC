using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //[NotMapped]
        //public HttpPostedFileBase ImageFile { get; set; }

        public ProgramType ProgramType { get; set; }

        [Display(Name="Program type")]
        public byte ProgramTypeId { get; set; }

        private string _directory = "Images";
        public string ImagePath
        {
            get
            {
                return _directory + "/" + Image;
            }
        } 
    }
}
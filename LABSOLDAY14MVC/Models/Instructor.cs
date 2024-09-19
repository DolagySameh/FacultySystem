using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace LABSOLDAY14MVC.Models
{
    public class Instructor
    {
        [Key]
        public int id { get; set; }

        [MaxLength(15, ErrorMessage ="Must less than 15")]
        [MinLength(3, ErrorMessage = "Must more than 3")]
        [DisplayName("Instructor Name")]
        public string name { get; set; }
        public string address { get; set; }
        public string imag { get; set; }
        [Range(20000, 60000, ErrorMessage ="Must between 60000 And 20000")]
        public int salary { get; set; }
        public int? crs_id { get; set; }
        public int? dept_id { get; set; }
        [ForeignKey("crs_id")]
        public Course? course { get; set; }
        [ForeignKey("dept_id")]
        public Department? department { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplication1CUG2.Validators;

namespace LABSOLDAY14MVC.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20,ErrorMessage ="Must be less than 20")]
        [MinLength(2, ErrorMessage = "Must be more than 2")]
        [DisplayName("Course Name")]
        [Unique]
        public string name { get; set; }
        [Range(1,5,ErrorMessage ="Must between 1 and 5")]
        public int degree { get; set; }
        [Range(1, 3, ErrorMessage = "Must between 1 and 3")]
        public int minDegree { get; set; }
        public int? dept_id { get; set; }
        [ForeignKey("dept_id")]
        public Department? department { get; set; }
        public ICollection<Instructor>? instructor { get; set; } = new List<Instructor>();
        public ICollection<Crs_Result>? crs_Results { get; set; }= new List<Crs_Result>();
    }
}

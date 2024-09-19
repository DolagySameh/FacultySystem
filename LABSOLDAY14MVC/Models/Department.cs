using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplication1CUG2.Validators;

namespace LABSOLDAY14MVC.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        [DisplayName("Department Name")]
        [Unique]
        public string name { get; set; }
        public string Manager { get; set; }
        public ICollection<Instructor>? instructors { get; set; } = new List<Instructor>();
        public ICollection<Course>? courses { get; set; } = new List<Course>();
        public ICollection<Trainee>? trainees { get; set; } = new List<Trainee>();

    }
}

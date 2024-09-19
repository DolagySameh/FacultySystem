using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LABSOLDAY14MVC.Models.ViewModels
{
    public class TraineeVM
    {
        public int id { get; set; }
        [MaxLength(20, ErrorMessage = "Must be less than 20")]
        [MinLength(3, ErrorMessage = "Must be more than 3")]
        [DisplayName("Trainee Name")]
        public string name { get; set; }
        public string Address { get; set; }
        public string imag { get; set; }
        public string? department { get; set; }
        public int? DeptId { get; set; }
        public List<int>? SelectedCourseIds { get; set; } = new List<int>();
        public List<CourseGradeVM>? crs_grd { get; set; } = new List<CourseGradeVM>();
        

    }
    public class CourseGradeVM
    {
        public string course;
        public int grade;
        public string color;
    }
}

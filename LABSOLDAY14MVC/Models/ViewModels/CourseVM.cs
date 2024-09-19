using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LABSOLDAY14MVC.Models.ViewModels
{
    public class CourseVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public int degree { get; set; }
        public int minDegree { get; set; }
        public string department { get; set; }
        public List<string> instructor { get; set; } = new List<string>();
        public List<string> trainees { get; set; } = new List<string>();

    }
}

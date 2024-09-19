using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LABSOLDAY14MVC.Models
{
    public class Crs_Result
    {
        [Key]
        public int id { get; set; }
        public int? degree { get; set; }
        public int? coursesid { get; set; }
        [Range(0, 100, ErrorMessage="Must Between 0 And 100")]
        public int grade { get; set; }
        public int? traineesid { get; set; }
        [ForeignKey("traineesid")]
        public Trainee? Trainee { get; set; }
        [ForeignKey("coursesid")]
        public Course? Course { get; set; }
    }
}

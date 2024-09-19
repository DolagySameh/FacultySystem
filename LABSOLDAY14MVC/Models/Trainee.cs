using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LABSOLDAY14MVC.Models
{
    public class Trainee
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20, ErrorMessage = "Must be less than 20")]
        [MinLength(3, ErrorMessage = "Must be more than 3")]
        [DisplayName("Trainee Name")]
        public string name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        public string imag { get; set; }
        public int? dept_id { get; set; }
        [ForeignKey("dept_id")]
        public Department? department { get; set; }
        public ICollection<Crs_Result>? crs_Results { get; set; } = new List<Crs_Result>();

    }
}

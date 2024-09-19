using LABSOLDAY14MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1CUG2.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            C_TContext db = new C_TContext ();
            if (db.departments.Any(e => e.name == value as string) || db.courses.Any(e => e.name == value as string)) 
            {
                return new ValidationResult("Name Already Exist !!!");
            }
            return ValidationResult.Success;

        }
    }
}

using LABSOLDAY14MVC.Models;
using LABSOLDAY14MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABSOLDAY14MVC.Controllers
{
    public class DepartmentController : Controller
    {
        C_TContext _TContext = new C_TContext();
        public IActionResult getAllDepartments()
        {
            var depart = _TContext.departments.ToList();
            return View(depart);
        }
        public IActionResult getSpecificDepartment(int id)
        {
            var dept = _TContext.departments.Include(c => c.courses).Include(i => i.instructors).Include(t => t.trainees).FirstOrDefault(x => x.id == id);
            return View(dept);
        }
        public IActionResult NewDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNewDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _TContext.departments.Add(department);
                _TContext.SaveChanges();
                return RedirectToAction("getAllDepartments");
            }
            return View("NewDepartment");
        }
        public IActionResult UpdateDept(int id)
        {
            var dept = _TContext.departments.Find(id);
            return View(dept);
        }
        public IActionResult SaveUpdateDept(Department department)
        {
            if (ModelState.IsValid)
            {
                _TContext.departments.Update(department);
                _TContext.SaveChanges();
                return RedirectToAction("getAllDepartments");
            }
            return View("UpdateDept");
        }
        public IActionResult DeleteDept(int id)
        {
            var dept = _TContext.departments
            .Include(d => d.instructors)
            .Include(d => d.courses)
            .FirstOrDefault(d => d.id == id);
            foreach (var instructor in dept.instructors.ToList())
            {
                _TContext.instructors.Remove(instructor);
            }
            foreach (var crsResult in dept.courses.ToList())
            {
                _TContext.courses.Remove(crsResult);
            }
            foreach (var trn in dept.courses.ToList())
            {          
                _TContext.courses.Remove(trn);
            }
            _TContext.departments.Remove(dept);
            _TContext.SaveChanges();

            return RedirectToAction("getAllDepartments");
        }
    }
}

using LABSOLDAY14MVC.Models;
using LABSOLDAY14MVC.Models.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABSOLDAY14MVC.Controllers
{
    public class CourseController : Controller
    {
        C_TContext _TContext = new C_TContext();
        public IActionResult GetAllCourses()
        {
           var crs = _TContext.courses.Include(d => d.department).ToList();
            return View(crs);
        }
        public IActionResult GetSpecificCourse(int id)
        {
            var crs = _TContext.courses.Include(d => d.department)
                .Include(i => i.instructor).Include(t => t.crs_Results).ThenInclude(cr => cr.Trainee).FirstOrDefault(e => e.id == id);
            CourseVM courseVM = new CourseVM();
            courseVM.id = id;
            courseVM.name = crs.name;
            courseVM.degree = crs.degree;
            courseVM.minDegree  = crs.minDegree;
            courseVM.department = crs.department.name;
            foreach(var inst in crs.instructor)
            {
                courseVM.instructor.Add(inst.name);
            }
            foreach(var trainee in crs.crs_Results.Select(t=>t.Trainee))
            {
                courseVM.trainees.Add(trainee.name);
            }
            return View(courseVM);
        }
        public IActionResult NewCrs()
        {
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewCrs(Course course)
        {
            if (ModelState.IsValid)
            {
                _TContext.courses.Add(course);
                _TContext.SaveChanges();
                return RedirectToAction("GetAllCourses");
            }
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View("NewCrs", course);
        }
        //[Route("/Course/UpdateCrs/{id}")]
        public IActionResult UpdateCrs(int id)
        {
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var crs = _TContext.courses.Find(id);
            return View(crs);
        }
        [HttpPost]
        public IActionResult SaveUpdateCrs(Course course)
        {
            if (ModelState.IsValid)
            {
                _TContext.courses.Update(course);
                _TContext.SaveChanges();
                return RedirectToAction("GetAllCourses");
            }
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View("UpdateCrs", course);
        }
        
        public IActionResult DeleteCrs(int id)
        {
            var crs = _TContext.courses.Include(c => c.instructor).FirstOrDefault(c => c.id == id);
            if (crs != null)
            {
                foreach (var instructor in crs.instructor.ToList())
                {
                    _TContext.instructors.Remove(instructor);
                }
                _TContext.courses.Remove(crs);
                _TContext.SaveChanges();
            }
            return RedirectToAction("GetAllCourses");
        }
    }
}

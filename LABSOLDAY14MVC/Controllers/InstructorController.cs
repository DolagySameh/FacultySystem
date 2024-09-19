using LABSOLDAY14MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABSOLDAY14MVC.Controllers
{
    public class InstructorController: Controller
    {
        C_TContext _TContext = new C_TContext();
        public IActionResult getAllInstructor()
        {
            var Allinstructor = _TContext.instructors.ToList();
            return View(Allinstructor);
        }
        public IActionResult getSpecificInstructor(int id)
        {
            var specificInstructor = _TContext.instructors.Include(e => e.department).Include(c => c.course).FirstOrDefault(e => e.id == id);
            return View(specificInstructor);

        }
        public IActionResult NewInst()
        {
            var crs = _TContext.courses.ToList();
            ViewBag.courses = crs;
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewInst(Instructor instructor)
        {
            if(ModelState.IsValid)
            {
                _TContext.instructors.Add(instructor);
                _TContext.SaveChanges();
                return RedirectToAction("getAllInstructor");
            }
            var crs = _TContext.courses.ToList();
            ViewBag.courses = crs;
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View("NewInst", instructor);  
        }
        
        public IActionResult UpdateInst(int id)
        {
            var crs = _TContext.courses.ToList();
            ViewBag.courses = crs;
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var inst = _TContext.instructors.Find(id);
            return View(inst);
        }
        [HttpPost]
        public IActionResult SaveUpdateInst(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _TContext.instructors.Update(instructor);
                _TContext.SaveChanges();
                return RedirectToAction("getAllInstructor");
            }
            var crs = _TContext.courses.ToList();
            ViewBag.courses = crs;
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            return View("UpdateInst", instructor);
        }
        public IActionResult DeleteInst(int id)
        {
            var inst = _TContext.instructors.Find(id);
            _TContext.instructors.Remove(inst);
            _TContext.SaveChanges();
            return RedirectToAction("getAllInstructor");
        }
    }
}

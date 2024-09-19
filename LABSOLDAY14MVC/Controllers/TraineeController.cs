using LABSOLDAY14MVC.Models.ViewModels;
using LABSOLDAY14MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABSOLDAY14MVC.Controllers
{
    public class TraineeController : Controller
    {
        C_TContext _TContext = new C_TContext();
        public IActionResult GetAllTrainees()
        {
            var trn = _TContext.trainees.Include(d => d.department).ToList();
            return View(trn);
        }
        public IActionResult GetSpecificTrainee(int id)
        {
            var trn = _TContext.trainees.Include(d => d.department)
                       .Include(c =>c.crs_Results).ThenInclude(cr=>cr.Course)
                       .FirstOrDefault(e => e.id == id);
            TraineeVM traineeVM = new TraineeVM();
            traineeVM.id = trn.id;
            traineeVM.name = trn.name;
            traineeVM.Address = trn.Address;
            traineeVM.imag = trn.imag;
            traineeVM.department = trn.department.name;
            string color;
            foreach(var crs in trn.crs_Results)
            {
                var crsName = crs.Course.name;
                var grade = crs.grade;
                color = (grade >= 60)? "green" : "red";
                traineeVM.crs_grd.Add(new CourseGradeVM
                {
                    course = crsName,
                    grade = grade,
                    color = color
                });
            }          
            return View(traineeVM);              
        }
        public IActionResult NewTrainee()
        {
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var crs = _TContext.courses.ToList();
            ViewBag.course = crs;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewTrn(TraineeVM traineeViewModel)
        {
            if (ModelState.IsValid)
            {
                var trainee = new Trainee
                {
                    name = traineeViewModel.name,
                    Address = traineeViewModel.Address,
                    imag = traineeViewModel.imag,
                    dept_id = traineeViewModel.DeptId
                };
                _TContext.trainees.Add(trainee);
                _TContext.SaveChanges();
                foreach (var courseId in traineeViewModel.SelectedCourseIds)
                {
                    var courseResult = new Crs_Result
                    {
                        traineesid = trainee.id,
                        coursesid = courseId,
                        grade = 70 
                    };
                    _TContext.Crs_Result.Add(courseResult);
                }
                _TContext.SaveChanges();
                return RedirectToAction("GetAllTrainees");
            }
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var crs = _TContext.courses.ToList();
            ViewBag.course = crs;
            return View("NewTrainee", traineeViewModel);
        }
        public IActionResult UpdateTrn(int id)
        {
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var crs = _TContext.courses.ToList();
            ViewBag.course = crs;
            var trn = _TContext.trainees
                    .Include(t => t.department)
                    .Include(t => t.crs_Results)
                        .ThenInclude(cr => cr.Course)
                    .FirstOrDefault(t => t.id == id);
            var traineeViewModel = new TraineeVM
            {
                id = trn.id,
                name = trn.name,
                Address = trn.Address,
                imag = trn.imag,
                DeptId = trn.dept_id,
                SelectedCourseIds = trn.crs_Results.Select(cr => cr.coursesid ?? 0).ToList()
            };
            return View(traineeViewModel);
        }

        [HttpPost]
        public IActionResult SaveUpdateTrn(TraineeVM traineeViewModel)
        {
            if (ModelState.IsValid)
            {
                var trainee = _TContext.trainees
                    .Include(t => t.department)
                    .Include(t => t.crs_Results)
                        .ThenInclude(cr => cr.Course)
                    .FirstOrDefault(t => t.id == traineeViewModel.id);
                trainee.name = traineeViewModel.name;
                trainee.Address = traineeViewModel.Address;
                trainee.imag = traineeViewModel.imag;
                trainee.dept_id = traineeViewModel.DeptId;
                _TContext.trainees.Update(trainee);

                _TContext.Crs_Result.RemoveRange(trainee.crs_Results);

                foreach (var courseId in traineeViewModel.SelectedCourseIds)
                {
                    var courseResult = new Crs_Result
                    {
                        traineesid = trainee.id,
                        coursesid = courseId,
                        grade = 60
                    };
                    _TContext.Crs_Result.Update(courseResult);
                }
                _TContext.SaveChanges();
                return RedirectToAction("GetAllTrainees");
            }
            var dept = _TContext.departments.ToList();
            ViewBag.departments = dept;
            var crs = _TContext.courses.ToList();
            ViewBag.course = crs;
            return View("UpdateTrn", traineeViewModel);
        }

        public IActionResult DeleteTrn(int id)
        {
            var trn = _TContext.trainees.Find(id);
            if (trn != null)
            {
                foreach(var t in trn.crs_Results)
                {
                    _TContext.Crs_Result.Remove(t);
                    _TContext.SaveChanges();
                }
            }
            _TContext.trainees.Remove(trn);
            _TContext.SaveChanges();
            return RedirectToAction("GetAllTrainees");
        }
    }
}


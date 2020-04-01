using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            //ModelState.Clear();
            //if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            //{
            //    ModelState.AddModelError("FirstName","Please enter first name");
            //}
            //if (string.IsNullOrEmpty(studentVM.Student.LastName))
            //{
            //    ModelState.AddModelError("LastName", "Please enter last name");
            //}
            //if (string.IsNullOrEmpty(studentVM.Student.GPA.ToString()))
            //{
            //    ModelState.AddModelError("GPA","Please enter GPA");
            //}
            //if (string.IsNullOrEmpty(studentVM.Student.Major.MajorId.ToString()) || studentVM.Student.Major.MajorId == 0)
            //{
            //    ModelState.AddModelError("MajorId", "Please select major");
            //}
            //if (studentVM.SelectedCourseIds.Count <= 0)
            //{
            //    ModelState.AddModelError("SelectedCourseIds", "Please select Courses");
            //}

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
               
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);
            var studentVM = new StudentVM();
            studentVM.Student = student;
            studentVM.SetCourseItems(CourseRepository.GetAll());
            if (student.Courses!=null)
            {
                studentVM.SelectedCourseIds = (from course in student.Courses
                                               select course.CourseId).ToList();
            }
            studentVM.Student.Major = student.Major; 
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());

            return View(studentVM);
        }


        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}
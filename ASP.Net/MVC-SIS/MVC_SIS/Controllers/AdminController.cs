using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("MajorName", "Please enter major name");
            }
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("MajorName","Please enter major name");
            }
            if (ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        // Methods for States
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrEmpty(state.StateAbbreviation))
            {
                ModelState.AddModelError("StateAbbreviation","Please enter state abbreviation");
            }
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName","Please enter state name");
            }

            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateAbbreviation))
            {
                ModelState.AddModelError("StateAbbreviation",
                    "Please enter state abbreviation");
            }

            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName",
                    "Please enter state name");
            }

            if (ModelState.IsValid)
            {
                // here we would save the appointment to a database
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
            else
            {
                // send them back to the entry form
                return View(state);
            }
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        /// <summary>
        /// Course Actions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                ModelState.AddModelError("CourseName",
                    "Please enter course name");
            }

            if (ModelState.IsValid)
            {
                // here we would save the appointment to a database
                CourseRepository.Add(courseName);
                return RedirectToAction("Courses");
            }
            else
            {
                // send them back to the entry form
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("CourseName","Please enter course name");
            }
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}
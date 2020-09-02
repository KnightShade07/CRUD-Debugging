using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWithIssuesCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithIssuesCore.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Students()
        {
            List<Student> students = StudentDb.GetStudents(context);
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                //Add the student to the DB
                StudentDb.Add(s, context);
                TempData["Message"] = $"{s.Name} was added!";
                //Redirects the user to the students page
                //after a student is added
                return RedirectToAction("Students");
            }

            //Show web page with errors
            return View(s);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get the student by id
            Student s = StudentDb.GetStudent(context, id);

            //show the student on the web page
            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                //updates a student in the database.
                StudentDb.Update(context, s);
                //use TempData instead of ViewData here,
                //because the message will not display, otherwise
                TempData["Message"] = "The Student was updated successfully!";
                return RedirectToAction("Students");
            }
            //return view with errors
            return View(s);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student s = StudentDb.GetStudent(context, id);
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Get the student to be deleted from the database.
            Student s = StudentDb.GetStudent(context, id);
            //Delete the student from the Database.
            StudentDb.Delete(context, s);

            return RedirectToAction("Students");
        }

        //The details IActionResult was missing from the original project.
        public IActionResult Details(int id)
        {
            //This view is readonly.
            //Get the student to be displayed on the page
             Student s = StudentDb.GetStudent(context, id);
            return View(s);
        }
    }
}
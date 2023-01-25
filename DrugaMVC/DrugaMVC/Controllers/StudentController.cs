using DrugaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrugaMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentList = new List<Student>{
            new Student() { Id = 1, Ime = "John", Starost = 18 } ,
            new Student() { Id = 2, Ime = "Steve", Starost = 21 } ,
            new Student() { Id = 3, Ime = "Bill", Starost = 25 } ,
            new Student() { Id = 4, Ime = "Ram" , Starost = 20 } ,
            new Student() { Id = 5, Ime = "Ron" , Starost = 31 } ,
            new Student() { Id = 4, Ime = "Chris" , Starost = 17 } ,
            new Student() { Id = 4, Ime = "Rob" , Starost = 19 }
            };

            // Get the students from the database in the real application
            return View(studentList);
        }
        public ActionResult Test_razorja()
        {
            Student miha = new Student();
            miha.Ime = "Joze jozetov";
            miha.Id = 10;
            miha.Starost = 25;

            return View();
        }

        public ActionResult Edit(int id)
        {
            var studentList = new List<Student>{
            new Student() { Id = 1, Ime = "John", Starost = 18 } ,
            new Student() { Id = 2, Ime = "Steve", Starost = 21 } ,
            new Student() { Id = 3, Ime = "Bill", Starost = 25 } ,
            new Student() { Id = 4, Ime = "Ram" , Starost = 20 } ,
            new Student() { Id = 5, Ime = "Ron" , Starost = 31 } ,
            new Student() { Id = 4, Ime = "Chris" , Starost = 17 } ,
            new Student() { Id = 4, Ime = "Rob" , Starost = 19 }
            };

            var st = studentList.Where(a => a.Id == id).FirstOrDefault();
            return View(st);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Student s = student;
                //posodobi bazo.
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
using MVC;
using MVC.Models;
using MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
        public class StudentController : Controller
    {

        public readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        private void PopulateSubjectsDropDownList (object selectedSubject = null )
        {
            var subjectsQuery = from s in _db.Subject
                                orderby s.SubjectName
                                select new {SubjectId = s.SubjectId, s.SubjectName};

           ViewBag.SubjectID = new SelectList(subjectsQuery.AsNoTracking(),"SubjectId","Subject_Name",selectedSubject);

        }

        public IActionResult Index(string searchString)
        {

            IEnumerable<Student> objList = _db.Student;

            if(!String.IsNullOrEmpty(searchString))
            {
                objList = objList.Where(s => s.StudentName.Contains(searchString));
            }
            return View(objList);
        }

        //Get Create
        public IActionResult Create()
        {
            PopulateSubjectsDropDownList(); 
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("StudentName,StudentClass")] Student studobj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Add(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studobj);
        }

        //Get Create
        public IActionResult Edit(int id)
        {
            
           var  studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Update(obj);
                _db.SaveChanges();
               return  RedirectToAction("Index");
            }
             return View(obj); 
        }

        //Get Delete
        public IActionResult Delete(int id)
        {

            var studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult DeletePost(int studentid)
        {
            var studobj = _db.Student.Find(studentid);

            if (ModelState.IsValid)
            {

                _db.Student.Remove(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studobj);
        }
    }
}
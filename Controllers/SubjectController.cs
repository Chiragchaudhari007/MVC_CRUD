using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;


namespace MVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDBContext _db;

        public SubjectController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index(string searchString)
        {

            IEnumerable<Subject> objList = _db.Subject;

            if(!String.IsNullOrEmpty(searchString))
            {
                objList = objList.Where(s => s.SubjectName.Contains(searchString));
            }
            return View(objList);
        }

       public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject subobj)
        {
            if (ModelState.IsValid)
            {
                _db.Subject.Add(subobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subobj);
        }
        
        [HttpGet]
        public IActionResult Edit(int subjectid)
        {
            var subobj = _db.Subject.Find(subjectid);
            return View(subobj);

        }

       

         [HttpPost]
        public IActionResult Edit(Subject updatedvaluesobj)
        {
            _db.Subject.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        
        [HttpGet]



        public IActionResult Delete(int subjectid)
        {
            var subobj =  _db.Subject.Find(subjectid);
            return View(subobj);
        }
        [HttpPost]
        public IActionResult  DeletePost(int subjectid)
        {
            var subobj=_db.Subject.Find(subjectid);
            if(ModelState.IsValid)
            {
                _db.Subject.Remove(subobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subobj);
        }
       
        
       
    }
}
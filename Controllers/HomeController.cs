using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCwithAdo.net.Models;
using Npgsql;

namespace MVCwithAdo.net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            StudentDbContext db = new StudentDbContext();
            List<Student> stu = db.GetStudents();
            return View(stu);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    StudentDbContext db = new StudentDbContext();
                    bool check = db.AddStudent(student);
                    if (check == true)
                    {
                        TempData["Message"] = "Data has been inserted successfully.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch 
            {
                return View();
            }
        }

        public IActionResult Edit(int id) 
        {
            StudentDbContext db = new StudentDbContext();
            var row = db.GetStudents().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    StudentDbContext db = new StudentDbContext();
                    bool check = db.UpdateStudent(student);
                    if (check == true)
                    {
                        TempData["Message"] = "Data has been updated successfully.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            StudentDbContext db = new StudentDbContext();
            var row = db.GetStudents().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public IActionResult Delete(int id, Student student)
        {
            try
            {
               
                    StudentDbContext db = new StudentDbContext();
                    bool check = db.DeleteStudent(id);
                    if (check == true)
                    {
                        TempData["Message"] = "Data has been deleted successfully.";
                        return RedirectToAction("Index");
                    }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int id) 
        {
            StudentDbContext db = new StudentDbContext();
            var row = db.GetStudents().Find(model => model.id == id);
            return View(row);
        }
    }
}

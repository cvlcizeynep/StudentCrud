using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.WebApp.Models;
using StudentRegistrationSystem.WebApp.Repository;

namespace StudentRegistrationSystem.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly BaseDbContext _baseDbContext;

        public StudentController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;//dependecy injection            
        }

        public IActionResult Index()
        {
            var students = _baseDbContext.Students.ToList();
            return View(students);

        }
        public IActionResult Delete(int id)
        {
            var student = _baseDbContext.Students.Find(id);
            _baseDbContext.Students.Remove(student);
            _baseDbContext.SaveChanges();
            return RedirectToAction("Index", "Student");

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EducationTime = new Dictionary<string, int>() {
            {"1 Month",1},
            {"3 Month",3},
            {"6 Month",6},
            {"12 Month",12 } };
          return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _baseDbContext.Students.Add(student);
            _baseDbContext.SaveChanges();
            TempData["status"] = "Add student succesfully";
            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _baseDbContext.Students.Find(id);

            return View(student);

        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _baseDbContext.Students.Update(student);
            _baseDbContext.SaveChanges();
            TempData["status"] = "Update student succesfully";
            return RedirectToAction("Index", "Student");

        }

        public IActionResult Details(int id)
        {
            Student? student = _baseDbContext.Students.SingleOrDefault(x => x.Id == id);
            return View(student);

        }


        //// İsme göre arama yapacak action methodu
        public IActionResult Search(string? name)
        {
           if (string.IsNullOrEmpty(name))
            {
             // İsim belirtilmemişse tüm verileri göster
               return View(_baseDbContext);
          }

            // İsimi içeren kayıtları filtrele
            var searchResponse = _baseDbContext.Students.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                                
              return View(searchResponse);
           }



    }
}



    


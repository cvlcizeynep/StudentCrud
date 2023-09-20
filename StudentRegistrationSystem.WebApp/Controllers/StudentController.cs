using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRegistrationSystem.WebApp.Models;
using StudentRegistrationSystem.WebApp.Models.StudentViewModel;
using StudentRegistrationSystem.WebApp.Repository;

namespace StudentRegistrationSystem.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly BaseDbContext _baseDbContext;
        private readonly IMapper _mapper;

        public StudentController(BaseDbContext baseDbContext,IMapper mapper)
        {
            _baseDbContext = baseDbContext;//dependecy injection
            _mapper = mapper;                               
        }

        public IActionResult Index()
        {
            var students = _baseDbContext.Students.ToList();

            return View(_mapper.Map<List<StudentViewModel>>(students));

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
            {"12 Month",12 }
            };


            ViewBag.DepartmentSelect = new SelectList(new List<SelectDepartment>() {
                new(){ Data="Yapay Zeka",Value="Yapay Zeka"},
                new(){Data="BackEnd",Value="BackEnd"},
                new(){Data="FrontEnd",Value="FronEnd"},
                new(){Data="Qality Assurance",Value="Qality Assurance"},
                new(){Data="Syber Security",Value="Syber Security"} }, "Value", "Data");

            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                _baseDbContext.Students.Add(_mapper.Map<Student>(student));
                _baseDbContext.SaveChanges();
                TempData["status"] = "Add student succesfully";
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ViewBag.EducationTime = new Dictionary<string, int>() {
            {"1 Month",1},
            {"3 Month",3},
            {"6 Month",6},
            {"12 Month",12 }
            };


                ViewBag.DepartmentSelect = new SelectList(new List<SelectDepartment>() {
                new(){ Data="Yapay Zeka",Value="Yapay Zeka"},
                new(){Data="BackEnd",Value="BackEnd"},
                new(){Data="FrontEnd",Value="FronEnd"},
                new(){Data="Qality Assurance",Value="Qality Assurance"},
                new(){Data="Syber Security",Value="Syber Security"} }, "Value", "Data");

                return View();              

            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _baseDbContext.Students.Find(id);
            
            ViewBag.EducationTime = new Dictionary<string, int>() {
            {"1 Month",1},
            {"3 Month",3},
            {"6 Month",6},
            {"12 Month",12 }
            };
            ViewBag.radioEducationTime = student.EducationTime;

            ViewBag.DepartmentSelect = new SelectList(new List<SelectDepartment>() {
                new(){ Data="Yapay Zeka",Value="Yapay Zeka"},
                new(){Data="BackEnd",Value="BackEnd"},
                new(){Data="FrontEnd",Value="FronEnd"},
                new(){Data="Qality Assurance",Value="Qality Assurance"},
                new(){Data="Syber Security",Value="Syber Security"} }, "Value", "Data",student.Department);

            return View(student);




            

        }
        [HttpPost]
        public IActionResult Update(StudentViewModel student)
        {
            _baseDbContext.Students.Update(_mapper.Map<Student>(student));
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



        


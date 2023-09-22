using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationSystem.WebApp.Models;

using StudentRegistrationSystem.WebApp.Repository;
using StudentRegistrationSystem.WebApp.ViewModels;
using System.Diagnostics;

namespace StudentRegistrationSystem.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly BaseDbContext _baseDbContext;
        private readonly IMapper _mapper;

        public HomeController(BaseDbContext baseDbContext, IMapper mapper)
        {
            _baseDbContext = baseDbContext;//dependecy injection
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
         {
           
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminViewModel admin)
        {
           
            if (ModelState.IsValid)
            {           

                return RedirectAction("Index", "Student");
            }
            else
            {
                if (!string.IsNullOrEmpty(admin.AdminName)&&!admin.AdminName.Contains("admin")){

                    ModelState.AddModelError(String.Empty, "Invalid Admin");
                }
                return View();
            }
        }

        public IActionResult Lotus()
        {
            var students = _baseDbContext.Students.OrderByDescending(x => x.Id).Select(x => new StudentPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Department = x.Department
            }

            ).ToList();
            ViewBag.studentListPartialViewModel = new StudentListPartialViewModel()
            {
                Students=students

            };
            return View();
        }



        private IActionResult RedirectAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
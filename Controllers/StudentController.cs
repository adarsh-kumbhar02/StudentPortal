using Microsoft.AspNetCore.Mvc;
namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message="Welcome to Student Portal";
            ViewBag.Today=DateTime.Now.ToShortDateString();
            ViewData["StudentCount"]=10;
            return View();
        }

        public IActionResult Details(int id)
        {
           Dictionary<int , string> students= new Dictionary<int, string>()
           {
               {101,"Adarsh"},
               {102,"Rohit"},
               {103,"Sahil"},
               {104,"Aaditi"},
               {105,"Vyankatesh"}
           };

            if (students.ContainsKey(id))
            {
                ViewBag.Message=$"ID: {id}, Name:{students[id]}";
            }
            else
            {
                ViewBag.Message=$"Student ID {id} doesn't exist.";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int age, string course)
        {
            ViewBag.Name=name;
            ViewBag.Age=age;
            ViewBag.Course=course;
            return View("Confirmation");
        }

        [Route("students/all")]
        public IActionResult AllStudents(){
            List <string> students=new List<string>()
            {
               "Adarsh", "Rohit", "Sahil", "Aaditi", "Vyankatesh"
            };

            return View(students);
        }
    }
}
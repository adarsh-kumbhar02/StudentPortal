using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Controllers{
public class StudentController : Controller
{
    private readonly StudentPortalContext _context;

    public StudentController(StudentPortalContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.WelcomeMessage = "Welcome to Student Portal";
        ViewBag.Today = DateTime.Now.ToShortDateString();
        ViewData["StudentCount"] = _context.Students.Count();
        return View();
    }

    public IActionResult Details(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string name, int age, string course)
    {
        var student = new Student { Name = name, Age = age, Course = course };
        _context.Students.Add(student);
        _context.SaveChanges();

        ViewBag.Message = $"Student {name} added!";
        return View("Confirmation");
    }

    [Route("students/all")]
    public IActionResult AllStudents()
    {
        var students = _context.Students.ToList();
        return View(students);
    }
    }
}
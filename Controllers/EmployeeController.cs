
using Exam_sem3.Entities;
using Exam_sem3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam_sem3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        // GET: DepartmentController1
        public ActionResult Index()
        {
            List<Employee> ls = _context.Employees.ToList();
            return View(ls);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {

                // save to db
                _context.Employees.Add(new Employee
                {
                    Name = model.Name,
                    Code = model.Code,
                    Rank = model.Rank,
                    DepartmentId = model.DepartmentId
                });
                _context.SaveChanges();

                // redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
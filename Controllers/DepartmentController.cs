using Exam_sem3.Entities;
using Exam_sem3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_sem3.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }
        // GET: DepartmentController1
        public ActionResult Index()
        {
            List<Department> ls = _context.Departments.ToList();
            return View(ls);
        }

        // GET: DepartmentController1/Details/5


        // GET: DepartmentController1/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {

                // save to db
                _context.Departments.Add(new Department
                {
                    Name = model.Name,
                    Code = model.Code,
                    Location = model.Location
                });
                _context.SaveChanges();

                // redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();
            return View(new DepartmentModel { Id = department.Id, Name = department.Name, Code = department.Code, Location = department.Location });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(new Department
                {
                    Id = model.Id,
                    Name = model.Name,
                    Code = model.Code,
                    Location = model.Location
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public IActionResult Delete(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using Exam_sem3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_sem3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        

        // Action để hiển thị form thêm mới nhân viên
        public IActionResult Create(int departmentId)
        {
            ViewBag.DepartmentId = departmentId;
            return View();
        }

        // Action để xử lý thêm mới nhân viên
        [HttpPost]
        public IActionResult Create(int departmentId, Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.DepartmentId = departmentId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { departmentId });
            }

            ViewBag.DepartmentId = departmentId;
            return View(employee);
        }
    }
}

using Exam_sem3.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_sem3.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        // Action để hiển thị danh sách phòng ban
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // Action để hiển thị form thêm mới phòng ban
        public IActionResult Create()
        {
            return View();
        }

        // Action để xử lý thêm mới phòng ban
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Action để hiển thị form chỉnh sửa phòng ban
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // Action để xử lý chỉnh sửa phòng ban
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Action để hiển thị form xóa phòng ban
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // Action để xử lý xóa phòng ban
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // Action để hiển thị báo cáo và thống kê nhân viên trong một phòng ban
        
    }
}

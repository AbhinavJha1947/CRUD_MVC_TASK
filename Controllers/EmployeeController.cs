using CRUD_MVC_TASK.DAL;
using CRUD_MVC_TASK.Models;
using Microsoft.AspNetCore.Mvc;
namespace CRUD_MVC_TASK.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL _empDAL;

        public EmployeeController(EmployeeDAL empDAL)
        {
            _empDAL = empDAL;
        }

        public IActionResult Index()
        {
            List<Employee> employees = _empDAL.GetAllEmployees() ?? new List<Employee>(); // Ensure it's not null
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empDAL.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public IActionResult Edit(int id)
        {
            Employee emp = _empDAL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empDAL.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = _empDAL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _empDAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}

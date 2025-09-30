using CoreApp.Data;
using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreApp.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.Include("Department").ToList();
            return View(employees);

        }
        public IActionResult Add()
        {
            List<Department> depts = _context.Departments.ToList();
            ViewBag.Department = depts;
            return View();
        }
        [HttpPost]
        public IActionResult Save(Employee emp)
        {
            if(emp.Id==0)
            {
                _context.Employees.Add(emp);
            }
            else if(emp.Id>0)
            {
                Employee empInDb = _context.Employees.Where(e => e.Id ==emp.Id).SingleOrDefault();
                if(empInDb!=null)
                {
                    empInDb.Name = emp.Name;
                    empInDb.Email = emp.Email;
                    empInDb.Mobile = emp.Mobile;
                    empInDb.SkillSet = emp.SkillSet;
                    empInDb.Password = emp.Password;
                    empInDb.Department = emp.Department;

                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
           Employee empInDb= _context.Employees.Where(e=>e.Id==id).SingleOrDefault();
            List<Department> depts = _context.Departments.ToList();
            ViewBag.Department = depts;
            return View("Add",empInDb);
        }
        public IActionResult Delete(int id)
        {
            Employee empInDb = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            _context.Employees.Remove(empInDb);
            _context.SaveChanges();
            return RedirectToAction("Index") ;
        }
        public IActionResult ChangePassword(int id)
        {
            Employee empInDb = _context.Employees.Where(e => e.Id == id).SingleOrDefault();  
            ViewBag.EmployeeId = id;
            return View("ChangePassword", empInDb);

        }
        

        [HttpPost]
        public IActionResult UpdatePassword(Employee emp)
        {
            string currentPasswordTyped = Request.Form["CurrentPassword"];
            string confirmNewPassword = Request.Form["ConfirmNewPassword"];

            Employee empInDb = _context.Employees.Where(e => e.Id == emp.Id).SingleOrDefault();

            if (empInDb != null)
            {
                if (empInDb.Password != currentPasswordTyped)
                {
                    ViewBag.LoginMessage = "Current password is incorrect.";
                    return View("ChangePassword", empInDb);
                }

                if (emp.Password != confirmNewPassword)
                {
                    ViewBag.LoginMessage = "New password and confirmation do not match.";
                    return View("ChangePassword", empInDb);
                }
            }
            empInDb.Password = emp.Password;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

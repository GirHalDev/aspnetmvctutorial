using ControllersMVCVTP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Controller VT P4, View P5, ViewData and ViewBag P6, Models P7

namespace ControllersMVCVTP4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details() //Hard coding
        {
            Employee employee = new Employee()
            {
                ID = 101,
                FirstName = "John",
                LastName = "Myth",
                Gender = "Male",
                DepartmentId = 1
            };
            return View(employee);
        }

        //Using database
        public ActionResult DatabaseDetails(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee1 = employeeContext.Employees.Single(emp => emp.ID == id);

            return View(employee1);    
        }

        //Hyperlinks using actionlink html helper
        public ActionResult Index(int departmentId) //Hard coding
        {
            EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employees.ToList();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();

            return View(employees);
        }
    }
}
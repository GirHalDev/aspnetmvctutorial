using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayers;

namespace ControllersMVCVTP4.Controllers
{
    public class BusinessLayerController : Controller
    {
        // GET: BusinessLayer
        public ActionResult Index()
        {
            EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
            List<Employee> employees = employeeBusinesslayer.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            //foreach (string key in formCollection.AllKeys)
            //{
            //    Response.Write("Key = " + key + " ");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br/>");
            //}

            //Adding it back to the database Employee 
            Employee employee = new Employee();
            employee.FirstName = formCollection["FirstName"];
            employee.LastName = formCollection["lastName"];
            employee.Gender = formCollection["Gender"];
            employee.Salary = formCollection["Salary"];
            employee.DepartmentId = formCollection["DepartmentId"];

            EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
            employeeBusinesslayer.AddEmployee(employee);

            return RedirectToAction("Index");
        }
    }
}
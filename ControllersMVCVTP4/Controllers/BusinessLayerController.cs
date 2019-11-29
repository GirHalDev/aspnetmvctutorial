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

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    //foreach (string key in formCollection.AllKeys)
        //    //{
        //    //    Response.Write("Key = " + key + " ");
        //    //    Response.Write(formCollection[key]);
        //    //    Response.Write("<br/>");
        //    //}

        //    //Adding it back to the database Employee 
        //    Employee employee = new Employee();
        //    employee.FirstName = formCollection["FirstName"];
        //    employee.LastName = formCollection["lastName"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.Salary = formCollection["Salary"];
        //    employee.DepartmentId = formCollection["DepartmentId"];

        //    EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //    employeeBusinesslayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //}

        //Another way of adding data into employee table. Using parameter that is connected using model binding.
        //the parameter name must match with the name of the browser input but the parameter order does not matter
        //[HttpPost]
        //public ActionResult Create(string firstName, string lastName, string gender, string salary, string departmentID)
        //{

        //    //Adding it back to the database Employee 
        //    Employee employee = new Employee();
        //    employee.FirstName = firstName;
        //    employee.LastName = lastName;
        //    employee.Gender = gender;
        //    employee.Salary = salary;
        //    employee.DepartmentId = departmentID;

        //    EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //    employeeBusinesslayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //}

        ////Another easier way to avoid writing too many parameters
        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //        employeeBusinesslayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}

        //Another way without using parameter which becomes identical with the create action method of post 
        //in type and number of parameter. However, using an attribute ActionName("Create") and renaming the method would respond to the create post of the view
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    Employee employee = new Employee();

        //    //Inspects Http request inputs, such as posted form data, QueryString, Cookies, and server variables
        //    //and populate the employee object
        //    //Throws an exception if validation fails
        //    //UpdateModel(employee);

        //    //Will never throw an exception
        //    TryUpdateModel(employee);


        //    if (ModelState.IsValid)
        //    {

        //        EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //        employeeBusinesslayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}

        //Without using UpdatModel() or TryUpdateModel() methods 
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Employee employee)
        {

            if (ModelState.IsValid)
            {

                EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
                employeeBusinesslayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
            Employee employee = employeeBusinesslayer.Employees.Single(emp => emp.ID == id);
            return View(employee);

        }

        //This model binding method is vernerable for hack using a tool like Fiddler
        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    //Model state checks if all the required fields decorated by the required attribute are filled
        //    if(ModelState.IsValid)
        //    {
        //        EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //        employeeBusinesslayer.SaveEmployee(employee);
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);

        //}

        //Another method of model binding to avoid hacking or unintended updates
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //    Employee employee = employeeBusinesslayer.Employees.Single(x => x.ID == id);

        //    //Include and Exclude list overloaded parameters to prevent model binding using a tool like Fiddler
        //    UpdateModel(employee, new string[] { "ID", "LastName", "Gender", "Salary", "DepartementId", "DateOfBirth" });

        //    //Exclude list parameter 
        //    // UpdateModel(employee, null, null, new string[] { "FirstName" });

        //    //Model state checks if all the required fields decorated by the required attribute are filled
        //    if (ModelState.IsValid)
        //    {

        //        employeeBusinesslayer.SaveEmployee(employee);
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);

        //}

        //Another method of model binding to avoid hacking or unintended updates: Using Bind Attribute
        //In this method the required field on Employee.cs FirstName can be deleted to avoid required field checking, or
        //
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include="ID, LastName, Gender, Salary, DepartementId, DateOfBirth")]Employee employee)
        //{
        //    EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //    employee.FirstName = employeeBusinesslayer.Employees.Single(x => x.ID == employee.ID).FirstName;
        //    employee.DepartmentId = employeeBusinesslayer.Employees.Single(x => x.ID == employee.ID).DepartmentId;

        //    //Model state checks if all the required fields decorated by the required attribute are filled
        //    if (ModelState.IsValid)
        //    {

        //        employeeBusinesslayer.SaveEmployee(employee);
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);

        //}

        //Another method of model binding to avoid hacking or unintended updates: Using Interface IEmployee
        //In this method the required field on Employee.cs FirstName can be deleted to avoid required field checking,
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
            Employee employee = employeeBusinesslayer.Employees.Single(x => x.ID == id);

            UpdateModel<IEmployee>(employee);

            //Model state checks if all the required fields decorated by the required attribute are filled
            if (ModelState.IsValid)
            {

                employeeBusinesslayer.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);

        }

        ////An action method for delete using Get Request 
        //public ActionResult Delete(int id)
        //{
        //    //< img src = "http://localhost/ControllersMVCVTP4/BusinessLayer/Delete/32" />
        //    //This html tag with maliceous address can delete the data from the database
        //    //Therefore Deleteing data using Get Request is not recommended by Microsoft
        //    //In addition, when search engines index your page, they issue a GET request
        //    //Which will delete the data

        //    //In general, GET Request should be free of any side effects(It should not change the state)
        //    //Delete should be performed using POST Request.

        //    EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
        //    employeeBusinesslayer.DeleteEmployee(id);
        //    return RedirectToAction("Index");

        //}

        //Deleting using POST Request
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //< img src = "http://localhost/ControllersMVCVTP4/BusinessLayer/Delete/32" />
            //This html tag with maliceous address can delete the data from the database
            //Therefore Deleteing data using Get Request is not recommended by Microsoft
            //In addition, when search engines index your page, they issue a GET request
            //Which will delete the data

            //In general, GET Request should be free of any side effects(It should not change the state)
            //Delete should be performed using POST Request.

            EmployeeBusinesslayer employeeBusinesslayer = new EmployeeBusinesslayer();
            employeeBusinesslayer.DeleteEmployee(id);
            return RedirectToAction("Index");

        }
    }
}
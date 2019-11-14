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
    }
}
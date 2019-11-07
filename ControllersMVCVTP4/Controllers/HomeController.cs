using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

///Controller VT P4, View P5, ViewData and ViewBag P6, Models P7
namespace ControllersMVCVTP4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index(string id, string name) //ControllerActionMethod
        {
            //http://localhost/ControllersMVCVTP4/home/index/10?name=Pragim 
            //when it is deployed on Localhost IIS Server
            //return "id = " + id + "Name = " + Request.QueryString["name"];
            return "id = " + id + "Name = " + name;
        }

        public ActionResult ListCountriesView() //ControllerActionMethod
        {
            //ViewBag stores in a Dynamic Property Countries created on the run
            //Dynamic properties do not provide Compile time error checking
            ViewBag.Countries = new List<string>()
            {
                "India", 
                "US",
                "UK",
                "Canada"
            };
            return View();
        }

        public ActionResult ListCountries() //ControllerActionMethod
        {
            //ViewData stores in Key Value
            //ViewData also do not provide Compile time error checking if the key miss spelled
            ViewData["Countries"] = new List<string>()
            {
                "Ethiopia",
                "Egypt",
                "South Africa",
                "Kenya"
            };
            return View();
        }

        public string GetDetails()
        {
            return "Get Details Method Invoked ";
        }
    }
}
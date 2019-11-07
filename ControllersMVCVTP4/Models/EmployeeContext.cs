using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControllersMVCVTP4.Models
{
    //This class enable the connection between the database and the webpage
    //using connectionString on the Web.config file
    public class EmployeeContext : DbContext
    {
        //Using the property Employee, we get Database set of employees
        public DbSet<Employee> Employees { get; set; }
    }
}
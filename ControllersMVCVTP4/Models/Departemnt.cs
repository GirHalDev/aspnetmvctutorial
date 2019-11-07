using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControllersMVCVTP4.Models
{
    //Working with Multiple tables VT P10
    [Table("Department")] //Mapping to a Department table on the databases
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //A department can have multiple employees, (One to many relationship) 
        public List<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControllersMVCVTP4.Models
{
    [Table("Employee")] //TableAttribute specifies the database table that a Model class is mapped to
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Data Annotations namespace

namespace BusinessLayers
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public string DepartmentId { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Data Annotations namespace

namespace BusinessLayers
{
    //Using Interface to exclude the FirstName from updating 
    //so that no outside debugging tool can update it malecously.
    public interface IEmployee
    {
        int ID { get; set; }
        string LastName { get; set; }
        string Gender { get; set; }
        string Salary { get; set; }
        string DepartmentId { get; set; }
        DateTime? DateOfBirth { get; set; }
    }

    public class Employee : IEmployee
    {
        public int ID { get; set; }
        //[Required]
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

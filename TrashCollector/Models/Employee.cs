using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

    }
}

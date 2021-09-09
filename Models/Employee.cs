using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnEFApplication.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentNumber { get; set; }
        [ForeignKey("DepartmentNumber")]
        public Department Department { get; set; }
    }
}

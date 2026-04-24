using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
    }
}

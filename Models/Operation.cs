using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Models
{
    public class Operation
    {
        public int OperationID { get; set; }
        public int EquipmentID { get; set; }
        public int OperationTypeID { get; set; }
        public int? EmployeeID { get; set; }
        public int? FromDepartmentID { get; set; }
        public int? ToDepartmentID { get; set; }
        public DateTime OperationDate { get; set; }
        public string Comment { get; set; }
    }
}

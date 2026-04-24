using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public int DepartmentID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }
    }
}

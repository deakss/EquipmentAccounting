using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentAccounting.Models;

namespace EquipmentAccounting.Services
{

    public class EquipmentService
    {
        // ================= EQUIPMENT =================

        public int GetTotalEquipmentCount()
        {
            object result = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Equipment");
            return Convert.ToInt32(result);
        }

        public int GetEquipmentCountByStatus(string statusName)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Equipment e
        INNER JOIN Statuses s ON e.StatusID = s.StatusID
        WHERE s.Name = @StatusName";

            object result = DbHelper.ExecuteScalar(query,
                new SqlParameter("@StatusName", statusName));

            return Convert.ToInt32(result);
        }

        public DataTable GetEquipment()
        {
            string query = @"
            SELECT 
                e.EquipmentID,
                e.Name,
                e.InventoryNumber,
                e.SerialNumber,
                e.CategoryID,
                c.Name AS CategoryName,
                e.StatusID,
                s.Name AS StatusName,
                e.DepartmentID,
                d.Name AS DepartmentName,
                e.EmployeeID,
                emp.FullName AS EmployeeName,
                e.PurchaseDate,
                e.Cost,
                e.Description
            FROM Equipment e
            JOIN Categories c ON e.CategoryID = c.CategoryID
            JOIN Statuses s ON e.StatusID = s.StatusID
            JOIN Departments d ON e.DepartmentID = d.DepartmentID
            LEFT JOIN Employees emp ON e.EmployeeID = emp.EmployeeID
            ORDER BY e.Name";

            return DbHelper.ExecuteQuery(query);
        }

        public void AddEquipment(Equipment eq)
        {
            string query = @"
            INSERT INTO Equipment
            (Name, InventoryNumber, SerialNumber, CategoryID, StatusID, DepartmentID, EmployeeID, PurchaseDate, Cost, Description)
            VALUES
            (@Name, @InventoryNumber, @SerialNumber, @CategoryID, @StatusID, @DepartmentID, @EmployeeID, @PurchaseDate, @Cost, @Description)";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@Name", eq.Name),
                new SqlParameter("@InventoryNumber", eq.InventoryNumber),
                new SqlParameter("@SerialNumber", (object)eq.SerialNumber ?? DBNull.Value),
                new SqlParameter("@CategoryID", eq.CategoryID),
                new SqlParameter("@StatusID", eq.StatusID),
                new SqlParameter("@DepartmentID", eq.DepartmentID),
                new SqlParameter("@EmployeeID", (object)eq.EmployeeID ?? DBNull.Value),
                new SqlParameter("@PurchaseDate", (object)eq.PurchaseDate ?? DBNull.Value),
                new SqlParameter("@Cost", (object)eq.Cost ?? DBNull.Value),
                new SqlParameter("@Description", eq.Description)
            );
        }

        public void UpdateEquipment(Equipment eq)
        {
            string query = @"
            UPDATE Equipment SET
                Name = @Name,
                InventoryNumber = @InventoryNumber,
                SerialNumber = @SerialNumber,
                CategoryID = @CategoryID,
                StatusID = @StatusID,
                DepartmentID = @DepartmentID,
                EmployeeID = @EmployeeID,
                PurchaseDate = @PurchaseDate,
                Cost = @Cost,
                Description = @Description
            WHERE EquipmentID = @EquipmentID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@EquipmentID", eq.EquipmentID),
                new SqlParameter("@Name", eq.Name),
                new SqlParameter("@InventoryNumber", eq.InventoryNumber),
                new SqlParameter("@SerialNumber", (object)eq.SerialNumber ?? DBNull.Value),
                new SqlParameter("@CategoryID", eq.CategoryID),
                new SqlParameter("@StatusID", eq.StatusID),
                new SqlParameter("@DepartmentID", eq.DepartmentID),
                new SqlParameter("@EmployeeID", (object)eq.EmployeeID ?? DBNull.Value),
                new SqlParameter("@PurchaseDate", (object)eq.PurchaseDate ?? DBNull.Value),
                new SqlParameter("@Cost", (object)eq.Cost ?? DBNull.Value),
                new SqlParameter("@Description", eq.Description)
            );
        }

        public void DeleteEquipment(int id)
        {
            DbHelper.ExecuteNonQuery(
                "DELETE FROM Equipment WHERE EquipmentID = @id",
                new SqlParameter("@id", id));
        }

        // ================= CATEGORIES =================

        public DataTable GetCategories()
        {
            return DbHelper.ExecuteQuery("SELECT * FROM Categories ORDER BY Name");
        }

        public void AddCategory(Category cat)
        {
            DbHelper.ExecuteNonQuery(
                "INSERT INTO Categories(Name) VALUES(@name)",
                new SqlParameter("@name", cat.Name));
        }

        public void UpdateCategory(Category cat)
        {
            DbHelper.ExecuteNonQuery(
                "UPDATE Categories SET Name=@name WHERE CategoryID=@id",
                new SqlParameter("@id", cat.CategoryID),
                new SqlParameter("@name", cat.Name));
        }

        public void DeleteCategory(int id)
        {
            DbHelper.ExecuteNonQuery(
                "DELETE FROM Categories WHERE CategoryID=@id",
                new SqlParameter("@id", id));
        }

        // ================= STATUSES =================

        public DataTable GetStatuses()
        {
            return DbHelper.ExecuteQuery("SELECT * FROM Statuses ORDER BY Name");
        }

        public void AddStatus(Status stat)
        {
            DbHelper.ExecuteNonQuery(
                "INSERT INTO Statuses(Name) VALUES(@name)",
                new SqlParameter("@name", stat.Name));
        }

        public void UpdateStatus(Status stat)
        {
            DbHelper.ExecuteNonQuery(
                "UPDATE Statuses SET Name=@name WHERE StatusID=@id",
                new SqlParameter("@id", stat.StatusID),
                new SqlParameter("@name", stat.Name));
        }

        public void DeleteStatus(int id)
        {
            DbHelper.ExecuteNonQuery(
                "DELETE FROM Statuses WHERE StatusID=@id",
                new SqlParameter("@id", id));
        }
    }
}

using EquipmentAccounting.Data;
using EquipmentAccounting.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EquipmentAccounting.Services
{
    public class OperationService
    {
        public DataTable GetOperations()
        {
            string query = @"
                SELECT 
                    o.OperationID,
                    o.OperationDate,
                    o.Comment,
                    o.EquipmentID,
                    e.Name AS EquipmentName,
                    o.OperationTypeID,
                    ot.Name AS OperationTypeName,
                    o.EmployeeID,
                    emp.FullName AS EmployeeName,
                    o.FromDepartmentID,
                    d1.Name AS FromDepartmentName,
                    o.ToDepartmentID,
                    d2.Name AS ToDepartmentName
                FROM Operations o
                INNER JOIN Equipment e ON o.EquipmentID = e.EquipmentID
                INNER JOIN OperationTypes ot ON o.OperationTypeID = ot.OperationTypeID
                LEFT JOIN Employees emp ON o.EmployeeID = emp.EmployeeID
                LEFT JOIN Departments d1 ON o.FromDepartmentID = d1.DepartmentID
                LEFT JOIN Departments d2 ON o.ToDepartmentID = d2.DepartmentID
                ORDER BY o.OperationDate DESC, o.OperationID DESC";

            return DbHelper.ExecuteQuery(query);
        }

        public DataTable GetEquipment()
        {
            return DbHelper.ExecuteQuery(@"
                SELECT EquipmentID, Name
                FROM Equipment
                ORDER BY Name");
        }

        public DataTable GetLastOperations(int count = 5)
        {
            string query = @"
        SELECT TOP (@Count)
            o.OperationDate,
            ot.Name AS OperationTypeName,
            e.Name AS EquipmentName,
            emp.FullName AS EmployeeName,
            d1.Name AS FromDepartmentName,
            d2.Name AS ToDepartmentName,
            o.Comment
        FROM Operations o
        INNER JOIN OperationTypes ot ON o.OperationTypeID = ot.OperationTypeID
        INNER JOIN Equipment e ON o.EquipmentID = e.EquipmentID
        LEFT JOIN Employees emp ON o.EmployeeID = emp.EmployeeID
        LEFT JOIN Departments d1 ON o.FromDepartmentID = d1.DepartmentID
        LEFT JOIN Departments d2 ON o.ToDepartmentID = d2.DepartmentID
        ORDER BY o.OperationDate DESC, o.OperationID DESC";

            return DbHelper.ExecuteQuery(query,
                new SqlParameter("@Count", count));
        }

        public int GetOperationTypeIdByName(string name)
        {
            object result = DbHelper.ExecuteScalar(@"
        SELECT OperationTypeID
        FROM OperationTypes
        WHERE Name = @Name",
                new SqlParameter("@Name", name));

            return Convert.ToInt32(result);
        }

        public DataTable GetOperationTypes()
        {
            return DbHelper.ExecuteQuery("SELECT * FROM OperationTypes ORDER BY Name");
        }

        public void AddOperationType(OperationType operationType)
        {
            DbHelper.ExecuteNonQuery(
                "INSERT INTO OperationTypes(Name) VALUES(@name)",
                new SqlParameter("@name", operationType.Name));
        }

        public void UpdateOperationType(OperationType operationType)
        {
            DbHelper.ExecuteNonQuery(
                "UPDATE OperationTypes SET Name=@name WHERE OperationTypeID=@id",
                new SqlParameter("@id", operationType.OperationTypeID),
                new SqlParameter("@name", operationType.Name));
        }

        public void DeleteOperationType(int id)
        {
            DbHelper.ExecuteNonQuery(
                "DELETE FROM OperationTypes WHERE OperationTypeID=@id",
                new SqlParameter("@id", id));
        }

        public DataTable GetEmployees()
        {
            return DbHelper.ExecuteQuery(@"
                SELECT EmployeeID, FullName
                FROM Employees
                ORDER BY FullName");
        }

        public DataTable GetDepartments()
        {
            return DbHelper.ExecuteQuery(@"
                SELECT DepartmentID, Name
                FROM Departments
                ORDER BY Name");
        }

        public void AddOperation(Operation operation)
        {
            string insertQuery = @"
                INSERT INTO Operations
                (EquipmentID, OperationTypeID, EmployeeID, FromDepartmentID, ToDepartmentID, OperationDate, Comment)
                VALUES
                (@EquipmentID, @OperationTypeID, @EmployeeID, @FromDepartmentID, @ToDepartmentID, @OperationDate, @Comment)";

            DbHelper.ExecuteNonQuery(insertQuery,
                new SqlParameter("@EquipmentID", operation.EquipmentID),
                new SqlParameter("@OperationTypeID", operation.OperationTypeID),
                new SqlParameter("@EmployeeID", (object)operation.EmployeeID ?? DBNull.Value),
                new SqlParameter("@FromDepartmentID", (object)operation.FromDepartmentID ?? DBNull.Value),
                new SqlParameter("@ToDepartmentID", (object)operation.ToDepartmentID ?? DBNull.Value),
                new SqlParameter("@OperationDate", operation.OperationDate),
                new SqlParameter("@Comment", (object)operation.Comment ?? DBNull.Value));

            ApplyOperationToEquipment(operation);
        }

        public void UpdateOperation(Operation operation)
        {
            string updateQuery = @"
                UPDATE Operations
                SET 
                    EquipmentID = @EquipmentID,
                    OperationTypeID = @OperationTypeID,
                    EmployeeID = @EmployeeID,
                    FromDepartmentID = @FromDepartmentID,
                    ToDepartmentID = @ToDepartmentID,
                    OperationDate = @OperationDate,
                    Comment = @Comment
                WHERE OperationID = @OperationID";

            DbHelper.ExecuteNonQuery(updateQuery,
                new SqlParameter("@OperationID", operation.OperationID),
                new SqlParameter("@EquipmentID", operation.EquipmentID),
                new SqlParameter("@OperationTypeID", operation.OperationTypeID),
                new SqlParameter("@EmployeeID", (object)operation.EmployeeID ?? DBNull.Value),
                new SqlParameter("@FromDepartmentID", (object)operation.FromDepartmentID ?? DBNull.Value),
                new SqlParameter("@ToDepartmentID", (object)operation.ToDepartmentID ?? DBNull.Value),
                new SqlParameter("@OperationDate", operation.OperationDate),
                new SqlParameter("@Comment", (object)operation.Comment ?? DBNull.Value));

            ApplyOperationToEquipment(operation);
        }

        public void DeleteOperation(int operationId)
        {
            // Сначала узнаём, к какому оборудованию относилась операция
            object equipmentIdObj = DbHelper.ExecuteScalar(@"
                SELECT EquipmentID
                FROM Operations
                WHERE OperationID = @OperationID",
                new SqlParameter("@OperationID", operationId));

            if (equipmentIdObj == null || equipmentIdObj == DBNull.Value)
                return;

            int equipmentId = Convert.ToInt32(equipmentIdObj);

            DbHelper.ExecuteNonQuery(@"
                DELETE FROM Operations
                WHERE OperationID = @OperationID",
                new SqlParameter("@OperationID", operationId));
        }

        private void ApplyOperationToEquipment(Operation operation)
        {
            DataTable equipmentTable = DbHelper.ExecuteQuery(@"
                SELECT EquipmentID, StatusID, DepartmentID, EmployeeID
                FROM Equipment
                WHERE EquipmentID = @EquipmentID",
                new SqlParameter("@EquipmentID", operation.EquipmentID));

            if (equipmentTable.Rows.Count == 0)
                return;

            DataRow equipmentRow = equipmentTable.Rows[0];

            int statusId = Convert.ToInt32(equipmentRow["StatusID"]);
            int departmentId = Convert.ToInt32(equipmentRow["DepartmentID"]);
            int? employeeId = equipmentRow["EmployeeID"] == DBNull.Value
                ? null
                : (int?)Convert.ToInt32(equipmentRow["EmployeeID"]);

            string operationTypeName = Convert.ToString(DbHelper.ExecuteScalar(@"
                SELECT Name
                FROM OperationTypes
                WHERE OperationTypeID = @OperationTypeID",
                new SqlParameter("@OperationTypeID", operation.OperationTypeID)));

            if (operationTypeName == null)
                return;

            switch (operationTypeName)
            {
                case "Поступление":
                    statusId = GetStatusIdByName("На складе");
                    departmentId = operation.ToDepartmentID ?? departmentId;
                    employeeId = null;
                    break;

                case "Выдача":
                    statusId = GetStatusIdByName("В эксплуатации");
                    if (operation.EmployeeID.HasValue)
                    {
                        employeeId = operation.EmployeeID;
                        departmentId = GetEmployeeDepartmentId(operation.EmployeeID.Value);
                    }
                    break;

                case "Возврат":
                    statusId = GetStatusIdByName("На складе");
                    employeeId = null;
                    if (operation.ToDepartmentID.HasValue)
                        departmentId = operation.ToDepartmentID.Value;
                    break;

                case "Перемещение":
                    if (operation.ToDepartmentID.HasValue)
                        departmentId = operation.ToDepartmentID.Value;
                    break;

                case "Передача в ремонт":
                    statusId = GetStatusIdByName("В ремонте");
                    employeeId = null;

                    if (operation.ToDepartmentID.HasValue)
                        departmentId = operation.ToDepartmentID.Value;

                    break;

                case "Возврат из ремонта":
                    statusId = GetStatusIdByName("На складе");
                    break;

                case "Списание":
                    statusId = GetStatusIdByName("Списано");
                    employeeId = null;
                    break;

                case "Инвентаризация":
                    break;

                case "Смена ответственного":
                    if (operation.EmployeeID.HasValue)
                    {
                        employeeId = operation.EmployeeID;
                        departmentId = GetEmployeeDepartmentId(operation.EmployeeID.Value);
                    }
                    statusId = GetStatusIdByName("В эксплуатации");
                    break;
            }

            DbHelper.ExecuteNonQuery(@"
                UPDATE Equipment
                SET StatusID = @StatusID,
                    DepartmentID = @DepartmentID,
                    EmployeeID = @EmployeeID
                WHERE EquipmentID = @EquipmentID",
                new SqlParameter("@StatusID", statusId),
                new SqlParameter("@DepartmentID", departmentId),
                new SqlParameter("@EmployeeID", (object)employeeId ?? DBNull.Value),
                new SqlParameter("@EquipmentID", operation.EquipmentID));
        }

        private int GetStatusIdByName(string name)
        {
            object result = DbHelper.ExecuteScalar(@"
                SELECT StatusID
                FROM Statuses
                WHERE Name = @Name",
                new SqlParameter("@Name", name));

            return Convert.ToInt32(result);
        }

        private int GetEmployeeDepartmentId(int employeeId)
        {
            object result = DbHelper.ExecuteScalar(@"
                SELECT DepartmentID
                FROM Employees
                WHERE EmployeeID = @EmployeeID",
                new SqlParameter("@EmployeeID", employeeId));

            return Convert.ToInt32(result);
        }

        public int GetRepairDepartmentId()
        {
            object result = DbHelper.ExecuteScalar(@"
        SELECT DepartmentID
        FROM Departments
        WHERE Name = @name",
                new SqlParameter("@name", "Технический отдел"));

            return Convert.ToInt32(result);
        }
    }
}
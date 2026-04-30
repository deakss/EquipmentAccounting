using EquipmentAccounting.Helpers;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly User _currentUser;
        private readonly EmployeeService _service = new EmployeeService();

        public EmployeesForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            Load += EmployeesForm_Load;
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            toolStripButtonUsers.Enabled = false;

            SetupGrid(dataGridViewUsers);
            SetupGrid(dataGridViewEmployees);
            SetupGrid(dataGridViewDepartments);
            SetupGrid(dataGridViewRoles);

            ReloadAllTables();

        }

        // Настройка DataGridView для отображения данных
        private void SetupGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = true;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm(_currentUser);
            mainForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonOperations_Click(object sender, EventArgs e)
        {
            this.Hide();
            var operationsForm = new OperationsForm(_currentUser);
            operationsForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var equipmentForm = new EquipmentForm(_currentUser);
            equipmentForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        // Метод для содержания кода try в одном месте
        private void ExecuteWithTry(Action action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Удаление невозможно",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Нельзя удалить запись: она связана с другими данными.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка данных для всех таблиц
        private void ReloadAllTables()
        {
            LoadUsers();
            LoadEmployees();
            LoadDepartments();
            LoadRoles();
        }

        // ===================== USERS =====================

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditUserForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddUser(form.User, form.Password);
                    LoadUsers();
                }
            });
        }

        // Методы загрузки данных для таблицы
        private void LoadUsers()
        {
            dataGridViewUsers.DataSource = _service.GetUsers();
            ConfigureUsersGrid();
        }

        private void ConfigureUsersGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewUsers);

                GridHelper.ApplyHeaders(
                    dataGridViewUsers,
                    new Dictionary<string, string>
                    {
            { "Login", "Логин" },
            { "RoleName", "Роль" },
            { "EmployeeName", "Сотрудник" }
                    },
                    "UserID", "PasswordHash", "RoleID", "EmployeeID"
                );

                GridHelper.AddActionButtons(dataGridViewUsers, "edit", "delete");

                dataGridViewUsers.CellContentClick -= Users_CellClick;
                dataGridViewUsers.CellContentClick += Users_CellClick;
            });
        }

        private void Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExecuteWithTry(() =>
            {
                if (e.RowIndex < 0) return;

                var grid = (DataGridView)sender;
                var row = grid.Rows[e.RowIndex];

                int id = (int)row.Cells["UserID"].Value;

                if (grid.Columns[e.ColumnIndex].Name == "edit")
                {
                    var user = new User
                    {
                        UserID = id,
                        Login = row.Cells["Login"].Value.ToString(),
                        RoleID = (int)row.Cells["RoleID"].Value,
                        EmployeeID = row.Cells["EmployeeID"].Value == DBNull.Value
                            ? null
                            : (int?)row.Cells["EmployeeID"].Value
                    };

                    var form = new AddEditUserForm(user);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _service.UpdateUser(form.User, form.Password);
                        LoadUsers();
                    }
                }
                else if (grid.Columns[e.ColumnIndex].Name == "delete")
                {
                    if (MessageBox.Show("Удалить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _service.DeleteUser(id);
                        LoadUsers();
                    }
                }
            });
        }

        // ===================== EMPLOYEES =====================

        private void toolStripButtonAddEmployees_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditEmployeeForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddEmployee(form.Employee);
                    LoadEmployees();
                }
            });
        }

        private void LoadEmployees()
        {
            dataGridViewEmployees.DataSource = _service.GetEmployees();
            ConfigureEmployeesGrid();
        }

        private void ConfigureEmployeesGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewEmployees);

                GridHelper.ApplyHeaders(
                    dataGridViewEmployees,
                    new Dictionary<string, string>
                    {
            { "FullName", "ФИО" },
            { "Position", "Должность" },
            { "DepartmentName", "Отдел" }
                    },
                    "EmployeeID", "DepartmentID"
                );

                GridHelper.AddActionButtons(dataGridViewEmployees, "edit", "delete");

                dataGridViewEmployees.CellContentClick -= Employees_CellClick;
                dataGridViewEmployees.CellContentClick += Employees_CellClick;
            });
        }

        private void Employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExecuteWithTry(() =>
            {
                if (e.RowIndex < 0) return;

                var row = dataGridViewEmployees.Rows[e.RowIndex];
                int id = (int)row.Cells["EmployeeID"].Value;

                if (dataGridViewEmployees.Columns[e.ColumnIndex].Name == "edit")
                {
                    var emp = new Employee
                    {
                        EmployeeID = id,
                        FullName = row.Cells["FullName"].Value.ToString(),
                        Position = row.Cells["Position"].Value?.ToString(),
                        DepartmentID = (int)row.Cells["DepartmentID"].Value
                    };
                    var form = new AddEditEmployeeForm(emp);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _service.UpdateEmployee(form.Employee);
                        LoadEmployees();
                    }
                }
                else if (dataGridViewEmployees.Columns[e.ColumnIndex].Name == "delete")
                {
                    if (MessageBox.Show("Удалить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _service.DeleteEmployeeSafe(id);
                        LoadEmployees();
                    }
                }
            });
        }

        // ===================== DEPARTMENTS =====================

        private void toolStripButtonAddDepartments_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditDepartmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddDepartment(form.Department);
                    LoadDepartments();
                }
            });
        }

        private void LoadDepartments()
        {
            dataGridViewDepartments.DataSource = _service.GetDepartments();
            ConfigureDepartmentsGrid();
        }

        private void ConfigureDepartmentsGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewDepartments);

                GridHelper.ApplyHeaders(
                    dataGridViewDepartments,
                    new Dictionary<string, string>
                    {
            { "Name", "Название" }
                    },
                    "DepartmentID"
                );

                GridHelper.AddActionButtons(dataGridViewDepartments, "editDepartment", "deleteDepartment");

                dataGridViewDepartments.CellContentClick -= Departments_CellClick;
                dataGridViewDepartments.CellContentClick += Departments_CellClick;
            });
        }

        private void Departments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExecuteWithTry(() =>
            {
                if (e.RowIndex < 0) return;

                var row = dataGridViewDepartments.Rows[e.RowIndex];
                int id = (int)row.Cells["DepartmentID"].Value;

                if (dataGridViewDepartments.Columns[e.ColumnIndex].Name == "editDepartment")
                {
                    var dep = new Department
                    {
                        DepartmentID = id,
                        Name = row.Cells["Name"].Value.ToString()
                    };

                    var form = new AddEditDepartmentForm(dep);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _service.UpdateDepartment(form.Department);
                        LoadDepartments();
                    }
                }
                else if (dataGridViewDepartments.Columns[e.ColumnIndex].Name == "deleteDepartment")
                {
                    if (MessageBox.Show("Удалить отдел?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _service.DeleteDepartmentSafe(id);
                        LoadDepartments();
                    }
                }
            });
        }

        // ===================== ROLES =====================

        private void toolStripButtonAddRoles_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditRoleForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddRole(form.Role);
                    LoadRoles();
                }
            });
        }

        private void LoadRoles()
        {
            dataGridViewRoles.DataSource = _service.GetRoles();
            ConfigureRolesGrid();
        }

        private void ConfigureRolesGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewRoles);

                GridHelper.ApplyHeaders(
                    dataGridViewRoles,
                    new Dictionary<string, string>
                    {
            { "Name", "Название роли" }
                    },
                    "RoleID"
                );

                GridHelper.AddActionButtons(dataGridViewRoles, "editRole", "deleteRole");

                dataGridViewRoles.CellContentClick -= Roles_CellClick;
                dataGridViewRoles.CellContentClick += Roles_CellClick;
            });
        }

        private void Roles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExecuteWithTry(() =>
            {
                if (e.RowIndex < 0) return;

                var row = dataGridViewRoles.Rows[e.RowIndex];
                int id = (int)row.Cells["RoleID"].Value;

                if (dataGridViewRoles.Columns[e.ColumnIndex].Name == "editRole")
                {
                    var role = new Role
                    {
                        RoleID = id,
                        Name = row.Cells["Name"].Value.ToString()
                    };

                    var form = new AddEditRoleForm(role);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _service.UpdateRole(form.Role);
                        LoadRoles();
                    }
                }
                else if (dataGridViewRoles.Columns[e.ColumnIndex].Name == "deleteRole")
                {
                    if (MessageBox.Show("Удалить роль?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _service.DeleteRoleSafe(id);
                        LoadRoles();
                    }
                }
            });
        }
    }
}
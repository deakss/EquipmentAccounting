using System;
using System.Data;
using System.Windows.Forms;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using Microsoft.VisualBasic;

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

        // Загрузка данных для всех таблиц
        private void ReloadAllTables()
        {
            LoadUsers();
            LoadEmployees();
            LoadDepartments();
            LoadRoles();
        }

        // Методы загрузки данных для каждой таблицы
        private void LoadUsers()
        {
            dataGridViewUsers.DataSource = _service.GetUsers();
        }

        private void LoadEmployees()
        {
            dataGridViewEmployees.DataSource = _service.GetEmployees();
        }

        private void LoadDepartments()
        {
            dataGridViewDepartments.DataSource = _service.GetDepartments();
        }

        private void LoadRoles()
        {
            dataGridViewRoles.DataSource = _service.GetRoles();
        }

        // Получение выбранной строки в DataGridView -> возвращаем DataRowView для удобного доступа к данным
        private DataRowView GetSelectedRow(DataGridView grid)
        {
            return grid.CurrentRow?.DataBoundItem as DataRowView;
        }

        
        private string Prompt(string caption, string text, string defaultValue = "")
        {
            return Interaction.InputBox(text, caption, defaultValue).Trim();
        }

        private int PromptInt(string caption, string text, string defaultValue = "")
        {
            while (true)
            {
                string value = Prompt(caption, text, defaultValue);

                if (string.IsNullOrWhiteSpace(value))
                    throw new OperationCanceledException();

                if (int.TryParse(value, out int result))
                    return result;

                MessageBox.Show("Введите корректное целое число.");
                defaultValue = value;
            }
        }

        private int? PromptNullableInt(string caption, string text, string defaultValue = "")
        {
            string value = Prompt(caption, text, defaultValue);

            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (int.TryParse(value, out int result))
                return result;

            MessageBox.Show("Введите корректное целое число.");
            return PromptNullableInt(caption, text, defaultValue);
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
        }

        private void toolStripButtonOperations_Click(object sender, EventArgs e)
        {
            var operationsForm = new OperationsForm();
            operationsForm.Show();
        }

        private void toolStripButtonEquipment_Click(object sender, EventArgs e)
        {
            var equipmentForm = new EquipmentForm();
            equipmentForm.Show();
        }

        // ===================== USERS =====================

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string login = Prompt("Добавление пользователя", "Логин:");
                if (string.IsNullOrWhiteSpace(login)) return;

                string password = Prompt("Добавление пользователя", "Пароль:");
                if (string.IsNullOrWhiteSpace(password)) return;

                int roleId = PromptInt("Добавление пользователя", "ID роли:");
                int? employeeId = PromptNullableInt("Добавление пользователя", "ID сотрудника (если нет — оставьте пустым):");

                _service.AddUser(new User
                {
                    Login = login,
                    RoleID = roleId,
                    EmployeeID = employeeId
                }, password);

                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления пользователя:\n" + ex.Message);
            }
        }

        private void toolStripButtonEditUser_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewUsers);
            if (row == null)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }

            try
            {
                int userId = Convert.ToInt32(row["UserID"]);
                string login = Prompt("Редактирование пользователя", "Логин:", row["Login"].ToString());
                if (string.IsNullOrWhiteSpace(login)) return;

                string password = Prompt("Редактирование пользователя", "Новый пароль (оставьте пустым, чтобы не менять):");
                int roleId = PromptInt("Редактирование пользователя", "ID роли:", row["RoleID"].ToString());
                int? employeeId = row["EmployeeID"] == DBNull.Value
                    ? PromptNullableInt("Редактирование пользователя", "ID сотрудника (если нет — оставьте пустым):")
                    : PromptNullableInt("Редактирование пользователя", "ID сотрудника (если нет — оставьте пустым):", row["EmployeeID"].ToString());

                _service.UpdateUser(new User
                {
                    UserID = userId,
                    Login = login,
                    RoleID = roleId,
                    EmployeeID = employeeId
                }, password);

                LoadUsers();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования пользователя:\n" + ex.Message);
            }
        }

        private void toolStripButtonDelUser_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewUsers);
            if (row == null)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }

            if (MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int userId = Convert.ToInt32(row["UserID"]);
                _service.DeleteUser(userId);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления пользователя:\n" + ex.Message);
            }
        }

        // ===================== EMPLOYEES =====================

        private void toolStripButtonAddEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = Prompt("Добавление сотрудника", "ФИО:");
                if (string.IsNullOrWhiteSpace(fullName)) return;

                string position = Prompt("Добавление сотрудника", "Должность:");
                int departmentId = PromptInt("Добавление сотрудника", "ID подразделения:");

                _service.AddEmployee(new Employee
                {
                    FullName = fullName,
                    Position = position,
                    DepartmentID = departmentId
                });

                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления сотрудника:\n" + ex.Message);
            }
        }

        private void toolStripButtonEditEmployees_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewEmployees);
            if (row == null)
            {
                MessageBox.Show("Выберите сотрудника.");
                return;
            }

            try
            {
                int employeeId = Convert.ToInt32(row["EmployeeID"]);
                string fullName = Prompt("Редактирование сотрудника", "ФИО:", row["FullName"].ToString());
                if (string.IsNullOrWhiteSpace(fullName)) return;

                string position = Prompt("Редактирование сотрудника", "Должность:", row["Position"].ToString());
                int departmentId = PromptInt("Редактирование сотрудника", "ID подразделения:", row["DepartmentID"].ToString());

                _service.UpdateEmployee(new Employee
                {
                    EmployeeID = employeeId,
                    FullName = fullName,
                    Position = position,
                    DepartmentID = departmentId
                });

                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования сотрудника:\n" + ex.Message);
            }
        }

        private void toolStripButtonDelEmployees_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewEmployees);
            if (row == null)
            {
                MessageBox.Show("Выберите сотрудника.");
                return;
            }

            if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int employeeId = Convert.ToInt32(row["EmployeeID"]);
                _service.DeleteEmployee(employeeId);
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления сотрудника:\n" + ex.Message);
            }
        }

        // ===================== DEPARTMENTS =====================

        private void toolStripButtonAddDepartments_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Prompt("Добавление подразделения", "Название подразделения:");
                if (string.IsNullOrWhiteSpace(name)) return;

                _service.AddDepartment(new Department { Name = name });
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления подразделения:\n" + ex.Message);
            }
        }

        private void toolStripButtonEditDepartments_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewDepartments);
            if (row == null)
            {
                MessageBox.Show("Выберите подразделение.");
                return;
            }

            try
            {
                int departmentId = Convert.ToInt32(row["DepartmentID"]);
                string name = Prompt("Редактирование подразделения", "Название подразделения:", row["Name"].ToString());
                if (string.IsNullOrWhiteSpace(name)) return;

                _service.UpdateDepartment(new Department
                {
                    DepartmentID = departmentId,
                    Name = name
                });

                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования подразделения:\n" + ex.Message);
            }
        }

        private void toolStripButtonDelDepartments_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewDepartments);
            if (row == null)
            {
                MessageBox.Show("Выберите подразделение.");
                return;
            }

            if (MessageBox.Show("Удалить подразделение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int departmentId = Convert.ToInt32(row["DepartmentID"]);
                _service.DeleteDepartment(departmentId);
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления подразделения:\n" + ex.Message);
            }
        }

        // ===================== ROLES =====================

        private void toolStripButtonAddRoles_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Prompt("Добавление роли", "Название роли:");
                if (string.IsNullOrWhiteSpace(name)) return;

                _service.AddRole(new Role { Name = name });
                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления роли:\n" + ex.Message);
            }
        }

        private void toolStripButtonEditRoles_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewRoles);
            if (row == null)
            {
                MessageBox.Show("Выберите роль.");
                return;
            }

            try
            {
                int roleId = Convert.ToInt32(row["RoleID"]);
                string name = Prompt("Редактирование роли", "Название роли:", row["Name"].ToString());
                if (string.IsNullOrWhiteSpace(name)) return;

                _service.UpdateRole(new Role
                {
                    RoleID = roleId,
                    Name = name
                });

                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования роли:\n" + ex.Message);
            }
        }

        private void toolStripButtonDelRoles_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow(dataGridViewRoles);
            if (row == null)
            {
                MessageBox.Show("Выберите роль.");
                return;
            }

            if (MessageBox.Show("Удалить роль?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int roleId = Convert.ToInt32(row["RoleID"]);
                _service.DeleteRole(roleId);
                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления роли:\n" + ex.Message);
            }
        }
    }
}
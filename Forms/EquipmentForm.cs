using EquipmentAccounting.Helpers;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class EquipmentForm : Form
    {
        private readonly User _currentUser;

        private EquipmentService _equipmentService = new EquipmentService();
        private EmployeeService _employeeService = new EmployeeService();

        public EquipmentForm(User user)
        {
            InitializeComponent();

            toolStripButtonEquipment.Enabled = false;
            _currentUser = user;
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

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var employeesForm = new EmployeesForm(_currentUser);
            employeesForm.ShowDialog();
            this.Close();
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            toolStripButtonEquipment.Enabled = false;
            LoadAll();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void ExecuteWithTry(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAll()
        {
            LoadEquipment();
            LoadCategories();
            LoadDepartments();
            LoadStatuses();
        }

        private void LoadEquipment()
        {
            dataGridViewEquipment.DataSource = _equipmentService.GetEquipment();
            ConfigureEquipmentGrid();
        }

        private void ConfigureEquipmentGrid()
        {
            GridHelper.ConfigureBase(dataGridViewEquipment);

            GridHelper.ApplyHeaders(
                dataGridViewEquipment,
                new Dictionary<string, string>
                {
                    { "Name", "Наименование" },
                    { "InventoryNumber", "Инв. номер" },
                    { "SerialNumber", "Серийный номер" },
                    { "CategoryName", "Категория" },
                    { "StatusName", "Статус" },
                    { "DepartmentName", "Отдел" },
                    { "EmployeeName", "Сотрудник" },
                    { "PurchaseDate", "Дата покупки" },
                    { "Cost", "Стоимость" },
                    { "Description", "Описание" }
                },
                "EquipmentID", "CategoryID", "StatusID", "DepartmentID", "EmployeeID"
            );

            GridHelper.AddActionButtons(dataGridViewEquipment, "editEquip", "deleteEquip");

            dataGridViewEquipment.CellContentClick -= Equipment_CellClick;
            dataGridViewEquipment.CellContentClick += Equipment_CellClick;
        }
        private void Equipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewEquipment.Rows[e.RowIndex];
            int id = (int)row.Cells["EquipmentID"].Value;

            if (dataGridViewEquipment.Columns[e.ColumnIndex].Name == "editEquip")
            {
                var eq = new Equipment
                {
                    EquipmentID = id,
                    Name = row.Cells["Name"].Value.ToString(),
                    InventoryNumber = row.Cells["InventoryNumber"].Value.ToString(),
                    SerialNumber = row.Cells["SerialNumber"]?.Value?.ToString(),
                    CategoryID = (int)row.Cells["CategoryID"].Value,
                    StatusID = (int)row.Cells["StatusID"].Value,
                    DepartmentID = (int)row.Cells["DepartmentID"].Value,
                    EmployeeID = row.Cells["EmployeeID"].Value == DBNull.Value ? null : (int?)row.Cells["EmployeeID"].Value,
                    Cost = row.Cells["Cost"].Value == DBNull.Value ? null : (decimal?)row.Cells["Cost"].Value,
                    Description = row.Cells["Description"]?.Value?.ToString()
                };

                var form = new AddEditEquipmentForm(eq);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateEquipment(form.Equipment);
                    LoadEquipment();
                }
            }
            else if (dataGridViewEquipment.Columns[e.ColumnIndex].Name == "deleteEquip")
            {
                if (MessageBox.Show("Удалить оборудование?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _equipmentService.DeleteEquipment(id);
                    LoadEquipment();
                }
            }
        }
        private void LoadCategories()
        {
            dataGridViewCategories.DataSource = _equipmentService.GetCategories();
            ConfigureCategoriesGrid();
        }

        private void ConfigureCategoriesGrid()
        {
            GridHelper.ConfigureBase(dataGridViewCategories);

            GridHelper.ApplyHeaders(
                dataGridViewCategories,
                new Dictionary<string, string>
                {
                    { "Name", "Название" }
                },
                "CategoryID"
            );

            GridHelper.AddActionButtons(dataGridViewCategories, "editCat", "deleteCat");

            dataGridViewCategories.CellContentClick -= Categories_CellClick;
            dataGridViewCategories.CellContentClick += Categories_CellClick;
        }
        private void Categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewCategories.Rows[e.RowIndex];
            int id = (int)row.Cells["CategoryID"].Value;

            if (dataGridViewCategories.Columns[e.ColumnIndex].Name == "editCat")
            {
                var cat = new Category
                {
                    CategoryID = id,
                    Name = row.Cells["Name"].Value.ToString()
                };

                var form = new AddEditCategoryForm(cat);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateCategory(form.Category);
                    LoadCategories();
                }
            }
            else if (dataGridViewCategories.Columns[e.ColumnIndex].Name == "deleteCat")
            {
                if (MessageBox.Show("Удалить категорию?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _equipmentService.DeleteCategory(id);
                    LoadCategories();
                }
            }
        }

        private void LoadDepartments()
        {
            dataGridViewDepartments.DataSource = _employeeService.GetDepartments();
            ConfigureDepartmentsGrid();
        }

        private void ConfigureDepartmentsGrid()
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

            GridHelper.AddActionButtons(dataGridViewDepartments, "editDep", "deleteDep");

            dataGridViewDepartments.CellContentClick -= Departments_CellClick;
            dataGridViewDepartments.CellContentClick += Departments_CellClick;
        }

        private void Departments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewDepartments.Rows[e.RowIndex];
            int id = (int)row.Cells["DepartmentID"].Value;

            if (dataGridViewDepartments.Columns[e.ColumnIndex].Name == "editDep")
            {
                var dep = new Department
                {
                    DepartmentID = id,
                    Name = row.Cells["Name"].Value.ToString()
                };

                var form = new AddEditDepartmentForm(dep);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _employeeService.UpdateDepartment(form.Department);
                    LoadDepartments();
                }
            }
            else if (dataGridViewDepartments.Columns[e.ColumnIndex].Name == "deleteDep")
            {
                if (MessageBox.Show("Удалить отдел?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _employeeService.DeleteDepartment(id);
                    LoadDepartments();
                }
            }
        }

        private void LoadStatuses()
        {
            dataGridViewStatuses.DataSource = _equipmentService.GetStatuses();
            ConfigureStatusesGrid();
        }

        private void ConfigureStatusesGrid()
        {
            GridHelper.ConfigureBase(dataGridViewStatuses);

            GridHelper.ApplyHeaders(
                dataGridViewStatuses,
                new Dictionary<string, string>
                {
                    { "Name", "Название статуса" }
                },
                "StatusID"
            );

            GridHelper.AddActionButtons(dataGridViewStatuses, "editStatus", "deleteStatus");

            dataGridViewStatuses.CellContentClick -= Statuses_CellClick;
            dataGridViewStatuses.CellContentClick += Statuses_CellClick;
        }

        private void Statuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewStatuses.Rows[e.RowIndex];
            int id = (int)row.Cells["StatusID"].Value;

            if (dataGridViewStatuses.Columns[e.ColumnIndex].Name == "editStatus")
            {
                var st = new Status
                {
                    StatusID = id,
                    Name = row.Cells["Name"].Value.ToString()
                };

                var form = new AddEditStatusForm(st);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateStatus(form.Status);
                    LoadStatuses();
                }
            }
            else if (dataGridViewStatuses.Columns[e.ColumnIndex].Name == "deleteStatus")
            {
                if (MessageBox.Show("Удалить статус?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _equipmentService.DeleteStatus(id);
                    LoadStatuses();
                }
            }
        }

        // Получение выбранной строки в DataGridView -> возвращаем DataRowView для удобного доступа к данным
        private DataRowView GetSelectedRow(DataGridView grid)
        {
            return grid.CurrentRow?.DataBoundItem as DataRowView;
        }

        // ===================== EQUIPMENT =====================

        private void toolStripButtonAddEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditEquipmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.AddEquipment(form.Equipment);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonEditEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewEquipment);
                if (row == null) return;

                var eq = new Equipment
                {
                    EquipmentID = (int)row["EquipmentID"],
                    Name = row["Name"].ToString(),
                    InventoryNumber = row["InventoryNumber"].ToString(),
                    SerialNumber = row["SerialNumber"]?.ToString(),
                    CategoryID = (int)row["CategoryID"],
                    StatusID = (int)row["StatusID"],
                    DepartmentID = (int)row["DepartmentID"],
                    EmployeeID = row["EmployeeID"] == DBNull.Value ? null : (int?)row["EmployeeID"],
                    Cost = (decimal)row["Cost"],
                    Description = row["Description"].ToString()
                };

                var form = new AddEditEquipmentForm(eq);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateEquipment(form.Equipment);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonDelEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewEquipment);
                if (row == null) return;

                int id = (int)row["EquipmentID"];

                if (MessageBox.Show("Удалить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _equipmentService.DeleteEquipment(id);
                    LoadAll();
                }
            });
        }

        // ===================== CATEGORY =====================

        private void toolStripButtonAddCategory_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditCategoryForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.AddCategory(form.Category);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonEditCategory_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewCategories);
                if (row == null) return;

                var cat = new Category
                {
                    CategoryID = (int)row["CategoryID"],
                    Name = row["Name"].ToString()
                };

                var form = new AddEditCategoryForm(cat);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateCategory(form.Category);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonDelCategory_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewCategories);
                if (row == null) return;

                int id = (int)row["CategoryID"];

                if (MessageBox.Show("Удалить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _equipmentService.DeleteCategory(id);
                    LoadAll();
                }
            });
        }

        // ===================== STATUS =====================

        private void toolStripButtonAddStatus_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditStatusForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.AddStatus(form.Status);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonEditStatus_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewStatuses);
                if (row == null) return;

                var stat = new Status
                {
                    StatusID = (int)row["StatusID"],
                    Name = row["Name"].ToString()
                };

                var form = new AddEditStatusForm(stat);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _equipmentService.UpdateStatus(form.Status);
                    LoadAll();
                }
            });
        }

        private void toolStripButtonDelStatus_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewStatuses);
                if (row == null) return;

                int id = (int)row["StatusID"];

                if (MessageBox.Show("Удалить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _equipmentService.DeleteStatus(id);
                    LoadAll();
                }
            });
        }

        // ===================== DEPARTMENT =====================
        
        private void toolStripButtonAddDep_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditDepartmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _employeeService.AddDepartment(form.Department);
                    LoadDepartments();
                }
            });
        }

        private void toolStripButtonEditDepartments_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewDepartments);
                if (row == null) return;

                var department = new Department
                {
                    DepartmentID = (int)row["DepartmentID"],
                    Name = row["Name"].ToString(),
                };

                var form = new AddEditDepartmentForm(department);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _employeeService.UpdateDepartment(form.Department);
                    LoadDepartments();
                }
            });
        }

        private void toolStripButtonDelDepartments_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewDepartments);
                if (row == null)
                {
                    MessageBox.Show("Выберите подразделение.");
                    return;
                }

                if (MessageBox.Show("Удалить подразделение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                int departmentId = Convert.ToInt32(row["DepartmentID"]);
                _employeeService.DeleteDepartment(departmentId);
                LoadDepartments();
            });
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;

namespace EquipmentAccounting.Forms
{
    public partial class EquipmentForm : Form
    {
        private readonly User _currentUser;
        private EquipmentService _service = new EquipmentService();
        private EmployeeService _empService = new EmployeeService();

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
            dataGridViewEquipment.DataSource = _service.GetEquipment();
        }

        private void LoadCategories()
        {
            dataGridViewCategories.DataSource = _service.GetCategories();
        }

        private void LoadDepartments()
        {
            dataGridViewDepartments.DataSource = _empService.GetDepartments();
        }

        private void LoadStatuses()
        {
            dataGridViewStatuses.DataSource = _service.GetStatuses();
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
                    _service.AddEquipment(form.Equipment);
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
                    _service.UpdateEquipment(form.Equipment);
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
                    _service.DeleteEquipment(id);
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
                    _service.AddCategory(form.Category);
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
                    _service.UpdateCategory(form.Category);
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
                    _service.DeleteCategory(id);
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
                    _service.AddStatus(form.Status);
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
                    _service.UpdateStatus(form.Status);
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
                    _service.DeleteStatus(id);
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
                    _empService.AddDepartment(form.Department);
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
                    _empService.UpdateDepartment(form.Department);
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
                _empService.DeleteDepartment(departmentId);
                LoadDepartments();
            });
        }
    }
}

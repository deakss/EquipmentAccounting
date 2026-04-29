using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class OperationsForm : Form
    {
        private readonly OperationService _service = new OperationService();
        private readonly User _currentUser;

        public enum Roles
        {
            Admin = 1,
            User = 2
        }
        public OperationsForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            toolStripLabelUser.Text =$"Пользователь: {_currentUser.Login}";
            Load += OperationsForm_Load;
            toolStripButtonOperations.Enabled = false;

            if (_currentUser.RoleID != (int)Roles.Admin)
            {
                toolStripButtonEquipment.Visible = false;
                toolStripButtonUsers.Visible = false;
                tabPageOperationTypes.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {
            SetupGrid(dataGridViewOperations);
            SetupGrid(dataGridViewOperationTypes);
            LoadOperations();
            LoadOperationTypes();
        }

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

        private void LoadOperations()
        {
            dataGridViewOperations.DataSource = _service.GetOperations();
        }

        private void LoadOperationTypes()
        {
            dataGridViewOperationTypes.DataSource = _service.GetOperationTypes();
        }
        private DataRowView GetSelectedRow(DataGridView grid)
        {
            return grid.CurrentRow?.DataBoundItem as DataRowView;
        }

        private void ExecuteWithTry(Action action)
        {
            try
            {
                action();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Нельзя удалить тип операции, так как он используется.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm(_currentUser);
            mainForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var usersForm = new EmployeesForm(_currentUser);
            usersForm.ShowDialog();
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

        private void toolStripButtonAddOperation_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditOperationForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddOperation(form.Operation);
                    LoadOperations();
                }
            });
        }

        private void toolStripButtonEditOperation_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewOperations);
                if (row == null)
                {
                    MessageBox.Show("Выберите операцию.");
                    return;
                }

                var operation = new Operation
                {
                    OperationID = (int)row["OperationID"],
                    EquipmentID = (int)row["EquipmentID"],
                    OperationTypeID = (int)row["OperationTypeID"],
                    EmployeeID = row["EmployeeID"] == DBNull.Value ? null : (int?)row["EmployeeID"],
                    FromDepartmentID = row["FromDepartmentID"] == DBNull.Value ? null : (int?)row["FromDepartmentID"],
                    ToDepartmentID = row["ToDepartmentID"] == DBNull.Value ? null : (int?)row["ToDepartmentID"],
                    OperationDate = (DateTime)row["OperationDate"],
                    Comment = row["Comment"] == DBNull.Value ? null : row["Comment"].ToString()
                };

                var form = new AddEditOperationForm(operation);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.UpdateOperation(form.Operation);
                    LoadOperations();
                }
            });
        }

        private void toolStripButtonDelOperation_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewOperations);
                if (row == null)
                {
                    MessageBox.Show("Выберите операцию.");
                    return;
                }

                if (MessageBox.Show("Удалить операцию?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                int operationId = (int)row["OperationID"];
                _service.DeleteOperation(operationId);
                LoadOperations();
            });
        }

        private void toolStripButtonAddOperationType_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditTypeForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddOperationType(form.OperationType);
                    LoadOperationTypes();
                }
            });
        }

        private void toolStripButtonEditOperationType_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewOperationTypes);
                if (row == null)
                {
                    MessageBox.Show("Выберите тип операции");
                    return;
                }

                var operationType = new OperationType
                {
                    OperationTypeID = (int)row["OperationTypeID"],
                    Name = row["Name"].ToString()
                };

                var form = new AddEditTypeForm(operationType);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.UpdateOperationType(form.OperationType);

                    LoadOperationTypes();
                }
            });
        }

        private void toolStripButtonDelOperationType_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var row = GetSelectedRow(dataGridViewOperationTypes);
                if (row == null)
                {
                    MessageBox.Show("Выберите тип операции");
                    return;
                }

                int id = (int)row["OperationTypeID"];

                if (MessageBox.Show("Удалить тип операции?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _service.DeleteOperationType(id);
                    LoadOperationTypes();
                }

            });
                
        }
    }
}
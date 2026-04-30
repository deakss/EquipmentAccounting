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
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            Load += OperationsForm_Load;
            toolStripButtonOperations.Enabled = false;

            if (_currentUser.RoleID != (int)Roles.Admin)
            {
                toolStripButtonMenu.Visible = false;
                toolStripButtonEquipment.Visible = false;
                toolStripButtonUsers.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
            }
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {
            LoadOperations();
            LoadOperationTypes();
        }

        private DataRowView GetSelectedRow(DataGridView grid)
        {
            return grid.CurrentRow?.DataBoundItem as DataRowView;
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

        // ===================== OPERATION =====================

        private void LoadOperations()
        {
            dataGridViewOperations.DataSource = _service.GetOperations();
            ConfigureOperationsGrid();
        }

        private void toolStripButtonAddOperation_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditOperationForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _service.AddOperation(form.Operation);
                    ConfigureOperationsGrid();
                }
            });
        }

        private void ConfigureOperationsGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewOperations);

                GridHelper.ApplyHeaders(
                    dataGridViewOperations,
                    new Dictionary<string, string>
                    {
                    { "OperationDate", "Дата" },
                    { "EquipmentName", "Оборудование" },
                    { "OperationTypeName", "Тип операции" },
                    { "EmployeeName", "Сотрудник" },
                    { "FromDepartmentName", "Откуда" },
                    { "ToDepartmentName", "Куда" },
                    { "Comment", "Комментарий" }
                    },
                    "OperationID", "EquipmentID", "OperationTypeID",
                    "EmployeeID", "FromDepartmentID", "ToDepartmentID"
                );
            });
        }

        // ===================== OPERATION TYPE =====================

        private void LoadOperationTypes()
        {
            dataGridViewOperationTypes.DataSource = _service.GetOperationTypes();
            ConfigureOperationTypesGrid();
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

        private void ConfigureOperationTypesGrid()
        {
            ExecuteWithTry(() =>
            {
                GridHelper.ConfigureBase(dataGridViewOperationTypes);

                GridHelper.ApplyHeaders(
                    dataGridViewOperationTypes,
                    new Dictionary<string, string>
                    {
                    { "Name", "Название типа операции" }
                    },
                    "OperationTypeID"
                );

                GridHelper.AddActionButtons(dataGridViewOperationTypes, "editType", "deleteType");

                dataGridViewOperationTypes.CellContentClick -= OperationTypes_CellClick;
                dataGridViewOperationTypes.CellContentClick += OperationTypes_CellClick;
            });
        }

        private void OperationTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExecuteWithTry(() =>
            {
                if (e.RowIndex < 0) return;

                var row = dataGridViewOperationTypes.Rows[e.RowIndex];
                int id = (int)row.Cells["OperationTypeID"].Value;

                if (dataGridViewOperationTypes.Columns[e.ColumnIndex].Name == "editType")
                {
                    var type = new OperationType
                    {
                        OperationTypeID = id,
                        Name = row.Cells["Name"].Value.ToString()
                    };

                    var form = new AddEditTypeForm(type);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _service.UpdateOperationType(form.OperationType);
                        LoadOperationTypes();
                    }
                }
                else if (dataGridViewOperationTypes.Columns[e.ColumnIndex].Name == "deleteType")
                {
                    if (MessageBox.Show("Удалить тип операции?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    _service.DeleteOperationTypeSafe(id);
                    LoadOperationTypes();
                }
            });
        }
    }
}
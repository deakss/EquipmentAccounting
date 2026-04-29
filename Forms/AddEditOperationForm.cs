using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditOperationForm : Form
    {
        public Operation Operation { get; private set; }

        private bool isEdit = false;
        private readonly OperationService _service = new OperationService();

        public AddEditOperationForm()
        {
            InitializeComponent();
            LoadEquipment();
            LoadOperationTypes();
            LoadEmployees();
            LoadDepartments();
            buttonAddOperation.Text = "Добавить";
        }

        public AddEditOperationForm(Operation operation) : this()
        {
            isEdit = true;
            Operation = operation;
            buttonAddOperation.Text = "Сохранить";

            comboBoxEquipment.SelectedValue = operation.EquipmentID;
            comboBoxEquipment.Enabled = false; // лучше не менять оборудование у уже созданной операции

            comboBoxType.SelectedValue = operation.OperationTypeID;

            if (operation.EmployeeID.HasValue)
                comboBoxEmployee.SelectedValue = operation.EmployeeID.Value;
            else
                comboBoxEmployee.SelectedIndex = -1;

            if (operation.FromDepartmentID.HasValue)
                comboBoxDepartmentFrom.SelectedValue = operation.FromDepartmentID.Value;
            else
                comboBoxDepartmentFrom.SelectedIndex = -1;

            if (operation.ToDepartmentID.HasValue)
                comboBoxDepartmentTo.SelectedValue = operation.ToDepartmentID.Value;
            else
                comboBoxDepartmentTo.SelectedIndex = -1;

            dateTimePickerOperationDate.Value = operation.OperationDate;
            richTextBoxComment.Text = operation.Comment;
        }

        private void LoadEquipment()
        {
            DataTable table = _service.GetEquipment();
            comboBoxEquipment.DataSource = table;
            comboBoxEquipment.DisplayMember = "Name";
            comboBoxEquipment.ValueMember = "EquipmentID";
        }

        private void LoadOperationTypes()
        {
            DataTable table = _service.GetOperationTypes();
            comboBoxType.DataSource = table;
            comboBoxType.DisplayMember = "Name";
            comboBoxType.ValueMember = "OperationTypeID";
        }

        private void LoadEmployees()
        {
            DataTable table = _service.GetEmployees();

            DataRow emptyRow = table.NewRow();
            emptyRow["EmployeeID"] = DBNull.Value;
            emptyRow["FullName"] = "(Не выбран)";
            table.Rows.InsertAt(emptyRow, 0);

            comboBoxEmployee.DataSource = table;
            comboBoxEmployee.DisplayMember = "FullName";
            comboBoxEmployee.ValueMember = "EmployeeID";
            comboBoxEmployee.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            DataTable table = _service.GetDepartments();

            DataRow emptyRow = table.NewRow();
            emptyRow["DepartmentID"] = DBNull.Value;
            emptyRow["Name"] = "(Не выбран)";
            table.Rows.InsertAt(emptyRow, 0);

            comboBoxDepartmentFrom.DataSource = table.Copy();
            comboBoxDepartmentFrom.DisplayMember = "Name";
            comboBoxDepartmentFrom.ValueMember = "DepartmentID";
            comboBoxDepartmentFrom.SelectedIndex = 0;

            comboBoxDepartmentTo.DataSource = table;
            comboBoxDepartmentTo.DisplayMember = "Name";
            comboBoxDepartmentTo.ValueMember = "DepartmentID";
            comboBoxDepartmentTo.SelectedIndex = 0;
        }

        private int? GetNullableSelectedValue(ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null || comboBox.SelectedValue == DBNull.Value)
                return null;

            return Convert.ToInt32(comboBox.SelectedValue);
        }

        private void buttonAddOperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEquipment.SelectedValue == null)
                {
                    MessageBox.Show("Выберите оборудование.");
                    return;
                }

                if (comboBoxType.SelectedValue == null)
                {
                    MessageBox.Show("Выберите тип операции.");
                    return;
                }

                int operationTypeId = Convert.ToInt32(comboBoxType.SelectedValue);
                string operationTypeName = comboBoxType.Text;

                int equipmentId = Convert.ToInt32(comboBoxEquipment.SelectedValue);
                int? employeeId = GetNullableSelectedValue(comboBoxEmployee);
                int? fromDepartmentId = GetNullableSelectedValue(comboBoxDepartmentFrom);
                int? toDepartmentId = GetNullableSelectedValue(comboBoxDepartmentTo);

                if ((operationTypeName == "Выдача" || operationTypeName == "Смена ответственного") && !employeeId.HasValue)
                {
                    MessageBox.Show("Для этой операции нужно выбрать сотрудника.");
                    return;
                }

                if ((operationTypeName == "Перемещение" || operationTypeName == "Поступление" || operationTypeName == "Возврат")
                    && !toDepartmentId.HasValue)
                {
                    MessageBox.Show("Для этой операции нужно выбрать подразделение назначения.");
                    return;
                }

                Operation = new Operation
                {
                    OperationID = isEdit ? Operation.OperationID : 0,
                    EquipmentID = equipmentId,
                    OperationTypeID = operationTypeId,
                    EmployeeID = employeeId,
                    FromDepartmentID = fromDepartmentId,
                    ToDepartmentID = toDepartmentId,
                    OperationDate = dateTimePickerOperationDate.Value,
                    Comment = string.IsNullOrWhiteSpace(richTextBoxComment.Text)
                        ? null
                        : richTextBoxComment.Text
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}");
            }
        }
    }
}
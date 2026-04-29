using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class FixEquipmentForm : Form
    {
        public Operation Operation { get; private set; }

        private readonly OperationService _operationService = new OperationService();
        private readonly EquipmentService _equipmentService = new EquipmentService();
        private DataTable _equipmentTable;

        public FixEquipmentForm()
        {
            InitializeComponent();

            LoadData();

            dateTimePickerOperationDate.Value = DateTime.Now;
            buttonSaveFix.Text = "В ремонт";

            comboBoxEquipment.SelectedIndexChanged += ComboBoxEquipment_SelectedIndexChanged;
        }

        private void LoadData()
        {
            _equipmentTable = _equipmentService.GetEquipment();

            comboBoxEquipment.DataSource = _equipmentTable;
            comboBoxEquipment.DisplayMember = "Name";
            comboBoxEquipment.ValueMember = "EquipmentID";

            comboBoxToDepartment.DataSource = _operationService.GetDepartments();
            comboBoxToDepartment.DisplayMember = "Name";
            comboBoxToDepartment.ValueMember = "DepartmentID";

            comboBoxEquipment.SelectedIndex = 0;
            int repairDeptId = _operationService.GetRepairDepartmentId();
            comboBoxToDepartment.SelectedValue = repairDeptId;
            comboBoxToDepartment.Enabled = false;
        }

        private void ComboBoxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = comboBoxEquipment.SelectedItem as DataRowView;
            if (row == null) return;

            textBoxFromDepartment.Text = row["DepartmentName"].ToString();
        }

        private void buttonSaveFix_Click(object sender, EventArgs e)
        {
            try
            {
                var row = comboBoxEquipment.SelectedItem as DataRowView;
                if (row == null)
                {
                    MessageBox.Show("Выберите оборудование");
                    return;
                }

                int equipmentId = (int)row["EquipmentID"];
                int? fromDept = row["DepartmentID"] == DBNull.Value
                    ? null
                    : (int?)row["DepartmentID"];

                int? toDept = comboBoxToDepartment.SelectedValue == null
                    ? null
                    : (int?)comboBoxToDepartment.SelectedValue;

                Operation = new Operation
                {
                    EquipmentID = equipmentId,
                    OperationTypeID = _operationService.GetOperationTypeIdByName("Передача в ремонт"),
                    FromDepartmentID = fromDept,
                    ToDepartmentID = toDept,
                    EmployeeID = null,
                    OperationDate = dateTimePickerOperationDate.Value,
                    Comment = string.IsNullOrWhiteSpace(richTextBoxComment.Text)
                        ? null
                        : richTextBoxComment.Text.Trim()
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
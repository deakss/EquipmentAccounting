using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditEquipmentForm : Form
    {
        public Equipment Equipment{ get; private set; }
        private bool isEdit = false;

        public AddEditEquipmentForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadStatuses();
            LoadDepartments();
            LoadEmployees();
            buttonAddEquipment.Text = "Добавить";
        }

        public AddEditEquipmentForm(Equipment equipment) : this()
        {
            isEdit = true;
            buttonAddEquipment.Text = "Сохранить";

            Equipment = equipment;

            textBoxName.Text = Equipment.Name;
            textBoxInventory.Text = Equipment.InventoryNumber;
            textBoxSerial.Text = Equipment.SerialNumber;

            comboBoxCategory.SelectedValue = Equipment.CategoryID;
            comboBoxStatus.SelectedValue = Equipment.StatusID;
            comboBoxDepartment.SelectedValue = Equipment.DepartmentID;

            if (Equipment.EmployeeID.HasValue)
                comboBoxEmployee.SelectedValue = Equipment.EmployeeID.Value;
            else
                comboBoxEmployee.SelectedIndex = -1;

            dateTimePickerPurchaseDate.Value = Equipment.PurchaseDate ?? DateTime.Now;

            textBoxCost.Text = Equipment.Cost?.ToString();
            richTextBoxDescription.Text = Equipment.Description;
        }

        private void LoadCategories()
        {
            var service = new EquipmentService();
            var table = service.GetCategories();

            comboBoxCategory.DataSource = table;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "CategoryID";
        }

        private void LoadStatuses()
        {
            var service = new EquipmentService();
            var table = service.GetStatuses();

            comboBoxStatus.DataSource = table;
            comboBoxStatus.DisplayMember = "Name";
            comboBoxStatus.ValueMember = "StatusID";
        }

        private void LoadDepartments()
        {
            var service = new EmployeeService();
            var table = service.GetDepartments();

            comboBoxDepartment.DataSource = table;
            comboBoxDepartment.DisplayMember = "Name";
            comboBoxDepartment.ValueMember = "DepartmentID";
        }

        private void LoadEmployees()
        {
            var service = new EmployeeService();
            var table = service.GetEmployees();

            comboBoxEmployee.DataSource = table;
            comboBoxEmployee.DisplayMember = "FullName";
            comboBoxEmployee.ValueMember = "EmployeeID";
        }

        private void buttonAddEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                // ===== Валидация =====
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("Введите название");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxInventory.Text))
                {
                    MessageBox.Show("Введите инвентарный номер");
                    return;
                }

                // ===== Cost =====
                decimal? cost = null;
                if (!string.IsNullOrWhiteSpace(textBoxCost.Text))
                {
                    if (decimal.TryParse(textBoxCost.Text, out decimal costValue))
                        cost = costValue;
                    else
                    {
                        MessageBox.Show("Неверный формат стоимости");
                        return;
                    }
                }

                // ===== Employee (nullable) =====
                int? employeeId = null;
                if (comboBoxEmployee.SelectedValue != null &&
                    comboBoxEmployee.SelectedValue != DBNull.Value)
                {
                    employeeId = (int)comboBoxEmployee.SelectedValue;
                }

                // ===== Собираем объект =====
                Equipment = new Equipment
                {
                    EquipmentID = isEdit ? Equipment.EquipmentID : 0,
                    Name = textBoxName.Text,
                    InventoryNumber = textBoxInventory.Text,
                    SerialNumber = string.IsNullOrWhiteSpace(textBoxSerial.Text)
                        ? null
                        : textBoxSerial.Text,

                    CategoryID = (int)comboBoxCategory.SelectedValue,
                    StatusID = (int)comboBoxStatus.SelectedValue,
                    DepartmentID = (int)comboBoxDepartment.SelectedValue,

                    EmployeeID = employeeId,
                    PurchaseDate = dateTimePickerPurchaseDate.Value,
                    Cost = cost,
                    Description = string.IsNullOrWhiteSpace(richTextBoxDescription.Text)
                        ? null
                        : richTextBoxDescription.Text
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

using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditEmployeeForm : Form
    {
        public Employee Employee { get; private set; }

        private bool isEdit = false;

        public AddEditEmployeeForm()
        {
            InitializeComponent();
            LoadDepartments();
            int departmentId = (int)comboBoxDepartments.SelectedValue;
            buttonAddEmployee.Text = "Добавить";
        }

        public AddEditEmployeeForm(Employee employee) : this()
        {
            LoadDepartments();
            isEdit = true;
            buttonAddEmployee.Text = "Сохранить";

            Employee = employee;
            textBoxFullName.Text = employee.FullName;
            textBoxPosition.Text = employee.Position;
        }

        private void LoadDepartments()
        {
            var service = new EmployeeService();
            var table = service.GetDepartments();

            comboBoxDepartments.DataSource = table;
            comboBoxDepartments.DisplayMember = "Name";
            comboBoxDepartments.ValueMember = "DepartmentID";
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                MessageBox.Show("Введите ФИО");
                return;
            }

            Employee = new Employee
            {
                EmployeeID = isEdit ? Employee.EmployeeID : 0,
                FullName = textBoxFullName.Text,
                Position = textBoxPosition.Text,
                DepartmentID = (int)comboBoxDepartments.SelectedIndex + 1
            };  

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddEditEmployeeForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();

        }
    }
}
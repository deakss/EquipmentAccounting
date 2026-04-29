using EquipmentAccounting.Helpers;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditUserForm : Form
    {
        public User User { get; private set; }
        public string Password { get; private set; }

        private bool isEdit = false;

        public AddEditUserForm()
        {
            InitializeComponent();
            LoadEmployees();
            LoadRoles();
            buttonAddUser.Text = "Добавить";
            int employeeId = (int)comboBoxEmployee.SelectedValue;
            int roleId = (int)comboBoxRole.SelectedValue;
        }

        public AddEditUserForm(User user) : this()
        {
            isEdit = true;
            buttonAddUser.Text = "Сохранить";

            User = user;

            textBoxLogin.Text = user.Login;

            if (user.EmployeeID.HasValue)
                comboBoxEmployee.SelectedValue = user.EmployeeID.Value;
            else
                comboBoxEmployee.SelectedIndex = -1;

            comboBoxRole.SelectedValue = user.RoleID;
        }

        private void LoadRoles()
        {
            var service = new EmployeeService();
            var table = service.GetRoles();

            comboBoxRole.DataSource = table;
            comboBoxRole.DisplayMember = "Name";
            comboBoxRole.ValueMember = "RoleID";
        }

        private void LoadEmployees()
        {
            var service = new EmployeeService();
            var table = service.GetEmployees();

            comboBoxEmployee.DataSource = table;
            comboBoxEmployee.DisplayMember = "FullName";
            comboBoxEmployee.ValueMember = "EmployeeID";
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            Password = textBoxPassword.Text;

            User = new User
            {
                UserID = isEdit ? User.UserID : 0,
                Login = textBoxLogin.Text,
                RoleID = (int)comboBoxRole.SelectedValue,
                EmployeeID = comboBoxEmployee.SelectedValue == null || comboBoxEmployee.SelectedValue == DBNull.Value
                    ? null
                    : (int?)comboBoxEmployee.SelectedValue
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

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
            LoadEmployees();
            LoadRoles();
            isEdit = true;
            buttonAddUser.Text = "Сохранить";

            User = user;

            textBoxLogin.Text = user.Login;
            comboBoxRole.SelectedValue = user.RoleID;
            comboBoxEmployee.SelectedValue = user.EmployeeID;
            
            if (user.EmployeeID.HasValue)
            {
                comboBoxEmployee.SelectedValue = user.EmployeeID.Value;
            }
            else
            {
                comboBoxEmployee.SelectedIndex = -1;
            }

            if (user.RoleID.HasValue)
            {
                comboBoxRole.SelectedValue = user.RoleID.Value;
            }
            else
            {
                comboBoxRole.SelectedIndex = -1;
            }
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
                Login = textBoxPassword.Text,
                RoleID = (int)comboBoxRole.SelectedIndex + 1,
                EmployeeID = (int)comboBoxEmployee.SelectedIndex + 1
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

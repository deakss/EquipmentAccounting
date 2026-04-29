using EquipmentAccounting.Forms;
using EquipmentAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentAccounting
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        public enum Roles
        {
            Admin = 1,
            User = 2
        }

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            if (_currentUser.RoleID != (int)Roles.Admin)
            {
                toolStripButtonEquipment.Visible = false;
                toolStripButtonUsers.Visible = false;
                GroupBoxAdmin.Visible = false;
                toolStripFastActions.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            if (_currentUser.RoleID != (int)Roles.Admin)
            {
                toolStripButtonEquipment.Visible = false;
                toolStripButtonUsers.Visible = false;
                GroupBoxAdmin.Visible = false;
                toolStripFastActions.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            toolStripButtonMenu.Enabled = false;
        }

        private void toolStripButtonOperations_Click(object sender, EventArgs e)
        {
            this.Hide();
            var operationsForm = new OperationsForm(_currentUser);
            this.Close();
            operationsForm.ShowDialog();
        }

        private void toolStripButtonEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var equipmentForm = new EquipmentForm(_currentUser);
            this.Close();
            equipmentForm.ShowDialog();
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var employeesForm = new EmployeesForm(_currentUser);
            employeesForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}

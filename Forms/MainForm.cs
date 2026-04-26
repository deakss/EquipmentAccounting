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
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripButtonMenu.Enabled = false;
        }

        private void toolStripButtonOperations_Click(object sender, EventArgs e)
        {
            var operationsForm = new OperationsForm();
            operationsForm.Show();
        }

        private void toolStripButtonEquipment_Click(object sender, EventArgs e)
        {
            var equipmentForm = new EquipmentForm();
            equipmentForm.Show();
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            var employeesForm = new EmployeesForm();
            employeesForm.Show();
        }
    }
}

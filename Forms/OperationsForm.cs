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

namespace EquipmentAccounting.Forms
{
    public partial class OperationsForm : Form
    {
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
            toolStripButtonOperations.Enabled = false;
            
            if (_currentUser.RoleID != (int)Roles.Admin)
            {
                toolStripButtonEquipment.Visible = false;
                toolStripButtonUsers.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm(_currentUser);
            mainForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var equipmentForm = new EquipmentForm(_currentUser);
            equipmentForm.ShowDialog();
            this.Close();
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var employeesForm = new EmployeesForm(_currentUser);
            employeesForm.ShowDialog();
            this.Close();
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            toolStripButtonOperations.Enabled = false;
        }
    }
}

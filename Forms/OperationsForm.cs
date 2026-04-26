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
        public OperationsForm()
        {
            InitializeComponent();

            toolStripButtonOperations.Enabled = false;
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
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

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
    public partial class EquipmentForm : Form
    {
        public EquipmentForm()
        {
            InitializeComponent();

            toolStripButtonEquipment.Enabled = false;
        }

        private void toolStripButtonMenu_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
        }

        private void toolStripButtonOperations_Click(object sender, EventArgs e)
        {
            var operationsForm = new OperationsForm();
            operationsForm.Show();
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            var employeesForm = new EmployeesForm();
            employeesForm.Show();
        }
    }
}

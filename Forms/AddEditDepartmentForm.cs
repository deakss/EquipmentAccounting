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
using System.Xml.Linq;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditDepartmentForm : Form
    {
        public Department Department { get; private set; }
        private bool isEdit = false;

        public AddEditDepartmentForm()
        {
            InitializeComponent();
            buttonAddDepartment.Text = "Добавить";
        }

        public AddEditDepartmentForm(Department dep) : this()
        {
            isEdit = true;
            buttonAddDepartment.Text = "Сохранить";

            Department = dep;
            textBoxDepName.Text = dep.Name;
        }

        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDepName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            Department = new Department
            {
                DepartmentID = isEdit ? Department.DepartmentID : 0,
                Name = textBoxDepName.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

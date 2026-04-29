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
    public partial class AddEditStatusForm : Form
    {
        public Status Status { get; private set; }
        private bool isEdit = false;

        public AddEditStatusForm()
        {
            InitializeComponent();
            buttonAddStatus.Text = "Добавить";
        }

        public AddEditStatusForm(Status stat) : this()
        {
            isEdit = true;
            buttonAddStatus.Text = "Сохранить";

            Status = stat;
            textBoxStatusName.Text = stat.Name;
        }

        private void buttonAddStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxStatusName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            Status = new Status
            {
                StatusID = isEdit ? Status.StatusID: 0,
                Name = textBoxStatusName.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

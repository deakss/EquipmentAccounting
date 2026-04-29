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
    public partial class AddEditRoleForm: Form
    {
        public Role Role { get; private set; }
        private bool isEdit = false;

        public AddEditRoleForm()
        {
            InitializeComponent();
            buttonAddRole.Text = "Добавить";
        }

        public AddEditRoleForm(Role role) : this()
        {
            isEdit = true;
            buttonAddRole.Text = "Сохранить";

            Role = role;
            textBoxRoleName.Text = role.Name;
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRoleName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            Role = new Role
            {
                RoleID = isEdit ? Role.RoleID: 0,
                Name = textBoxRoleName.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

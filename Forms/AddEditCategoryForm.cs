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
    public partial class AddEditCategoryForm : Form
    {
        public Category Category { get; private set; }
        private bool isEdit = false;

        public AddEditCategoryForm()
        {
            InitializeComponent();
            buttonAddCategory.Text = "Добавить";
        }

        public AddEditCategoryForm(Category cat) : this()
        {
            isEdit = true;
            buttonAddCategory.Text = "Сохранить";

            Category = cat;
            textBoxCatName.Text = cat.Name;
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCatName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            Category = new Category
            {
                CategoryID = isEdit ? Category.CategoryID: 0,
                Name = textBoxCatName.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

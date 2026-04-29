using EquipmentAccounting.Models;
using System;
using System.Windows.Forms;

namespace EquipmentAccounting.Forms
{
    public partial class AddEditTypeForm : Form
    {
        public OperationType OperationType { get; private set; }
        private readonly bool isEdit;

        public AddEditTypeForm()
        {
            InitializeComponent();
            buttonAddType.Text = "Добавить";
        }

        public AddEditTypeForm(OperationType operationType) : this()
        {
            isEdit = true;
            OperationType = operationType;
            buttonAddType.Text = "Сохранить";

            textBoxTypeName.Text = operationType.Name;
        }

        private void buttonAddType_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxTypeName.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Введите название типа операции.");
                    return;
                }

                OperationType = new OperationType
                {
                    OperationTypeID = isEdit ? OperationType.OperationTypeID : 0,
                    Name = name
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using EquipmentAccounting.Forms;
using EquipmentAccounting.Models;
using EquipmentAccounting.Services;
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
        private readonly User _currentUser;
        private readonly EquipmentService _equipmentService = new EquipmentService();
        private readonly OperationService _operationService = new OperationService();

        public enum Roles
        {
            Admin = 1,
            User = 2
        }

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripLabelUser.Text = $"Пользователь: {_currentUser.Login}";
            toolStripButtonMenu.Enabled = false;
            SetupLastOpsGrid();
            LoadDashboard();
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

        private void SetupLastOpsGrid()
        {
            DataGridLastOps.AutoGenerateColumns = true;
            DataGridLastOps.ReadOnly = true;
            DataGridLastOps.AllowUserToAddRows = false;
            DataGridLastOps.AllowUserToDeleteRows = false;
            DataGridLastOps.MultiSelect = false;
            DataGridLastOps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridLastOps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDashboard()
        {
            labelTotalEquip.Text = $"Всего оборудования: {_equipmentService.GetTotalEquipmentCount().ToString()}";
            labelEquipInOper.Text = $"В работе: {_equipmentService.GetEquipmentCountByStatus("В эксплуатации").ToString()}";
            labelEquipFix.Text = $"В ремонте: {_equipmentService.GetEquipmentCountByStatus("В ремонте").ToString()}";
            labelEquipDismissed.Text = $"Списано: {_equipmentService.GetEquipmentCountByStatus("Списано").ToString()}";

            DataGridLastOps.DataSource = _operationService.GetLastOperations(5);
        }

        private void ExecuteWithTry(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonAddEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new AddEditEquipmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var equipmentService = new EquipmentService();
                    equipmentService.AddEquipment(form.Equipment);
                    LoadDashboard();
                }
            });
        }

        private void toolStripButtonMoveEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new MoveEquipmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _operationService.AddOperation(form.Operation);
                    LoadDashboard();
                }
            });
        }

        private void toolStripButtonFixEquip_Click(object sender, EventArgs e)
        {
            ExecuteWithTry(() =>
            {
                var form = new FixEquipmentForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _operationService.AddOperation(form.Operation);
                    LoadDashboard();
                }
            });
        }
    }
}

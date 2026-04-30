using EquipmentAccounting.Helpers;
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
using static EquipmentAccounting.Services.AuthService;

namespace EquipmentAccounting.Forms
{
    public partial class LoginForm : Form
    {
        public enum Roles
        {
            Admin = 1,
            User = 2
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            var authService = new AuthService();
            var user = authService.Login(login, password);

            if (user != null)
            {
                if (user.RoleID != (int)Roles.Admin)
                {
                    this.Hide();

                    var operationsForm = new OperationsForm(user);
                    operationsForm.ShowDialog();

                    this.Close();
                }
                else if (user.RoleID == (int)Roles.Admin)
                {
                    this.Hide();

                    var mainForm = new MainForm(user);
                    mainForm.ShowDialog();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}

namespace EquipmentAccounting.Forms
{
    partial class EmployeesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            this.toolStripNavBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOperations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEquipment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelUser = new System.Windows.Forms.ToolStripLabel();
            this.tabControlUsers = new System.Windows.Forms.TabControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.toolStripUsersActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddUser = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.toolStripEmployeesActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddEmployees = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.tabPageDepartments = new System.Windows.Forms.TabPage();
            this.toolStripDepartmentsActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddDepartments = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddRoles = new System.Windows.Forms.ToolStripButton();
            this.toolStripRolesActions = new System.Windows.Forms.ToolStrip();
            this.toolStripNavBar.SuspendLayout();
            this.tabControlUsers.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.toolStripUsersActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.tabPageEmployees.SuspendLayout();
            this.toolStripEmployeesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabPageDepartments.SuspendLayout();
            this.toolStripDepartmentsActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.tabPageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.toolStripRolesActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripNavBar
            // 
            this.toolStripNavBar.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMenu,
            this.toolStripSeparator3,
            this.toolStripButtonOperations,
            this.toolStripSeparator1,
            this.toolStripButtonEquipment,
            this.toolStripSeparator2,
            this.toolStripButtonUsers,
            this.toolStripButtonExit,
            this.toolStripSeparator12,
            this.toolStripLabelUser});
            this.toolStripNavBar.Location = new System.Drawing.Point(0, 0);
            this.toolStripNavBar.Name = "toolStripNavBar";
            this.toolStripNavBar.Size = new System.Drawing.Size(800, 25);
            this.toolStripNavBar.TabIndex = 6;
            this.toolStripNavBar.Text = "toolStrip1";
            // 
            // toolStripButtonMenu
            // 
            this.toolStripButtonMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMenu.Image")));
            this.toolStripButtonMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtonMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMenu.Name = "toolStripButtonMenu";
            this.toolStripButtonMenu.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonMenu.Text = "Меню";
            this.toolStripButtonMenu.Click += new System.EventHandler(this.toolStripButtonMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonOperations
            // 
            this.toolStripButtonOperations.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOperations.Image")));
            this.toolStripButtonOperations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOperations.Name = "toolStripButtonOperations";
            this.toolStripButtonOperations.Size = new System.Drawing.Size(89, 22);
            this.toolStripButtonOperations.Text = "Операции";
            this.toolStripButtonOperations.Click += new System.EventHandler(this.toolStripButtonOperations_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEquipment
            // 
            this.toolStripButtonEquipment.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEquipment.Image")));
            this.toolStripButtonEquipment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEquipment.Name = "toolStripButtonEquipment";
            this.toolStripButtonEquipment.Size = new System.Drawing.Size(115, 22);
            this.toolStripButtonEquipment.Text = "Оборудование";
            this.toolStripButtonEquipment.Click += new System.EventHandler(this.toolStripButtonEquipment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUsers
            // 
            this.toolStripButtonUsers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUsers.Image")));
            this.toolStripButtonUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUsers.Name = "toolStripButtonUsers";
            this.toolStripButtonUsers.Size = new System.Drawing.Size(114, 22);
            this.toolStripButtonUsers.Text = "Пользователи";
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonExit.Text = "Выйти";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelUser
            // 
            this.toolStripLabelUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelUser.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.toolStripLabelUser.Name = "toolStripLabelUser";
            this.toolStripLabelUser.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabelUser.Text = "Пользователь:";
            // 
            // tabControlUsers
            // 
            this.tabControlUsers.Controls.Add(this.tabPageUsers);
            this.tabControlUsers.Controls.Add(this.tabPageEmployees);
            this.tabControlUsers.Controls.Add(this.tabPageDepartments);
            this.tabControlUsers.Controls.Add(this.tabPageRoles);
            this.tabControlUsers.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.tabControlUsers.Location = new System.Drawing.Point(0, 28);
            this.tabControlUsers.Name = "tabControlUsers";
            this.tabControlUsers.SelectedIndex = 0;
            this.tabControlUsers.Size = new System.Drawing.Size(800, 424);
            this.tabControlUsers.TabIndex = 8;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.toolStripUsersActions);
            this.tabPageUsers.Controls.Add(this.dataGridViewUsers);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 23);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(792, 397);
            this.tabPageUsers.TabIndex = 0;
            this.tabPageUsers.Text = "Пользователи";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // toolStripUsersActions
            // 
            this.toolStripUsersActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripUsersActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripUsersActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonAddUser});
            this.toolStripUsersActions.Location = new System.Drawing.Point(3, 369);
            this.toolStripUsersActions.Name = "toolStripUsersActions";
            this.toolStripUsersActions.Size = new System.Drawing.Size(786, 25);
            this.toolStripUsersActions.TabIndex = 10;
            this.toolStripUsersActions.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "Действия:";
            // 
            // toolStripButtonAddUser
            // 
            this.toolStripButtonAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddUser.Image")));
            this.toolStripButtonAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddUser.Name = "toolStripButtonAddUser";
            this.toolStripButtonAddUser.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddUser.Text = "Добавить";
            this.toolStripButtonAddUser.Click += new System.EventHandler(this.toolStripButtonAddUser_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 1);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewUsers.TabIndex = 9;
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.toolStripEmployeesActions);
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 23);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(792, 397);
            this.tabPageEmployees.TabIndex = 1;
            this.tabPageEmployees.Text = "Сотрудники";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
            // 
            // toolStripEmployeesActions
            // 
            this.toolStripEmployeesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripEmployeesActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripEmployeesActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonAddEmployees});
            this.toolStripEmployeesActions.Location = new System.Drawing.Point(3, 369);
            this.toolStripEmployeesActions.Name = "toolStripEmployeesActions";
            this.toolStripEmployeesActions.Size = new System.Drawing.Size(786, 25);
            this.toolStripEmployeesActions.TabIndex = 10;
            this.toolStripEmployeesActions.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "Действия:";
            // 
            // toolStripButtonAddEmployees
            // 
            this.toolStripButtonAddEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddEmployees.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEmployees.Image")));
            this.toolStripButtonAddEmployees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEmployees.Name = "toolStripButtonAddEmployees";
            this.toolStripButtonAddEmployees.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddEmployees.Text = "Добавить";
            this.toolStripButtonAddEmployees.Click += new System.EventHandler(this.toolStripButtonAddEmployees_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(0, 1);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewEmployees.TabIndex = 9;
            // 
            // tabPageDepartments
            // 
            this.tabPageDepartments.Controls.Add(this.toolStripDepartmentsActions);
            this.tabPageDepartments.Controls.Add(this.dataGridViewDepartments);
            this.tabPageDepartments.Location = new System.Drawing.Point(4, 23);
            this.tabPageDepartments.Name = "tabPageDepartments";
            this.tabPageDepartments.Size = new System.Drawing.Size(792, 397);
            this.tabPageDepartments.TabIndex = 2;
            this.tabPageDepartments.Text = "Отделы";
            this.tabPageDepartments.UseVisualStyleBackColor = true;
            // 
            // toolStripDepartmentsActions
            // 
            this.toolStripDepartmentsActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripDepartmentsActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripDepartmentsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripButtonAddDepartments});
            this.toolStripDepartmentsActions.Location = new System.Drawing.Point(0, 372);
            this.toolStripDepartmentsActions.Name = "toolStripDepartmentsActions";
            this.toolStripDepartmentsActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripDepartmentsActions.Size = new System.Drawing.Size(792, 25);
            this.toolStripDepartmentsActions.TabIndex = 10;
            this.toolStripDepartmentsActions.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = "Действия:";
            // 
            // toolStripButtonAddDepartments
            // 
            this.toolStripButtonAddDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddDepartments.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddDepartments.Image")));
            this.toolStripButtonAddDepartments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddDepartments.Name = "toolStripButtonAddDepartments";
            this.toolStripButtonAddDepartments.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddDepartments.Text = "Добавить";
            this.toolStripButtonAddDepartments.Click += new System.EventHandler(this.toolStripButtonAddDepartments_Click);
            // 
            // dataGridViewDepartments
            // 
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewDepartments.TabIndex = 9;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Controls.Add(this.toolStripRolesActions);
            this.tabPageRoles.Controls.Add(this.dataGridViewRoles);
            this.tabPageRoles.Location = new System.Drawing.Point(4, 23);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Size = new System.Drawing.Size(792, 397);
            this.tabPageRoles.TabIndex = 3;
            this.tabPageRoles.Text = "Роли";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewRoles.TabIndex = 9;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel4.Text = "Действия:";
            // 
            // toolStripButtonAddRoles
            // 
            this.toolStripButtonAddRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddRoles.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddRoles.Image")));
            this.toolStripButtonAddRoles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddRoles.Name = "toolStripButtonAddRoles";
            this.toolStripButtonAddRoles.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddRoles.Text = "Добавить";
            this.toolStripButtonAddRoles.Click += new System.EventHandler(this.toolStripButtonAddRoles_Click);
            // 
            // toolStripRolesActions
            // 
            this.toolStripRolesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripRolesActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripRolesActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripButtonAddRoles});
            this.toolStripRolesActions.Location = new System.Drawing.Point(0, 372);
            this.toolStripRolesActions.Name = "toolStripRolesActions";
            this.toolStripRolesActions.Size = new System.Drawing.Size(792, 25);
            this.toolStripRolesActions.TabIndex = 10;
            this.toolStripRolesActions.Text = "toolStrip2";
            // 
            // EmployeesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlUsers);
            this.Controls.Add(this.toolStripNavBar);
            this.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи и сотрудники";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            this.toolStripNavBar.ResumeLayout(false);
            this.toolStripNavBar.PerformLayout();
            this.tabControlUsers.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            this.toolStripUsersActions.ResumeLayout(false);
            this.toolStripUsersActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.tabPageEmployees.ResumeLayout(false);
            this.tabPageEmployees.PerformLayout();
            this.toolStripEmployeesActions.ResumeLayout(false);
            this.toolStripEmployeesActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabPageDepartments.ResumeLayout(false);
            this.tabPageDepartments.PerformLayout();
            this.toolStripDepartmentsActions.ResumeLayout(false);
            this.toolStripDepartmentsActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.tabPageRoles.ResumeLayout(false);
            this.tabPageRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.toolStripRolesActions.ResumeLayout(false);
            this.toolStripRolesActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripNavBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonOperations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEquipment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsers;
        private System.Windows.Forms.ToolStripLabel toolStripLabelUser;
        private System.Windows.Forms.TabControl tabControlUsers;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.TabPage tabPageDepartments;
        private System.Windows.Forms.TabPage tabPageRoles;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.ToolStrip toolStripEmployeesActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEmployees;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.ToolStrip toolStripDepartmentsActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddDepartments;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStrip toolStripUsersActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddUser;
        private System.Windows.Forms.ToolStrip toolStripRolesActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddRoles;
    }
}
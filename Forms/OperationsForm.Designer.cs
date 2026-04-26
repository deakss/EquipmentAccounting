namespace EquipmentAccounting.Forms
{
    partial class OperationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationsForm));
            this.toolStripNavBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOperations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEquipment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelUser = new System.Windows.Forms.ToolStripLabel();
            this.tabControlEquipment = new System.Windows.Forms.TabControl();
            this.tabPageOperations = new System.Windows.Forms.TabPage();
            this.toolStripOperationsActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddOperations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEditOperations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelOperations = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewOperations = new System.Windows.Forms.DataGridView();
            this.tabPageOperationTypes = new System.Windows.Forms.TabPage();
            this.toolStripOperationTypesActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddOperationType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEditOperationType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelOperationType = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewOperationTypes = new System.Windows.Forms.DataGridView();
            this.toolStripNavBar.SuspendLayout();
            this.tabControlEquipment.SuspendLayout();
            this.tabPageOperations.SuspendLayout();
            this.toolStripOperationsActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).BeginInit();
            this.tabPageOperationTypes.SuspendLayout();
            this.toolStripOperationTypesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperationTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripNavBar
            // 
            this.toolStripNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMenu,
            this.toolStripSeparator3,
            this.toolStripButtonOperations,
            this.toolStripSeparator1,
            this.toolStripButtonEquipment,
            this.toolStripSeparator2,
            this.toolStripButtonUsers,
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
            this.toolStripButtonMenu.Size = new System.Drawing.Size(61, 22);
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
            this.toolStripButtonOperations.Size = new System.Drawing.Size(83, 22);
            this.toolStripButtonOperations.Text = "Операции";
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
            this.toolStripButtonEquipment.Size = new System.Drawing.Size(108, 22);
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
            this.toolStripButtonUsers.Size = new System.Drawing.Size(105, 22);
            this.toolStripButtonUsers.Text = "Пользователи";
            this.toolStripButtonUsers.Click += new System.EventHandler(this.toolStripButtonUsers_Click);
            // 
            // toolStripLabelUser
            // 
            this.toolStripLabelUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelUser.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.toolStripLabelUser.Name = "toolStripLabelUser";
            this.toolStripLabelUser.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabelUser.Text = "Пользователь:";
            // 
            // tabControlEquipment
            // 
            this.tabControlEquipment.Controls.Add(this.tabPageOperations);
            this.tabControlEquipment.Controls.Add(this.tabPageOperationTypes);
            this.tabControlEquipment.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.tabControlEquipment.Location = new System.Drawing.Point(0, 28);
            this.tabControlEquipment.Name = "tabControlEquipment";
            this.tabControlEquipment.SelectedIndex = 0;
            this.tabControlEquipment.Size = new System.Drawing.Size(800, 424);
            this.tabControlEquipment.TabIndex = 8;
            // 
            // tabPageOperations
            // 
            this.tabPageOperations.Controls.Add(this.toolStripOperationsActions);
            this.tabPageOperations.Controls.Add(this.dataGridViewOperations);
            this.tabPageOperations.Location = new System.Drawing.Point(4, 23);
            this.tabPageOperations.Name = "tabPageOperations";
            this.tabPageOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOperations.Size = new System.Drawing.Size(792, 397);
            this.tabPageOperations.TabIndex = 0;
            this.tabPageOperations.Text = "Операции";
            this.tabPageOperations.UseVisualStyleBackColor = true;
            // 
            // toolStripOperationsActions
            // 
            this.toolStripOperationsActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripOperationsActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripOperationsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonAddOperations,
            this.toolStripSeparator4,
            this.toolStripButtonEditOperations,
            this.toolStripSeparator5,
            this.toolStripButtonDelOperations});
            this.toolStripOperationsActions.Location = new System.Drawing.Point(3, 369);
            this.toolStripOperationsActions.Name = "toolStripOperationsActions";
            this.toolStripOperationsActions.Size = new System.Drawing.Size(786, 25);
            this.toolStripOperationsActions.TabIndex = 8;
            this.toolStripOperationsActions.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "Действия:";
            // 
            // toolStripButtonAddOperations
            // 
            this.toolStripButtonAddOperations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddOperations.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddOperations.Image")));
            this.toolStripButtonAddOperations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddOperations.Name = "toolStripButtonAddOperations";
            this.toolStripButtonAddOperations.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddOperations.Text = "Добавить";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEditOperations
            // 
            this.toolStripButtonEditOperations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.toolStripButtonEditOperations.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditOperations.Image")));
            this.toolStripButtonEditOperations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditOperations.Name = "toolStripButtonEditOperations";
            this.toolStripButtonEditOperations.Size = new System.Drawing.Size(119, 22);
            this.toolStripButtonEditOperations.Text = "Редактировать";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelOperations
            // 
            this.toolStripButtonDelOperations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.toolStripButtonDelOperations.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelOperations.Image")));
            this.toolStripButtonDelOperations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelOperations.Name = "toolStripButtonDelOperations";
            this.toolStripButtonDelOperations.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonDelOperations.Text = "Удалить";
            // 
            // dataGridViewOperations
            // 
            this.dataGridViewOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperations.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOperations.Name = "dataGridViewOperations";
            this.dataGridViewOperations.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewOperations.TabIndex = 0;
            // 
            // tabPageOperationTypes
            // 
            this.tabPageOperationTypes.Controls.Add(this.toolStripOperationTypesActions);
            this.tabPageOperationTypes.Controls.Add(this.dataGridViewOperationTypes);
            this.tabPageOperationTypes.Location = new System.Drawing.Point(4, 23);
            this.tabPageOperationTypes.Name = "tabPageOperationTypes";
            this.tabPageOperationTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOperationTypes.Size = new System.Drawing.Size(792, 397);
            this.tabPageOperationTypes.TabIndex = 1;
            this.tabPageOperationTypes.Text = "Типы операций";
            this.tabPageOperationTypes.UseVisualStyleBackColor = true;
            // 
            // toolStripOperationTypesActions
            // 
            this.toolStripOperationTypesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripOperationTypesActions.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.toolStripOperationTypesActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonAddOperationType,
            this.toolStripSeparator6,
            this.toolStripButtonEditOperationType,
            this.toolStripSeparator7,
            this.toolStripButtonDelOperationType});
            this.toolStripOperationTypesActions.Location = new System.Drawing.Point(3, 369);
            this.toolStripOperationTypesActions.Name = "toolStripOperationTypesActions";
            this.toolStripOperationTypesActions.Size = new System.Drawing.Size(786, 25);
            this.toolStripOperationTypesActions.TabIndex = 9;
            this.toolStripOperationTypesActions.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "Действия:";
            // 
            // toolStripButtonAddOperationType
            // 
            this.toolStripButtonAddOperationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddOperationType.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddOperationType.Image")));
            this.toolStripButtonAddOperationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddOperationType.Name = "toolStripButtonAddOperationType";
            this.toolStripButtonAddOperationType.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonAddOperationType.Text = "Добавить";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEditOperationType
            // 
            this.toolStripButtonEditOperationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.toolStripButtonEditOperationType.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditOperationType.Image")));
            this.toolStripButtonEditOperationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditOperationType.Name = "toolStripButtonEditOperationType";
            this.toolStripButtonEditOperationType.Size = new System.Drawing.Size(119, 22);
            this.toolStripButtonEditOperationType.Text = "Редактировать";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelOperationType
            // 
            this.toolStripButtonDelOperationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.toolStripButtonDelOperationType.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelOperationType.Image")));
            this.toolStripButtonDelOperationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelOperationType.Name = "toolStripButtonDelOperationType";
            this.toolStripButtonDelOperationType.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonDelOperationType.Text = "Удалить";
            // 
            // dataGridViewOperationTypes
            // 
            this.dataGridViewOperationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperationTypes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOperationTypes.Name = "dataGridViewOperationTypes";
            this.dataGridViewOperationTypes.Size = new System.Drawing.Size(792, 366);
            this.dataGridViewOperationTypes.TabIndex = 1;
            // 
            // OperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlEquipment);
            this.Controls.Add(this.toolStripNavBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperationsForm";
            this.Text = "Операции";
            this.toolStripNavBar.ResumeLayout(false);
            this.toolStripNavBar.PerformLayout();
            this.tabControlEquipment.ResumeLayout(false);
            this.tabPageOperations.ResumeLayout(false);
            this.tabPageOperations.PerformLayout();
            this.toolStripOperationsActions.ResumeLayout(false);
            this.toolStripOperationsActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).EndInit();
            this.tabPageOperationTypes.ResumeLayout(false);
            this.tabPageOperationTypes.PerformLayout();
            this.toolStripOperationTypesActions.ResumeLayout(false);
            this.toolStripOperationTypesActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperationTypes)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlEquipment;
        private System.Windows.Forms.TabPage tabPageOperations;
        private System.Windows.Forms.ToolStrip toolStripOperationsActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddOperations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditOperations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelOperations;
        private System.Windows.Forms.DataGridView dataGridViewOperations;
        private System.Windows.Forms.TabPage tabPageOperationTypes;
        private System.Windows.Forms.ToolStrip toolStripOperationTypesActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddOperationType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditOperationType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelOperationType;
        private System.Windows.Forms.DataGridView dataGridViewOperationTypes;
    }
}
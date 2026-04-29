namespace EquipmentAccounting
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.GroupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.DataGridLastOps = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTotalEquip = new System.Windows.Forms.Label();
            this.labelEquipInOper = new System.Windows.Forms.Label();
            this.labelEquipFix = new System.Windows.Forms.Label();
            this.labelEquipDismissed = new System.Windows.Forms.Label();
            this.toolStripFastActions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddEquip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMoveEquip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFixEquip = new System.Windows.Forms.ToolStripButton();
            this.toolStripNavBar.SuspendLayout();
            this.GroupBoxAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLastOps)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStripFastActions.SuspendLayout();
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
            this.toolStripButtonExit,
            this.toolStripSeparator12,
            this.toolStripLabelUser});
            this.toolStripNavBar.Location = new System.Drawing.Point(0, 0);
            this.toolStripNavBar.Name = "toolStripNavBar";
            this.toolStripNavBar.Size = new System.Drawing.Size(800, 25);
            this.toolStripNavBar.TabIndex = 5;
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
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(46, 22);
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
            // GroupBoxAdmin
            // 
            this.GroupBoxAdmin.Controls.Add(this.DataGridLastOps);
            this.GroupBoxAdmin.Controls.Add(this.flowLayoutPanel1);
            this.GroupBoxAdmin.Location = new System.Drawing.Point(0, 29);
            this.GroupBoxAdmin.Name = "GroupBoxAdmin";
            this.GroupBoxAdmin.Size = new System.Drawing.Size(800, 393);
            this.GroupBoxAdmin.TabIndex = 6;
            this.GroupBoxAdmin.TabStop = false;
            this.GroupBoxAdmin.Text = "Статистика";
            // 
            // DataGridLastOps
            // 
            this.DataGridLastOps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridLastOps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridLastOps.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DataGridLastOps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridLastOps.Location = new System.Drawing.Point(13, 59);
            this.DataGridLastOps.Name = "DataGridLastOps";
            this.DataGridLastOps.ReadOnly = true;
            this.DataGridLastOps.Size = new System.Drawing.Size(775, 328);
            this.DataGridLastOps.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelTotalEquip);
            this.flowLayoutPanel1.Controls.Add(this.labelEquipInOper);
            this.flowLayoutPanel1.Controls.Add(this.labelEquipFix);
            this.flowLayoutPanel1.Controls.Add(this.labelEquipDismissed);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 21);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(775, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelTotalEquip
            // 
            this.labelTotalEquip.AutoSize = true;
            this.labelTotalEquip.Location = new System.Drawing.Point(13, 10);
            this.labelTotalEquip.Name = "labelTotalEquip";
            this.labelTotalEquip.Size = new System.Drawing.Size(133, 15);
            this.labelTotalEquip.TabIndex = 0;
            this.labelTotalEquip.Text = "Всего оборудования:";
            // 
            // labelEquipInOper
            // 
            this.labelEquipInOper.AutoSize = true;
            this.labelEquipInOper.Location = new System.Drawing.Point(152, 10);
            this.labelEquipInOper.Name = "labelEquipInOper";
            this.labelEquipInOper.Size = new System.Drawing.Size(61, 15);
            this.labelEquipInOper.TabIndex = 1;
            this.labelEquipInOper.Text = "В работе:";
            // 
            // labelEquipFix
            // 
            this.labelEquipFix.AutoSize = true;
            this.labelEquipFix.Location = new System.Drawing.Point(219, 10);
            this.labelEquipFix.Name = "labelEquipFix";
            this.labelEquipFix.Size = new System.Drawing.Size(72, 15);
            this.labelEquipFix.TabIndex = 2;
            this.labelEquipFix.Text = "В ремонте:";
            // 
            // labelEquipDismissed
            // 
            this.labelEquipDismissed.AutoSize = true;
            this.labelEquipDismissed.Location = new System.Drawing.Point(297, 10);
            this.labelEquipDismissed.Name = "labelEquipDismissed";
            this.labelEquipDismissed.Size = new System.Drawing.Size(63, 15);
            this.labelEquipDismissed.TabIndex = 3;
            this.labelEquipDismissed.Text = "Списано:";
            // 
            // toolStripFastActions
            // 
            this.toolStripFastActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripFastActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonAddEquip,
            this.toolStripSeparator4,
            this.toolStripButtonMoveEquip,
            this.toolStripSeparator5,
            this.toolStripButtonFixEquip});
            this.toolStripFastActions.Location = new System.Drawing.Point(0, 425);
            this.toolStripFastActions.Name = "toolStripFastActions";
            this.toolStripFastActions.Size = new System.Drawing.Size(800, 25);
            this.toolStripFastActions.TabIndex = 7;
            this.toolStripFastActions.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(111, 22);
            this.toolStripLabel2.Text = "Быстрые действия:";
            // 
            // toolStripButtonAddEquip
            // 
            this.toolStripButtonAddEquip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(247)))), ((int)(((byte)(183)))));
            this.toolStripButtonAddEquip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddEquip.Image")));
            this.toolStripButtonAddEquip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEquip.Name = "toolStripButtonAddEquip";
            this.toolStripButtonAddEquip.Size = new System.Drawing.Size(161, 22);
            this.toolStripButtonAddEquip.Text = "Добавить оборудование";
            this.toolStripButtonAddEquip.Click += new System.EventHandler(this.toolStripButtonAddEquip_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMoveEquip
            // 
            this.toolStripButtonMoveEquip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.toolStripButtonMoveEquip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMoveEquip.Image")));
            this.toolStripButtonMoveEquip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveEquip.Name = "toolStripButtonMoveEquip";
            this.toolStripButtonMoveEquip.Size = new System.Drawing.Size(99, 22);
            this.toolStripButtonMoveEquip.Text = "Переместить";
            this.toolStripButtonMoveEquip.Click += new System.EventHandler(this.toolStripButtonMoveEquip_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFixEquip
            // 
            this.toolStripButtonFixEquip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(166)))));
            this.toolStripButtonFixEquip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFixEquip.Image")));
            this.toolStripButtonFixEquip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFixEquip.Name = "toolStripButtonFixEquip";
            this.toolStripButtonFixEquip.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonFixEquip.Text = "Ремонт";
            this.toolStripButtonFixEquip.Click += new System.EventHandler(this.toolStripButtonFixEquip_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripFastActions);
            this.Controls.Add(this.GroupBoxAdmin);
            this.Controls.Add(this.toolStripNavBar);
            this.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripNavBar.ResumeLayout(false);
            this.toolStripNavBar.PerformLayout();
            this.GroupBoxAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLastOps)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStripFastActions.ResumeLayout(false);
            this.toolStripFastActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripNavBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonOperations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEquipment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsers;
        private System.Windows.Forms.ToolStripLabel toolStripLabelUser;
        private System.Windows.Forms.GroupBox GroupBoxAdmin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelTotalEquip;
        private System.Windows.Forms.Label labelEquipInOper;
        private System.Windows.Forms.Label labelEquipFix;
        private System.Windows.Forms.Label labelEquipDismissed;
        private System.Windows.Forms.DataGridView DataGridLastOps;
        private System.Windows.Forms.ToolStrip toolStripFastActions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEquip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveEquip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonFixEquip;
        private System.Windows.Forms.ToolStripButton toolStripButtonMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
    }
}
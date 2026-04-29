namespace EquipmentAccounting.Forms
{
    partial class AddEditOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditOperationForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEquipment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxDepartmentFrom = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerOperationDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAddOperation = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDepartmentTo = new System.Windows.Forms.ComboBox();
            this.richTextBoxComment = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 483);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxName);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxType);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxEquipment);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxEmployee);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxDepartmentFrom);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxDepartmentTo);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerOperationDate);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.richTextBoxComment);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddOperation);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(64, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 477);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(3, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Тип операции";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(3, 61);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(150, 22);
            this.comboBoxType.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Оборудование";
            // 
            // comboBoxEquipment
            // 
            this.comboBoxEquipment.FormattingEnabled = true;
            this.comboBoxEquipment.Location = new System.Drawing.Point(3, 104);
            this.comboBoxEquipment.Name = "comboBoxEquipment";
            this.comboBoxEquipment.Size = new System.Drawing.Size(150, 22);
            this.comboBoxEquipment.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Из отдела";
            // 
            // comboBoxDepartmentFrom
            // 
            this.comboBoxDepartmentFrom.FormattingEnabled = true;
            this.comboBoxDepartmentFrom.Location = new System.Drawing.Point(3, 190);
            this.comboBoxDepartmentFrom.Name = "comboBoxDepartmentFrom";
            this.comboBoxDepartmentFrom.Size = new System.Drawing.Size(150, 22);
            this.comboBoxDepartmentFrom.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Сотрудник";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(3, 147);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(150, 22);
            this.comboBoxEmployee.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Дата операции";
            // 
            // dateTimePickerOperationDate
            // 
            this.dateTimePickerOperationDate.Location = new System.Drawing.Point(3, 276);
            this.dateTimePickerOperationDate.Name = "dateTimePickerOperationDate";
            this.dateTimePickerOperationDate.Size = new System.Drawing.Size(150, 22);
            this.dateTimePickerOperationDate.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Комментарий";
            // 
            // buttonAddOperation
            // 
            this.buttonAddOperation.Location = new System.Drawing.Point(3, 436);
            this.buttonAddOperation.Name = "buttonAddOperation";
            this.buttonAddOperation.Size = new System.Drawing.Size(150, 30);
            this.buttonAddOperation.TabIndex = 9;
            this.buttonAddOperation.Text = "Добавить";
            this.buttonAddOperation.UseVisualStyleBackColor = true;
            this.buttonAddOperation.Click += new System.EventHandler(this.buttonAddOperation_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "В отдел";
            // 
            // comboBoxDepartmentTo
            // 
            this.comboBoxDepartmentTo.FormattingEnabled = true;
            this.comboBoxDepartmentTo.Location = new System.Drawing.Point(3, 233);
            this.comboBoxDepartmentTo.Name = "comboBoxDepartmentTo";
            this.comboBoxDepartmentTo.Size = new System.Drawing.Size(150, 22);
            this.comboBoxDepartmentTo.TabIndex = 6;
            // 
            // richTextBoxComment
            // 
            this.richTextBoxComment.Location = new System.Drawing.Point(3, 319);
            this.richTextBoxComment.Name = "richTextBoxComment";
            this.richTextBoxComment.Size = new System.Drawing.Size(150, 111);
            this.richTextBoxComment.TabIndex = 8;
            this.richTextBoxComment.Text = "";
            // 
            // AddEditOperationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Roboto", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEditOperationForm";
            this.Text = "Операции";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEquipment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxDepartmentFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerOperationDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonAddOperation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDepartmentTo;
        private System.Windows.Forms.RichTextBox richTextBoxComment;
    }
}
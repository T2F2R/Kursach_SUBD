namespace Kursach_SUBD
{
    partial class InsertFormContract
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.txtClientAccountNumber = new System.Windows.Forms.TextBox();
            this.txtClientRepresentative = new System.Windows.Forms.TextBox();
            this.txtClientPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtServiceType = new System.Windows.Forms.TextBox();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.txtServiceCost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRevenue
            // 
            this.txtRevenue.Location = new System.Drawing.Point(10, 468);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.Size = new System.Drawing.Size(230, 22);
            this.txtRevenue.TabIndex = 4;
            this.txtRevenue.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(10, 424);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerOrderDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дата создания";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выручка с контракта";
            // 
            // txtClientType
            // 
            this.txtClientType.Location = new System.Drawing.Point(12, 28);
            this.txtClientType.Name = "txtClientType";
            this.txtClientType.Size = new System.Drawing.Size(230, 22);
            this.txtClientType.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Тип клиента";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Адрес клиента";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Номер счета";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Представитель клиента";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Телефон";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Вид услуги";
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(12, 72);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(230, 22);
            this.txtClientAddress.TabIndex = 15;
            // 
            // txtClientAccountNumber
            // 
            this.txtClientAccountNumber.Location = new System.Drawing.Point(12, 116);
            this.txtClientAccountNumber.Name = "txtClientAccountNumber";
            this.txtClientAccountNumber.Size = new System.Drawing.Size(230, 22);
            this.txtClientAccountNumber.TabIndex = 16;
            // 
            // txtClientRepresentative
            // 
            this.txtClientRepresentative.Location = new System.Drawing.Point(12, 160);
            this.txtClientRepresentative.Name = "txtClientRepresentative";
            this.txtClientRepresentative.Size = new System.Drawing.Size(230, 22);
            this.txtClientRepresentative.TabIndex = 17;
            // 
            // txtClientPhoneNumber
            // 
            this.txtClientPhoneNumber.Location = new System.Drawing.Point(12, 204);
            this.txtClientPhoneNumber.Name = "txtClientPhoneNumber";
            this.txtClientPhoneNumber.Size = new System.Drawing.Size(230, 22);
            this.txtClientPhoneNumber.TabIndex = 18;
            // 
            // txtServiceType
            // 
            this.txtServiceType.Location = new System.Drawing.Point(10, 248);
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.Size = new System.Drawing.Size(232, 22);
            this.txtServiceType.TabIndex = 19;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(10, 292);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(230, 22);
            this.txtServiceName.TabIndex = 20;
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(10, 380);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(230, 22);
            this.txtEmployeeId.TabIndex = 21;
            // 
            // txtServiceCost
            // 
            this.txtServiceCost.Location = new System.Drawing.Point(10, 336);
            this.txtServiceCost.Name = "txtServiceCost";
            this.txtServiceCost.Size = new System.Drawing.Size(230, 22);
            this.txtServiceCost.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Название услуги";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Стоимость услуги";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Идентификатор сотрудника";
            // 
            // InsertFormContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 529);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtServiceCost);
            this.Controls.Add(this.txtEmployeeId);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.txtServiceType);
            this.Controls.Add(this.txtClientPhoneNumber);
            this.Controls.Add(this.txtClientRepresentative);
            this.Controls.Add(this.txtClientAccountNumber);
            this.Controls.Add(this.txtClientAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClientType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerOrderDate);
            this.Controls.Add(this.txtRevenue);
            this.Controls.Add(this.button1);
            this.Name = "InsertFormContract";
            this.Text = "InsertFormContract";
            this.Load += new System.EventHandler(this.InsertFormContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRevenue;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.TextBox txtClientAccountNumber;
        private System.Windows.Forms.TextBox txtClientRepresentative;
        private System.Windows.Forms.TextBox txtClientPhoneNumber;
        private System.Windows.Forms.TextBox txtServiceType;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.TextBox txtServiceCost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
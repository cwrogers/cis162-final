namespace DisplayChecks {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.shiftsTable = new System.Windows.Forms.DataGridView();
            this.deductionsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grossPayLabel = new System.Windows.Forms.Label();
            this.netPayLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkDateLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkNumberLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shiftsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // shiftsTable
            // 
            this.shiftsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shiftsTable.Location = new System.Drawing.Point(9, 12);
            this.shiftsTable.Name = "shiftsTable";
            this.shiftsTable.Size = new System.Drawing.Size(442, 206);
            this.shiftsTable.TabIndex = 0;
            // 
            // deductionsTable
            // 
            this.deductionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deductionsTable.Location = new System.Drawing.Point(468, 12);
            this.deductionsTable.Name = "deductionsTable";
            this.deductionsTable.Size = new System.Drawing.Size(442, 206);
            this.deductionsTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gross Pay";
            // 
            // grossPayLabel
            // 
            this.grossPayLabel.Location = new System.Drawing.Point(378, 236);
            this.grossPayLabel.Name = "grossPayLabel";
            this.grossPayLabel.Size = new System.Drawing.Size(73, 13);
            this.grossPayLabel.TabIndex = 3;
            this.grossPayLabel.Text = "Gross Pay";
            this.grossPayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // netPayLabel
            // 
            this.netPayLabel.Location = new System.Drawing.Point(375, 260);
            this.netPayLabel.Name = "netPayLabel";
            this.netPayLabel.Size = new System.Drawing.Size(76, 13);
            this.netPayLabel.TabIndex = 4;
            this.netPayLabel.Text = "Net Pay";
            this.netPayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Net Pay";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(796, 389);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(114, 23);
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = "Next Employee";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 236);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Employee Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(678, 285);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Employee Name:";
            // 
            // numberLabel
            // 
            this.numberLabel.Location = new System.Drawing.Point(775, 236);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numberLabel.Size = new System.Drawing.Size(135, 13);
            this.numberLabel.TabIndex = 9;
            this.numberLabel.Text = "Number";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(772, 285);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameLabel.Size = new System.Drawing.Size(138, 13);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // departmentLabel
            // 
            this.departmentLabel.Location = new System.Drawing.Point(775, 260);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.departmentLabel.Size = new System.Drawing.Size(135, 13);
            this.departmentLabel.TabIndex = 12;
            this.departmentLabel.Text = "dept";
            this.departmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(660, 260);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Department Number:";
            // 
            // checkDateLabel
            // 
            this.checkDateLabel.Location = new System.Drawing.Point(771, 309);
            this.checkDateLabel.Name = "checkDateLabel";
            this.checkDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkDateLabel.Size = new System.Drawing.Size(138, 13);
            this.checkDateLabel.TabIndex = 14;
            this.checkDateLabel.Text = "date";
            this.checkDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(698, 309);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Check Date:";
            // 
            // checkNumberLabel
            // 
            this.checkNumberLabel.Location = new System.Drawing.Point(771, 333);
            this.checkNumberLabel.Name = "checkNumberLabel";
            this.checkNumberLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkNumberLabel.Size = new System.Drawing.Size(138, 13);
            this.checkNumberLabel.TabIndex = 16;
            this.checkNumberLabel.Text = "check#";
            this.checkNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(698, 333);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Check Number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 424);
            this.Controls.Add(this.checkNumberLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkDateLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.netPayLabel);
            this.Controls.Add(this.grossPayLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deductionsTable);
            this.Controls.Add(this.shiftsTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.shiftsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView shiftsTable;
        private System.Windows.Forms.DataGridView deductionsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label grossPayLabel;
        private System.Windows.Forms.Label netPayLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label checkDateLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label checkNumberLabel;
        private System.Windows.Forms.Label label8;
    }
}


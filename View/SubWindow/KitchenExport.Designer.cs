
namespace GetSmokingData_Techlink
{
    partial class KitchenExport
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
            this.btn_exportExcel = new XanderUI.XUIButton();
            this.dtpk_dateIn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_dateOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radbtn_getAll = new System.Windows.Forms.RadioButton();
            this.radbtn_getCorrectData = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.BackgroundColor = System.Drawing.Color.White;
            this.btn_exportExcel.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.excel;
            this.btn_exportExcel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_exportExcel.ButtonText = "Xuất báo biểu NHÀ ĂN";
            this.btn_exportExcel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_exportExcel.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.CornerRadius = 20;
            this.btn_exportExcel.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_exportExcel.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btn_exportExcel.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_exportExcel.Location = new System.Drawing.Point(59, 258);
            this.btn_exportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exportExcel.Size = new System.Drawing.Size(435, 118);
            this.btn_exportExcel.TabIndex = 5;
            this.btn_exportExcel.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // dtpk_dateIn
            // 
            this.dtpk_dateIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateIn.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtpk_dateIn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_dateIn.Location = new System.Drawing.Point(300, 129);
            this.dtpk_dateIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk_dateIn.Name = "dtpk_dateIn";
            this.dtpk_dateIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpk_dateIn.Size = new System.Drawing.Size(300, 35);
            this.dtpk_dateIn.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "ĐẾN";
            // 
            // dtpk_dateOut
            // 
            this.dtpk_dateOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateOut.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtpk_dateOut.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_dateOut.Location = new System.Drawing.Point(300, 195);
            this.dtpk_dateOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk_dateOut.Name = "dtpk_dateOut";
            this.dtpk_dateOut.Size = new System.Drawing.Size(300, 35);
            this.dtpk_dateOut.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "TỪ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(301, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 55);
            this.label3.TabIndex = 14;
            this.label3.Text = "NHÀ ĂN";
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.White;
            this.xuiButton1.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.excel;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "Xuất báo biểu nhân viên đi sai giờ";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.CornerRadius = 20;
            this.xuiButton1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(45, 426);
            this.xuiButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xuiButton1.Size = new System.Drawing.Size(448, 118);
            this.xuiButton1.TabIndex = 15;
            this.xuiButton1.TextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 379);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "* Xuất báo biểu những nhân viên chấm tay ở nhà ăn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 546);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "* Xuất báo biểu những đi ăn SAI khung giờ nghỉ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 100);
            this.panel1.TabIndex = 18;
            // 
            // radbtn_getAll
            // 
            this.radbtn_getAll.AutoSize = true;
            this.radbtn_getAll.Checked = true;
            this.radbtn_getAll.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtn_getAll.Location = new System.Drawing.Point(528, 258);
            this.radbtn_getAll.Name = "radbtn_getAll";
            this.radbtn_getAll.Size = new System.Drawing.Size(167, 26);
            this.radbtn_getAll.TabIndex = 19;
            this.radbtn_getAll.TabStop = true;
            this.radbtn_getAll.Text = "Lấy hết data gốc";
            this.radbtn_getAll.UseVisualStyleBackColor = true;
            this.radbtn_getAll.CheckedChanged += new System.EventHandler(this.radbtn_getAll_CheckedChanged);
            // 
            // radbtn_getCorrectData
            // 
            this.radbtn_getCorrectData.AutoSize = true;
            this.radbtn_getCorrectData.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtn_getCorrectData.Location = new System.Drawing.Point(528, 300);
            this.radbtn_getCorrectData.Name = "radbtn_getCorrectData";
            this.radbtn_getCorrectData.Size = new System.Drawing.Size(199, 48);
            this.radbtn_getCorrectData.TabIndex = 20;
            this.radbtn_getCorrectData.Text = "Chỉ lấy giờ lọc đúng \r\ntheo giờ nghỉ";
            this.radbtn_getCorrectData.UseVisualStyleBackColor = true;
            this.radbtn_getCorrectData.CheckedChanged += new System.EventHandler(this.radbtn_getCorrectData_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(524, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 60);
            this.label6.TabIndex = 21;
            this.label6.Text = "** Hai chế độ trên KHÔNG áp \r\ndụng cho xuất báo biểu nhân \r\nviên đi sai giờ\r\n";
            // 
            // KitchenExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(856, 593);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radbtn_getCorrectData);
            this.Controls.Add(this.radbtn_getAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.xuiButton1);
            this.Controls.Add(this.dtpk_dateIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpk_dateOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exportExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KitchenExport";
            this.Text = "KitchenExport";
            this.Load += new System.EventHandler(this.KitchenExport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XanderUI.XUIButton btn_exportExcel;
        private System.Windows.Forms.DateTimePicker dtpk_dateIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpk_dateOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private XanderUI.XUIButton xuiButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radbtn_getAll;
        private System.Windows.Forms.RadioButton radbtn_getCorrectData;
        private System.Windows.Forms.Label label6;
    }
}
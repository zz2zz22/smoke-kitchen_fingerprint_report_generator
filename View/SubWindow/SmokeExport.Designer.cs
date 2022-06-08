
namespace GetSmokingData_Techlink
{
    partial class SmokeExport
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
            this.dtpk_dateIn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpk_dateOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_exportExcel = new XanderUI.XUIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpk_dateIn
            // 
            this.dtpk_dateIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateIn.Checked = false;
            this.dtpk_dateIn.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtpk_dateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_dateIn.Location = new System.Drawing.Point(100, 57);
            this.dtpk_dateIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk_dateIn.Name = "dtpk_dateIn";
            this.dtpk_dateIn.Size = new System.Drawing.Size(300, 27);
            this.dtpk_dateIn.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "ĐẾN";
            // 
            // dtpk_dateOut
            // 
            this.dtpk_dateOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateOut.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtpk_dateOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_dateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_dateOut.Location = new System.Drawing.Point(100, 123);
            this.dtpk_dateOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk_dateOut.Name = "dtpk_dateOut";
            this.dtpk_dateOut.Size = new System.Drawing.Size(300, 27);
            this.dtpk_dateOut.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "TỪ";
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.BackgroundColor = System.Drawing.Color.White;
            this.btn_exportExcel.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.excel;
            this.btn_exportExcel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_exportExcel.ButtonText = "";
            this.btn_exportExcel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_exportExcel.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.CornerRadius = 20;
            this.btn_exportExcel.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_exportExcel.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btn_exportExcel.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.btn_exportExcel.Location = new System.Drawing.Point(171, 226);
            this.btn_exportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exportExcel.Size = new System.Drawing.Size(119, 92);
            this.btn_exportExcel.TabIndex = 10;
            this.btn_exportExcel.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Xuất dữ liệu hút thuốc";
            // 
            // SmokeExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(469, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_exportExcel);
            this.Controls.Add(this.dtpk_dateIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpk_dateOut);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmokeExport";
            this.Text = "Smoking Report";
            this.Load += new System.EventHandler(this.SmokeExport_Load);
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
    }
}


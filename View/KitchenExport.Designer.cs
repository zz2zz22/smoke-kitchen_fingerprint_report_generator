
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
            this.dtpk_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.BackgroundColor = System.Drawing.Color.White;
            this.btn_exportExcel.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.excel;
            this.btn_exportExcel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btn_exportExcel.ButtonText = "EXPORT";
            this.btn_exportExcel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_exportExcel.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.CornerRadius = 10;
            this.btn_exportExcel.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btn_exportExcel.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btn_exportExcel.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btn_exportExcel.Location = new System.Drawing.Point(344, 64);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Padding = new System.Windows.Forms.Padding(2);
            this.btn_exportExcel.Size = new System.Drawing.Size(269, 92);
            this.btn_exportExcel.TabIndex = 5;
            this.btn_exportExcel.TextColor = System.Drawing.Color.DodgerBlue;
            this.btn_exportExcel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            // 
            // dtpk_date
            // 
            this.dtpk_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_date.CustomFormat = "dd-MM-yyyy";
            this.dtpk_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_date.Location = new System.Drawing.Point(150, 96);
            this.dtpk_date.Name = "dtpk_date";
            this.dtpk_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpk_date.Size = new System.Drawing.Size(163, 27);
            this.dtpk_date.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "DATE";
            // 
            // KitchenExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(723, 230);
            this.Controls.Add(this.btn_exportExcel);
            this.Controls.Add(this.dtpk_date);
            this.Controls.Add(this.label1);
            this.Name = "KitchenExport";
            this.Text = "KitchenExport";
            this.Load += new System.EventHandler(this.KitchenExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XanderUI.XUIButton btn_exportExcel;
        private System.Windows.Forms.DateTimePicker dtpk_date;
        private System.Windows.Forms.Label label1;
    }
}
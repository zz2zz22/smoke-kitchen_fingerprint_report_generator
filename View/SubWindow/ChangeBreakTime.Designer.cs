
namespace GetSmokingData_Techlink
{
    partial class ChangeBreakTime
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
            this.lb_deptName = new System.Windows.Forms.Label();
            this.lb_deptNameInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_time1From = new System.Windows.Forms.TextBox();
            this.txb_time1To = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_breakRange = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xuiButton2 = new XanderUI.XUIButton();
            this.cbx_chooseTime = new System.Windows.Forms.ComboBox();
            this.xuibtn_closeSetting = new XanderUI.XUIButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_deptName
            // 
            this.lb_deptName.AutoSize = true;
            this.lb_deptName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_deptName.Location = new System.Drawing.Point(6, 28);
            this.lb_deptName.Name = "lb_deptName";
            this.lb_deptName.Size = new System.Drawing.Size(79, 19);
            this.lb_deptName.TabIndex = 8;
            this.lb_deptName.Text = "Bộ phận: ";
            // 
            // lb_deptNameInfo
            // 
            this.lb_deptNameInfo.AutoSize = true;
            this.lb_deptNameInfo.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_deptNameInfo.Location = new System.Drawing.Point(104, 28);
            this.lb_deptNameInfo.Name = "lb_deptNameInfo";
            this.lb_deptNameInfo.Size = new System.Drawing.Size(0, 19);
            this.lb_deptNameInfo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Giờ nghỉ:";
            // 
            // txb_time1From
            // 
            this.txb_time1From.Enabled = false;
            this.txb_time1From.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_time1From.Location = new System.Drawing.Point(63, 122);
            this.txb_time1From.Name = "txb_time1From";
            this.txb_time1From.Size = new System.Drawing.Size(179, 27);
            this.txb_time1From.TabIndex = 15;
            // 
            // txb_time1To
            // 
            this.txb_time1To.Enabled = false;
            this.txb_time1To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_time1To.Location = new System.Drawing.Point(63, 173);
            this.txb_time1To.Name = "txb_time1To";
            this.txb_time1To.Size = new System.Drawing.Size(179, 27);
            this.txb_time1To.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "đến";
            // 
            // cbx_breakRange
            // 
            this.cbx_breakRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_breakRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_breakRange.FormattingEnabled = true;
            this.cbx_breakRange.Items.AddRange(new object[] {
            "Trưa",
            "Chiều",
            "Tối",
            "Khuya"});
            this.cbx_breakRange.Location = new System.Drawing.Point(97, 71);
            this.cbx_breakRange.Name = "cbx_breakRange";
            this.cbx_breakRange.Size = new System.Drawing.Size(160, 28);
            this.cbx_breakRange.TabIndex = 33;
            this.cbx_breakRange.SelectionChangeCommitted += new System.EventHandler(this.cbx_breakRange_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.xuiButton2);
            this.groupBox1.Controls.Add(this.cbx_chooseTime);
            this.groupBox1.Controls.Add(this.lb_deptName);
            this.groupBox1.Controls.Add(this.lb_deptNameInfo);
            this.groupBox1.Controls.Add(this.cbx_breakRange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_time1To);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txb_time1From);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 221);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn giờ có sẵn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(364, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 19);
            this.label4.TabIndex = 42;
            this.label4.Text = "Chọn khung giờ mới";
            // 
            // xuiButton2
            // 
            this.xuiButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuiButton2.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.pencil;
            this.xuiButton2.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton2.ButtonText = "SỬA";
            this.xuiButton2.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton2.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton2.CornerRadius = 10;
            this.xuiButton2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton2.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton2.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton2.Location = new System.Drawing.Point(368, 113);
            this.xuiButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton2.Name = "xuiButton2";
            this.xuiButton2.Size = new System.Drawing.Size(162, 62);
            this.xuiButton2.TabIndex = 36;
            this.xuiButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.Click += new System.EventHandler(this.xuiButton2_Click);
            // 
            // cbx_chooseTime
            // 
            this.cbx_chooseTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_chooseTime.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_chooseTime.FormattingEnabled = true;
            this.cbx_chooseTime.Location = new System.Drawing.Point(368, 66);
            this.cbx_chooseTime.Name = "cbx_chooseTime";
            this.cbx_chooseTime.Size = new System.Drawing.Size(175, 27);
            this.cbx_chooseTime.TabIndex = 34;
            this.cbx_chooseTime.SelectionChangeCommitted += new System.EventHandler(this.cbx_chooseTime_SelectionChangeCommitted);
            // 
            // xuibtn_closeSetting
            // 
            this.xuibtn_closeSetting.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuibtn_closeSetting.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.cancel;
            this.xuibtn_closeSetting.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_closeSetting.ButtonText = "";
            this.xuibtn_closeSetting.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuibtn_closeSetting.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuibtn_closeSetting.CornerRadius = 10;
            this.xuibtn_closeSetting.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.xuibtn_closeSetting.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_closeSetting.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuibtn_closeSetting.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuibtn_closeSetting.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.xuibtn_closeSetting.Location = new System.Drawing.Point(615, 11);
            this.xuibtn_closeSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_closeSetting.Name = "xuibtn_closeSetting";
            this.xuibtn_closeSetting.Size = new System.Drawing.Size(67, 62);
            this.xuibtn_closeSetting.TabIndex = 6;
            this.xuibtn_closeSetting.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_closeSetting.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_closeSetting.Click += new System.EventHandler(this.xuibtn_closeSetting_Click);
            // 
            // ChangeBreakTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(699, 248);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.xuibtn_closeSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeBreakTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeBreakTime";
            this.Load += new System.EventHandler(this.ChangeBreakTime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private XanderUI.XUIButton xuibtn_closeSetting;
        private System.Windows.Forms.Label lb_deptName;
        private System.Windows.Forms.Label lb_deptNameInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_time1From;
        private System.Windows.Forms.TextBox txb_time1To;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_breakRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private XanderUI.XUIButton xuiButton2;
        private System.Windows.Forms.ComboBox cbx_chooseTime;
        private System.Windows.Forms.Label label4;
    }
}
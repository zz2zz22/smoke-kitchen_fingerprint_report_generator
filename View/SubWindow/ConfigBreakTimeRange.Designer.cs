
namespace GetSmokingData_Techlink
{
    partial class ConfigBreakTimeRange
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_breakType = new System.Windows.Forms.ComboBox();
            this.xuiButton4 = new XanderUI.XUIButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_chooseRange = new System.Windows.Forms.ComboBox();
            this.xuiButton3 = new XanderUI.XUIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_time1To2 = new System.Windows.Forms.TextBox();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.txb_Desc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_time1From2 = new System.Windows.Forms.TextBox();
            this.xuibtn_closeSetting = new XanderUI.XUIButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbx_breakType);
            this.groupBox2.Controls.Add(this.xuiButton4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbx_chooseRange);
            this.groupBox2.Controls.Add(this.xuiButton3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txb_time1To2);
            this.groupBox2.Controls.Add(this.xuiButton1);
            this.groupBox2.Controls.Add(this.txb_Desc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txb_time1From2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 475);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chỉnh các khung giờ gốc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(18, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(615, 46);
            this.label4.TabIndex = 47;
            this.label4.Text = "** Mục này sẽ chỉnh các khung giờ gốc để chon cho các chức năng khác\r\ncủa phần mề" +
    "m chỉ chỉnh sửa khi nào cần đổi hoặc thêm khung giờ\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "Chọn loại khung giờ:";
            // 
            // cbx_breakType
            // 
            this.cbx_breakType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_breakType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_breakType.FormattingEnabled = true;
            this.cbx_breakType.Items.AddRange(new object[] {
            "Trưa",
            "Chiều",
            "Tối",
            "Khuya"});
            this.cbx_breakType.Location = new System.Drawing.Point(329, 294);
            this.cbx_breakType.Name = "cbx_breakType";
            this.cbx_breakType.Size = new System.Drawing.Size(160, 28);
            this.cbx_breakType.TabIndex = 43;
            // 
            // xuiButton4
            // 
            this.xuiButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuiButton4.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.save;
            this.xuiButton4.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton4.ButtonText = "LƯU MỚI";
            this.xuiButton4.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton4.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton4.CornerRadius = 10;
            this.xuiButton4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton4.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton4.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton4.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton4.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton4.Location = new System.Drawing.Point(338, 359);
            this.xuiButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton4.Name = "xuiButton4";
            this.xuiButton4.Size = new System.Drawing.Size(184, 62);
            this.xuiButton4.TabIndex = 45;
            this.xuiButton4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton4.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton4.Click += new System.EventHandler(this.xuiButton4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nhập khung giờ:";
            // 
            // cbx_chooseRange
            // 
            this.cbx_chooseRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_chooseRange.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_chooseRange.FormattingEnabled = true;
            this.cbx_chooseRange.Items.AddRange(new object[] {
            "Trưa",
            "Chiều",
            "Tối",
            "Khuya"});
            this.cbx_chooseRange.Location = new System.Drawing.Point(23, 83);
            this.cbx_chooseRange.Name = "cbx_chooseRange";
            this.cbx_chooseRange.Size = new System.Drawing.Size(173, 27);
            this.cbx_chooseRange.TabIndex = 41;
            this.cbx_chooseRange.SelectionChangeCommitted += new System.EventHandler(this.cbx_chooseRange_SelectionChangeCommitted);
            // 
            // xuiButton3
            // 
            this.xuiButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuiButton3.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.save;
            this.xuiButton3.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton3.ButtonText = "XÓA";
            this.xuiButton3.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton3.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton3.CornerRadius = 10;
            this.xuiButton3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton3.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton3.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton3.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton3.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton3.Location = new System.Drawing.Point(431, 49);
            this.xuiButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton3.Name = "xuiButton3";
            this.xuiButton3.Size = new System.Drawing.Size(162, 62);
            this.xuiButton3.TabIndex = 44;
            this.xuiButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton3.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton3.Click += new System.EventHandler(this.xuiButton3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "Chọn khung giờ cần chỉnh";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(325, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 19);
            this.label10.TabIndex = 27;
            this.label10.Text = "Nhập mô tả:";
            // 
            // txb_time1To2
            // 
            this.txb_time1To2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_time1To2.Location = new System.Drawing.Point(84, 282);
            this.txb_time1To2.Name = "txb_time1To2";
            this.txb_time1To2.Size = new System.Drawing.Size(179, 27);
            this.txb_time1To2.TabIndex = 39;
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuiButton1.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.pencil;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "LƯU SỬA";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton1.CornerRadius = 10;
            this.xuiButton1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(241, 49);
            this.xuiButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(162, 62);
            this.xuiButton1.TabIndex = 32;
            this.xuiButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // txb_Desc
            // 
            this.txb_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Desc.Location = new System.Drawing.Point(329, 231);
            this.txb_Desc.Name = "txb_Desc";
            this.txb_Desc.Size = new System.Drawing.Size(233, 27);
            this.txb_Desc.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "đến";
            // 
            // txb_time1From2
            // 
            this.txb_time1From2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_time1From2.Location = new System.Drawing.Point(84, 231);
            this.txb_time1From2.Name = "txb_time1From2";
            this.txb_time1From2.Size = new System.Drawing.Size(179, 27);
            this.txb_time1From2.TabIndex = 38;
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
            this.xuibtn_closeSetting.Location = new System.Drawing.Point(596, 11);
            this.xuibtn_closeSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_closeSetting.Name = "xuibtn_closeSetting";
            this.xuibtn_closeSetting.Size = new System.Drawing.Size(67, 62);
            this.xuibtn_closeSetting.TabIndex = 48;
            this.xuibtn_closeSetting.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_closeSetting.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_closeSetting.Click += new System.EventHandler(this.xuibtn_closeSetting_Click);
            // 
            // ConfigBreakTimeRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(674, 565);
            this.Controls.Add(this.xuibtn_closeSetting);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigBreakTimeRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigBreakTimeRange";
            this.Load += new System.EventHandler(this.ConfigBreakTimeRange_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbx_breakType;
        private XanderUI.XUIButton xuiButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_chooseRange;
        private XanderUI.XUIButton xuiButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_time1To2;
        private XanderUI.XUIButton xuiButton1;
        private System.Windows.Forms.TextBox txb_Desc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_time1From2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private XanderUI.XUIButton xuibtn_closeSetting;
    }
}
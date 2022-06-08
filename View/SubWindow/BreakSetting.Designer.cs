
namespace GetSmokingData_Techlink
{
    partial class BreakSetting
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
            this.grb_breakSetting = new System.Windows.Forms.GroupBox();
            this.chbx_isRemoveBT = new System.Windows.Forms.CheckBox();
            this.lb_choseDeptName = new System.Windows.Forms.Label();
            this.lb_choseDept = new System.Windows.Forms.Label();
            this.lb_search = new System.Windows.Forms.Label();
            this.xuibtn_editDept = new XanderUI.XUIButton();
            this.dtgv_deptBreak = new System.Windows.Forms.DataGridView();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.xuibtn_closeSetting = new XanderUI.XUIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbx_introSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grb_breakSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_deptBreak)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_breakSetting
            // 
            this.grb_breakSetting.BackColor = System.Drawing.Color.Silver;
            this.grb_breakSetting.Controls.Add(this.panel1);
            this.grb_breakSetting.Controls.Add(this.chbx_isRemoveBT);
            this.grb_breakSetting.Controls.Add(this.lb_choseDeptName);
            this.grb_breakSetting.Controls.Add(this.lb_choseDept);
            this.grb_breakSetting.Controls.Add(this.lb_search);
            this.grb_breakSetting.Controls.Add(this.xuibtn_editDept);
            this.grb_breakSetting.Controls.Add(this.dtgv_deptBreak);
            this.grb_breakSetting.Controls.Add(this.txb_search);
            this.grb_breakSetting.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_breakSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grb_breakSetting.Location = new System.Drawing.Point(13, 86);
            this.grb_breakSetting.Name = "grb_breakSetting";
            this.grb_breakSetting.Size = new System.Drawing.Size(1077, 466);
            this.grb_breakSetting.TabIndex = 0;
            this.grb_breakSetting.TabStop = false;
            this.grb_breakSetting.Text = "Cài đặt giờ nghỉ";
            // 
            // chbx_isRemoveBT
            // 
            this.chbx_isRemoveBT.AutoSize = true;
            this.chbx_isRemoveBT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbx_isRemoveBT.Location = new System.Drawing.Point(901, 397);
            this.chbx_isRemoveBT.Name = "chbx_isRemoveBT";
            this.chbx_isRemoveBT.Size = new System.Drawing.Size(170, 42);
            this.chbx_isRemoveBT.TabIndex = 9;
            this.chbx_isRemoveBT.Text = "Bỏ qua các dữ liệu \r\ntrong giờ nghỉ";
            this.chbx_isRemoveBT.UseVisualStyleBackColor = true;
            this.chbx_isRemoveBT.CheckedChanged += new System.EventHandler(this.chbx_isRemoveBT_CheckedChanged);
            // 
            // lb_choseDeptName
            // 
            this.lb_choseDeptName.AutoSize = true;
            this.lb_choseDeptName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_choseDeptName.Location = new System.Drawing.Point(56, 403);
            this.lb_choseDeptName.Name = "lb_choseDeptName";
            this.lb_choseDeptName.Size = new System.Drawing.Size(0, 26);
            this.lb_choseDeptName.TabIndex = 8;
            // 
            // lb_choseDept
            // 
            this.lb_choseDept.AutoSize = true;
            this.lb_choseDept.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_choseDept.Location = new System.Drawing.Point(21, 370);
            this.lb_choseDept.Name = "lb_choseDept";
            this.lb_choseDept.Size = new System.Drawing.Size(200, 21);
            this.lb_choseDept.TabIndex = 7;
            this.lb_choseDept.Text = "Bộ phận đang được chọn";
            // 
            // lb_search
            // 
            this.lb_search.AutoSize = true;
            this.lb_search.Location = new System.Drawing.Point(11, 51);
            this.lb_search.Name = "lb_search";
            this.lb_search.Size = new System.Drawing.Size(88, 22);
            this.lb_search.TabIndex = 6;
            this.lb_search.Text = "Tìm kiếm";
            // 
            // xuibtn_editDept
            // 
            this.xuibtn_editDept.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.xuibtn_editDept.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.pencil;
            this.xuibtn_editDept.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_editDept.ButtonText = "";
            this.xuibtn_editDept.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuibtn_editDept.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuibtn_editDept.CornerRadius = 10;
            this.xuibtn_editDept.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.xuibtn_editDept.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_editDept.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuibtn_editDept.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuibtn_editDept.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.xuibtn_editDept.Location = new System.Drawing.Point(411, 388);
            this.xuibtn_editDept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_editDept.Name = "xuibtn_editDept";
            this.xuibtn_editDept.Size = new System.Drawing.Size(67, 62);
            this.xuibtn_editDept.TabIndex = 5;
            this.xuibtn_editDept.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_editDept.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_editDept.Click += new System.EventHandler(this.xuibtn_editDept_Click);
            // 
            // dtgv_deptBreak
            // 
            this.dtgv_deptBreak.AllowUserToAddRows = false;
            this.dtgv_deptBreak.AllowUserToDeleteRows = false;
            this.dtgv_deptBreak.AllowUserToOrderColumns = true;
            this.dtgv_deptBreak.AllowUserToResizeRows = false;
            this.dtgv_deptBreak.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgv_deptBreak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_deptBreak.Location = new System.Drawing.Point(7, 83);
            this.dtgv_deptBreak.MultiSelect = false;
            this.dtgv_deptBreak.Name = "dtgv_deptBreak";
            this.dtgv_deptBreak.ReadOnly = true;
            this.dtgv_deptBreak.RowHeadersVisible = false;
            this.dtgv_deptBreak.RowHeadersWidth = 51;
            this.dtgv_deptBreak.RowTemplate.Height = 24;
            this.dtgv_deptBreak.Size = new System.Drawing.Size(1064, 284);
            this.dtgv_deptBreak.TabIndex = 1;
            this.dtgv_deptBreak.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_deptBreak_CellClick);
            // 
            // txb_search
            // 
            this.txb_search.Location = new System.Drawing.Point(105, 48);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(446, 28);
            this.txb_search.TabIndex = 0;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
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
            this.xuibtn_closeSetting.Location = new System.Drawing.Point(1023, 11);
            this.xuibtn_closeSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_closeSetting.Name = "xuibtn_closeSetting";
            this.xuibtn_closeSetting.Size = new System.Drawing.Size(67, 62);
            this.xuibtn_closeSetting.TabIndex = 4;
            this.xuibtn_closeSetting.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_closeSetting.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_closeSetting.Click += new System.EventHandler(this.xuibtn_closeSetting_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.cbx_introSelect);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(571, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 60);
            this.panel1.TabIndex = 5;
            // 
            // cbx_introSelect
            // 
            this.cbx_introSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_introSelect.Items.AddRange(new object[] {
            "techlinkIntro_1",
            "techlinkIntro_2"});
            this.cbx_introSelect.Location = new System.Drawing.Point(125, 17);
            this.cbx_introSelect.Name = "cbx_introSelect";
            this.cbx_introSelect.Size = new System.Drawing.Size(176, 28);
            this.cbx_introSelect.TabIndex = 1;
            this.cbx_introSelect.SelectedIndexChanged += new System.EventHandler(this.cbx_introSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intro Setting";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GetSmokingData_Techlink.Properties.Resources.logoTechlink;
            this.pictureBox1.Location = new System.Drawing.Point(-154, -56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // BreakSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1102, 564);
            this.Controls.Add(this.xuibtn_closeSetting);
            this.Controls.Add(this.grb_breakSetting);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BreakSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BreakSetting";
            this.Load += new System.EventHandler(this.BreakSetting_Load);
            this.grb_breakSetting.ResumeLayout(false);
            this.grb_breakSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_deptBreak)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_breakSetting;
        private XanderUI.XUIButton xuibtn_closeSetting;
        private XanderUI.XUIButton xuibtn_editDept;
        private System.Windows.Forms.DataGridView dtgv_deptBreak;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.Label lb_choseDeptName;
        private System.Windows.Forms.Label lb_choseDept;
        private System.Windows.Forms.Label lb_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbx_introSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chbx_isRemoveBT;
    }
}

namespace GetSmokingData_Techlink
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.xuiWidgetPanel1 = new XanderUI.XUIWidgetPanel();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.xuibtn_smoke = new XanderUI.XUIButton();
            this.xuibtn_kitchen = new XanderUI.XUIButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // xuiWidgetPanel1
            // 
            this.xuiWidgetPanel1.ControlsAsWidgets = true;
            this.xuiWidgetPanel1.Location = new System.Drawing.Point(348, 11);
            this.xuiWidgetPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.xuiWidgetPanel1.Name = "xuiWidgetPanel1";
            this.xuiWidgetPanel1.Size = new System.Drawing.Size(732, 542);
            this.xuiWidgetPanel1.TabIndex = 1;
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuiButton1.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.close;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton1.CornerRadius = 45;
            this.xuiButton1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Center;
            this.xuiButton1.Location = new System.Drawing.Point(23, 475);
            this.xuiButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(67, 65);
            this.xuiButton1.TabIndex = 3;
            this.xuiButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // xuibtn_smoke
            // 
            this.xuibtn_smoke.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuibtn_smoke.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.smokeCactusE;
            this.xuibtn_smoke.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_smoke.ButtonText = "SMOKE REPORT";
            this.xuibtn_smoke.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuibtn_smoke.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuibtn_smoke.CornerRadius = 50;
            this.xuibtn_smoke.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuibtn_smoke.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_smoke.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuibtn_smoke.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuibtn_smoke.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuibtn_smoke.Location = new System.Drawing.Point(12, 104);
            this.xuibtn_smoke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_smoke.Name = "xuibtn_smoke";
            this.xuibtn_smoke.Size = new System.Drawing.Size(330, 131);
            this.xuibtn_smoke.TabIndex = 1;
            this.xuibtn_smoke.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_smoke.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_smoke.Click += new System.EventHandler(this.xuibtn_smoke_Click);
            // 
            // xuibtn_kitchen
            // 
            this.xuibtn_kitchen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.xuibtn_kitchen.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.catChef;
            this.xuibtn_kitchen.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_kitchen.ButtonText = "KITCHEN REPORT";
            this.xuibtn_kitchen.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuibtn_kitchen.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuibtn_kitchen.CornerRadius = 50;
            this.xuibtn_kitchen.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.xuibtn_kitchen.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_kitchen.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuibtn_kitchen.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuibtn_kitchen.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuibtn_kitchen.Location = new System.Drawing.Point(12, 248);
            this.xuibtn_kitchen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xuibtn_kitchen.Name = "xuibtn_kitchen";
            this.xuibtn_kitchen.Size = new System.Drawing.Size(330, 127);
            this.xuibtn_kitchen.TabIndex = 2;
            this.xuibtn_kitchen.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.xuibtn_kitchen.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_kitchen.Click += new System.EventHandler(this.xuibtn_kitchen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GetSmokingData_Techlink.Properties.Resources.logoTechlink;
            this.pictureBox1.Location = new System.Drawing.Point(-145, -35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(553, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1092, 564);
            this.Controls.Add(this.xuiButton1);
            this.Controls.Add(this.xuibtn_smoke);
            this.Controls.Add(this.xuibtn_kitchen);
            this.Controls.Add(this.xuiWidgetPanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Get Smoke & Kitchen Report - beta vesion";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private XanderUI.XUIButton xuibtn_smoke;
        private XanderUI.XUIButton xuibtn_kitchen;
        private XanderUI.XUIWidgetPanel xuiWidgetPanel1;
        private XanderUI.XUIButton xuiButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
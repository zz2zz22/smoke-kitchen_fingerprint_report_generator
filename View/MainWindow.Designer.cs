
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
            this.tlp_mainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.xuiWidgetPanel1 = new XanderUI.XUIWidgetPanel();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.xuibtn_smoke = new XanderUI.XUIButton();
            this.xuibtn_kitchen = new XanderUI.XUIButton();
            this.tlp_mainWindow.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_mainWindow
            // 
            this.tlp_mainWindow.ColumnCount = 1;
            this.tlp_mainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_mainWindow.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlp_mainWindow.Controls.Add(this.xuiWidgetPanel1, 0, 1);
            this.tlp_mainWindow.Location = new System.Drawing.Point(5, 111);
            this.tlp_mainWindow.Name = "tlp_mainWindow";
            this.tlp_mainWindow.RowCount = 2;
            this.tlp_mainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_mainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_mainWindow.Size = new System.Drawing.Size(747, 445);
            this.tlp_mainWindow.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.xuibtn_smoke, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.xuibtn_kitchen, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(741, 156);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // xuiWidgetPanel1
            // 
            this.xuiWidgetPanel1.ControlsAsWidgets = false;
            this.xuiWidgetPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiWidgetPanel1.Location = new System.Drawing.Point(3, 165);
            this.xuiWidgetPanel1.Name = "xuiWidgetPanel1";
            this.xuiWidgetPanel1.Size = new System.Drawing.Size(741, 277);
            this.xuiWidgetPanel1.TabIndex = 1;
            // 
            // pic_logo
            // 
            this.pic_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_logo.Image")));
            this.pic_logo.Location = new System.Drawing.Point(8, 12);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(744, 93);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_logo.TabIndex = 6;
            this.pic_logo.TabStop = false;
            // 
            // xuibtn_smoke
            // 
            this.xuibtn_smoke.BackgroundColor = System.Drawing.Color.White;
            this.xuibtn_smoke.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.smokeCactusE;
            this.xuibtn_smoke.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_smoke.ButtonText = "SMOKE REPORT";
            this.xuibtn_smoke.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.xuibtn_smoke.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_smoke.CornerRadius = 5;
            this.xuibtn_smoke.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuibtn_smoke.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_smoke.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xuibtn_smoke.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_smoke.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuibtn_smoke.Location = new System.Drawing.Point(3, 3);
            this.xuibtn_smoke.Name = "xuibtn_smoke";
            this.xuibtn_smoke.Size = new System.Drawing.Size(364, 150);
            this.xuibtn_smoke.TabIndex = 1;
            this.xuibtn_smoke.TextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_smoke.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_smoke.Click += new System.EventHandler(this.xuibtn_smoke_Click);
            // 
            // xuibtn_kitchen
            // 
            this.xuibtn_kitchen.BackgroundColor = System.Drawing.Color.White;
            this.xuibtn_kitchen.ButtonImage = global::GetSmokingData_Techlink.Properties.Resources.catChef;
            this.xuibtn_kitchen.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuibtn_kitchen.ButtonText = "KITCHEN REPORT";
            this.xuibtn_kitchen.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.xuibtn_kitchen.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_kitchen.CornerRadius = 5;
            this.xuibtn_kitchen.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuibtn_kitchen.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_kitchen.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xuibtn_kitchen.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_kitchen.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuibtn_kitchen.Location = new System.Drawing.Point(373, 3);
            this.xuibtn_kitchen.Name = "xuibtn_kitchen";
            this.xuibtn_kitchen.Size = new System.Drawing.Size(365, 150);
            this.xuibtn_kitchen.TabIndex = 2;
            this.xuibtn_kitchen.TextColor = System.Drawing.Color.DodgerBlue;
            this.xuibtn_kitchen.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuibtn_kitchen.Click += new System.EventHandler(this.xuibtn_kitchen_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 568);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.tlp_mainWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Smoke & Kitchen Report - beta vesion";
            this.tlp_mainWindow.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_mainWindow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private XanderUI.XUIButton xuibtn_smoke;
        private XanderUI.XUIButton xuibtn_kitchen;
        private XanderUI.XUIWidgetPanel xuiWidgetPanel1;
        private System.Windows.Forms.PictureBox pic_logo;
    }
}
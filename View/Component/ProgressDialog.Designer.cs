
namespace GetSmokingData_Techlink
{
    partial class ProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialog));
            this.lb_announce = new System.Windows.Forms.Label();
            this.progressBar1 = new XanderUI.XUIFlatProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_announce
            // 
            this.lb_announce.AutoSize = true;
            this.lb_announce.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_announce.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_announce.Location = new System.Drawing.Point(266, 128);
            this.lb_announce.Name = "lb_announce";
            this.lb_announce.Size = new System.Drawing.Size(187, 19);
            this.lb_announce.TabIndex = 1;
            this.lb_announce.Text = "Loading ... Please wait...";
            // 
            // progressBar1
            // 
            this.progressBar1.BarStyle = XanderUI.XUIFlatProgressBar.Style.Material;
            this.progressBar1.BarThickness = 5;
            this.progressBar1.CompleteColor = System.Drawing.Color.Yellow;
            this.progressBar1.InocmpletedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressBar1.Location = new System.Drawing.Point(3, 6);
            this.progressBar1.MaxValue = 100;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(353, 36);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Text = "xuiFlatProgressBar1";
            this.progressBar1.Value = 50;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(267, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 50);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GetSmokingData_Techlink.Properties.Resources.load;
            this.pictureBox1.Location = new System.Drawing.Point(-62, -31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 250);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_announce);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(644, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(644, 250);
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_announce;
        private XanderUI.XUIFlatProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
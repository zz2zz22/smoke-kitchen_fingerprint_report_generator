using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            xuiWidgetPanel1.Controls.Add(childForm);
            xuiWidgetPanel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void xuibtn_smoke_Click(object sender, EventArgs e)
        {
            openChildForm(new SmokeExport());
        }

        private void xuibtn_kitchen_Click(object sender, EventArgs e)
        {
            openChildForm(new KitchenExport());
        }

        
    }
}

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
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int progress, string announce)
        {
            lb_announce.BeginInvoke(
                new Action(() =>
                {
                    lb_announce.Text = announce + progress + "%";
                }));
            progressBar1.BeginInvoke(
                new Action(() =>
                {
                    progressBar1.Value = progress;
                }
            ));
        }
    }
}

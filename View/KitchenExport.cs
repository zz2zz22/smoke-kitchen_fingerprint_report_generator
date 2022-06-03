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
    public partial class KitchenExport : Form
    {
        public KitchenExport()
        {
            InitializeComponent();
        }

        private void KitchenExport_Load(object sender, EventArgs e)
        {
            dtpk_date.Value = DateTime.Now.AddDays(-1);
        }
    }
}

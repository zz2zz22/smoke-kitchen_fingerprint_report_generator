using GetSmokingData_Techlink.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public partial class HomeWindow : Form
    {
        public HomeWindow()
        {
            InitializeComponent();
            LoadGifToPictureBox loadGifToPictureBox = new LoadGifToPictureBox();
            loadGifToPictureBox.Intro_Load(pictureBox1, "umaru");
        }

        
    }
}

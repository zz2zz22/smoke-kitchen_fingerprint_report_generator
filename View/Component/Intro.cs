using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GetSmokingData_Techlink.Properties;
using System.Drawing.Imaging;

namespace GetSmokingData_Techlink
{
    public partial class Intro : Form
    {
        static Image[] images;
        int frameCount = 0;
        public Intro()
        {
            InitializeComponent();    
        }
        Image[] getFrames(Image originalImg)
        {
            int numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);
            Image[] frames = new Image[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                originalImg.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = ((Image)originalImg.Clone());
            }

            return frames;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            pictureBox1.Image = images[frameCount];
            frameCount++;
            if (frameCount > images.Length - 1)
                frameCount = 0;
        }
        private void Intro_Load(object sender, EventArgs e)
        {
            object techlinkIntro = Resources.ResourceManager.GetObject("techlinkIntro");
            images = getFrames((Image)techlinkIntro);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 45;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
    }
}

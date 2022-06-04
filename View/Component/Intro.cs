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
        //Timer t1 = new Timer();
        public Intro()
        {
            InitializeComponent();
            //Opacity = 0;      //first the opacity is 0
            //t1.Interval = 20;  //we'll increase the opacity every 10ms
            //t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            //t1.Start();
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
        //void fadeIn(object sender, EventArgs e)
        //{
        //    if (Opacity >= 1)
        //        t1.Stop();   //this stops the timer if the form is completely displayed
        //    else
        //        Opacity += 0.05;
        //}
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

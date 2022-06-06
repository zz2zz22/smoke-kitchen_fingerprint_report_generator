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
        Timer t1 = new Timer();
        Timer t2 = new Timer();
        System.Timers.Timer timer = new System.Timers.Timer();
        public Intro()
        {
            InitializeComponent();
            Opacity = 0;      //first the opacity is 0
            t1.Interval = 20;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }
        
        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                Opacity += 0.05;
        }
        #region LoadIntro
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
        
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            pictureBox1.Image = images[frameCount];
            frameCount++;
            if (frameCount > images.Length - 1)
            {
                frameCount = 0;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog();
            this.Close();
        }
        private void Intro_Load(object sender, EventArgs e)
        {
            object techlinkIntro = Resources.ResourceManager.GetObject("techlinkIntro"); // Doi intro bang ten trong resource
            images = getFrames((Image)techlinkIntro);

            timer.Interval = 60;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            t2.Interval = images.Length * 60;
            t2.Tick += Timer_Tick;
            t2.Start();
        }
        #endregion
    }
}

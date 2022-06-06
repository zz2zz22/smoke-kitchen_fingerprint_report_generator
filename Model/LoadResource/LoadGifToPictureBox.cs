using GetSmokingData_Techlink.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public class LoadGifToPictureBox
    {
        static Image[] images;
        int frameCount = 0;
        Timer t1 = new Timer();
        
        System.Timers.Timer timer = new System.Timers.Timer();
        
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

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e, PictureBox ptb)
        {
            ptb.Image = images[frameCount];
            frameCount++;
            if (frameCount > images.Length - 1)
            {
                frameCount = 0;
            }
        }

        public void Intro_Load(PictureBox ptb, string PicName)
        {
            object techlinkIntro = Resources.ResourceManager.GetObject(PicName); // Doi intro bang ten trong resource
            images = getFrames((Image)techlinkIntro);

            timer.Interval = 60;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((sender, e) => Timer_Elapsed(sender, e, ptb));
            timer.Start();
        }
    }
}

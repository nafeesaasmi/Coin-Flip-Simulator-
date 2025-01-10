using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace CulmProject
{
    public partial class Animation : UserControl
    {
        
        public enum Modes
        {
            CoinFlip,
            Stop
        }

        private int frame = 0;
        private Modes mode = Modes.CoinFlip;
        private DispatcherTimer? timer;

        List<BitmapImage>? imgCoinFlip;
        

        public Animation()
        {
            InitializeComponent();
        }

        public void Initiate(int goldFrames, string coinFileName, double speed)
        {
            imgCoinFlip = new List<BitmapImage>(goldFrames);
            for (int i = 1; i <= goldFrames; i++)
            {
                imgCoinFlip.Add(new BitmapImage(new Uri("pack://application:,,,/images/" + coinFileName + "-" + i + ".PNG")));
            }
            image.Source = imgCoinFlip.ElementAt(0);

            this.timer = new DispatcherTimer(DispatcherPriority.Render);
            this.timer.Interval = TimeSpan.FromMilliseconds(speed);
            this.timer.Tick += new EventHandler(this.updateImage);
            this.timer.Start();
        }

        // called every time the timer goes off (ie: every frame)
        private void updateImage(object? sender, EventArgs e)
        {
            if (imgCoinFlip != null)  // must ensure the lists are instantiated
            {
                List<BitmapImage> currImages = imgCoinFlip;

                image.Source = currImages.ElementAt(frame);
                frame++;

                // check if we've seen all the images
                if (frame >= currImages.Count)
                {
                    switch (mode)
                    {
                        case Modes.CoinFlip:
                            setMode(Modes.CoinFlip);
                            break;
                    }
                    frame = currImages.Count - 1;
                }
            }
        }

        // change the current animation
        public void setMode(Modes mode)
        {
            this.mode = mode;
            frame = 0;
        }
    }
}

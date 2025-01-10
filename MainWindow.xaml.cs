using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CulmProject
{
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            MainVisible();
            FlipPageHidden();
            EndHidden();
            cmbResult.Visibility = Visibility.Hidden;
            imgGoldHeads.Visibility = Visibility.Hidden;
            imgGoldTails.Visibility = Visibility.Hidden;
            lblResult.Visibility = Visibility.Hidden;
        }

        private void cmbStart_Click(object sender, RoutedEventArgs e)
        {
            MainHidden();
            FlipPageVisilble();
            cmbFlip.Visibility = Visibility.Hidden;
        }



        private void rbHeads_Checked(object sender, RoutedEventArgs e)
        {
            aniFlip.setMode(Animation.Modes.CoinFlip);
            cmbFlip.Visibility = Visibility.Visible;
        }
        private void rbTails_Checked(object sender, RoutedEventArgs e)
        {
            aniFlip.setMode(Animation.Modes.CoinFlip);
            cmbFlip.Visibility= Visibility.Visible;
        }



        private void cmbFlip_Click(object sender, RoutedEventArgs e)
        {
            ViewResult();
            aniFlip.Initiate(10, "GoldFlip", 75);
        }

        private void cmbResult_Click(object sender, RoutedEventArgs e)
        {
            FlipPageHidden();
            EndVisible();

            int cf = rand.Next(1, 3);

            //1 is tails and 2 is heads
            //make this appear on the endscreen

            if (cf == 1 && rbTails.IsChecked == true)
            {
                lblWinOrLose.Content = "You Win";
                imgGoldTails.Visibility = Visibility.Visible;
                lblResult.Content = "It was Tails!";
                lblResult.Visibility = Visibility.Visible;
            }
            else if(cf == 2 && rbTails.IsChecked == true)
            {
                lblWinOrLose.Content = "You Lose";
                imgGoldHeads.Visibility = Visibility.Visible;
                lblResult.Content = "It was Heads!";
                lblResult.Visibility = Visibility.Visible;
            }
            else if(cf == 1 && rbHeads.IsChecked == true)
            {
                lblWinOrLose.Content = "You Lose";
                imgGoldTails.Visibility = Visibility.Visible;
                lblResult.Content = "It was Tails!";
                lblResult.Visibility = Visibility.Visible;
            }
            else if(cf == 2 && rbHeads.IsChecked == true)
            {
                lblWinOrLose.Content = "You Win";
                imgGoldHeads.Visibility = Visibility.Visible;
                lblResult.Content = "It was Heads!";
                lblResult.Visibility = Visibility.Visible;
            }
        }

        public void MainVisible()
        {
            lblName.Visibility = Visibility.Visible;
            cmbStart.Visibility = Visibility.Visible;
        }

        public void MainHidden()
        {
            lblName.Visibility = Visibility.Hidden;
            cmbStart.Visibility = Visibility.Hidden;
        }

        public void FlipPageVisilble()
        {
            cmbFlip.Visibility = Visibility.Visible;
            rbHeads.Visibility = Visibility.Visible;
            rbTails.Visibility = Visibility.Visible;
        }

        public void FlipPageHidden()
        {
            cmbFlip.Visibility = Visibility.Hidden;
            cmbResult.Visibility = Visibility.Hidden;
            rbTails.Visibility = Visibility.Hidden;
            rbHeads.Visibility = Visibility.Hidden;
        }

        public void ViewResult()
        {
            cmbResult.Visibility = Visibility.Visible;
            cmbFlip.Visibility = Visibility.Hidden;
        }

        public void EndHidden()
        {
            lblWinOrLose.Visibility = Visibility.Hidden;   

        }

        public void EndVisible()
        {
            lblWinOrLose.Visibility = Visibility.Visible;
        }
    }
}
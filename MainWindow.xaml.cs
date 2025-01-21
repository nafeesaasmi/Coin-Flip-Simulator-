using System.Diagnostics.PerformanceData;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
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
        CoinFlip coinflip; //instantiate class 



        public MainWindow()
        {
            InitializeComponent(); // setting visibility  
            MainVisible(); 
            FlipPageHidden();
            EndHidden();
            CoinNumHidden();
            SliderHidden();
            cmbResult.Visibility = Visibility.Hidden;
            imgGoldHeads.Visibility = Visibility.Hidden;
            imgGoldTails.Visibility = Visibility.Hidden;
            lblResult.Visibility = Visibility.Hidden;
            ChoiceHidden();
            lblManipulatedTitle.Visibility = Visibility.Hidden;
            lblRandomTitle.Visibility = Visibility.Hidden;
            cmbFlip.Visibility = Visibility.Hidden;
            imgBackground.Visibility = Visibility.Hidden;
            lblPercent.Visibility = Visibility.Hidden;
            lblHeadsorTails.Visibility = Visibility.Hidden;
            lblTotalFlipped.Visibility = Visibility.Hidden;


            coinflip = new CoinFlip(); // instantiate coinflip 


        }

        private void cmbStart_Click(object sender, RoutedEventArgs e)
        {
            MainHidden(); // setting visibility  when start button is pressed 
            CoinNumVisible();
            imgBackground.Visibility = Visibility.Visible;
        }
        private void cmbConfirm_Click(object sender, RoutedEventArgs e)
        {

            int input = Convert.ToInt32(txtInput.Text); // getting user input for the amount of coins 
            coinflip.coinNum = input; // setting that input to coinNum
            
            CoinNumHidden(); // setting visibility  
            ChoiceVisible();
        }

        private void rbHeads_Checked(object sender, RoutedEventArgs e)
        {
            aniFlip.setMode(Animation.Modes.CoinFlip);// Making the animation work when you click heads or  tails 
        }
        private void rbTails_Checked(object sender, RoutedEventArgs e)
        {
            aniFlip.setMode(Animation.Modes.CoinFlip);// Making the animation work when you click heads or  tails
        }

        private void rbManipulate_Checked(object sender, RoutedEventArgs e)
        {
            ChoiceHidden(); // setting visibility  
            cmbFlip.Visibility = Visibility.Visible;
            lblPercent.Visibility= Visibility.Visible;
            SliderVisible();
            lblSlider.Content = "0%"; // setting default slider lable to 0% 
        }
        private void rbRandom_Checked(object sender, RoutedEventArgs e)
        {
            ChoiceHidden(); // setting visibility  
            FlipPageVisible();
            lblRandomTitle.Visibility= Visibility.Visible;
        }

        private void slChance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            coinflip.chance = Convert.ToInt32(slChance.Value); // setting the coinflip.chance to the integer value of the slider 
            lblSlider.Content = $"{coinflip.chance}%";// displayng that percent 
        }


        private void cmbFlip_Click(object sender, RoutedEventArgs e)
        {
            lblPercent.Visibility = Visibility.Hidden; // setting visibility  
            ViewResult();
            aniFlip.Initiate(10, "GoldFlip", 75); // instaniate the animation 
            lblManipulatedTitle.Visibility = Visibility.Hidden; // setting visibility  
            lblRandomTitle.Visibility = Visibility.Hidden;
            rbTails.Visibility = Visibility.Hidden;
            rbHeads.Visibility = Visibility.Hidden;
            SliderHidden();
            coinflip.coins(); // calling coins function  
         }

        private void cmbResult_Click(object sender, RoutedEventArgs e)
        {
            if (rbManipulate.IsChecked == true)  // checking user input and doing an action based on that 
            {
                ManipulateResult();
                EndHidden();
            }
            else if (rbRandom.IsChecked == true)
            {
                EndVisible();
                RandomResult();        
            }
            FlipPageHidden();
            aniFlip.Visibility = Visibility.Hidden; // seting visibility 
            lblPercent.Visibility = Visibility.Hidden;
            lblTotalFlipped.Visibility = Visibility.Visible;
            lblHeadsorTails.Visibility = Visibility.Visible;
            lblTotalFlipped.Content = $"You flipped {coinflip.flipResults.Length} coins!"; // displaying how many coins you have inputed 
        }

        public void ManipulateResult()
        {
            coinflip.ManipulatePercent();
            lblHeadsorTails.Content = $"{coinflip.tails} landed on tails : {coinflip.heads} landed on heads"; // displaying results of coins 

            if(coinflip.tails >= coinflip.heads) // displaying majority coins 
            {
                imgGoldTails.Visibility = Visibility.Visible;
            }
            else if(coinflip.heads > coinflip.tails)
            {
                imgGoldHeads.Visibility = Visibility.Visible;
            }
        }

        public void RandomResult()
        {
            coinflip.coins();
            //1 is tails and 2 is heads
            
            coinflip.RandomFlip();
            lblHeadsorTails.Content = $"{coinflip.tails} landed on tails : {coinflip.heads} landed on heads"; // displaying majority coins 

            if (coinflip.tails >= coinflip.heads && rbTails.IsChecked == true) // making a case for each possible outcome 
            {
                imgGoldTails.Visibility = Visibility.Visible;
                lblWinOrLose.Content = "You Were Correct"; 
            }
            else if (coinflip.heads >= coinflip.tails && rbTails.IsChecked == true)
            {
                imgGoldHeads.Visibility = Visibility.Visible;
                lblWinOrLose.Content = "You Were Wrong";
            }
            else if (coinflip.tails >= coinflip.heads && rbHeads.IsChecked == true)
            {
                imgGoldTails.Visibility = Visibility.Visible;
                lblWinOrLose.Content = "You Were Wrong";
            }
            else if (coinflip.heads >= coinflip.tails && rbHeads.IsChecked == true)
            {
                imgGoldHeads.Visibility = Visibility.Visible;
                lblWinOrLose.Content = "You Were Correct";
            }
            else if(coinflip.heads >= coinflip.tails && rbHeads.IsChecked == false)
            {
                imgGoldHeads.Visibility = Visibility.Visible;
                lblWinOrLose.Visibility = Visibility.Hidden;
            }
            else if(coinflip.tails >= coinflip.heads && rbTails.IsChecked == false)
            {
                imgGoldTails.Visibility = Visibility.Visible;
                lblWinOrLose.Visibility = Visibility.Hidden;
            }
        }


        //the following are functions to set visibilities:

        public void MainVisible()
        {
            cmbStart.Visibility = Visibility.Visible; //setting visibility
            imgTitle.Visibility = Visibility.Visible;
        }

        public void MainHidden()
        {
            cmbStart.Visibility = Visibility.Hidden;//setting visibility
            imgTitle.Visibility = Visibility.Hidden;
        }

        public void FlipPageVisible()
        {
            cmbFlip.Visibility = Visibility.Visible;//setting visibility
            rbHeads.Visibility = Visibility.Visible;
            rbTails.Visibility = Visibility.Visible;
        }

        public void FlipPageHidden()
        {
            cmbFlip.Visibility = Visibility.Hidden;//setting visibility
            cmbResult.Visibility = Visibility.Hidden;
            rbTails.Visibility = Visibility.Hidden;
            rbHeads.Visibility = Visibility.Hidden;
        }

        public void ViewResult()
        {
            cmbResult.Visibility = Visibility.Visible;//setting visibility
            cmbFlip.Visibility = Visibility.Hidden;
        }

        public void EndHidden()
        {
            lblWinOrLose.Visibility = Visibility.Hidden;   //setting visibility

        }

        public void EndVisible()
        {
            lblWinOrLose.Visibility = Visibility.Visible;//setting visibility
        }

        public void ChoiceHidden()
        {
            rbManipulate.Visibility = Visibility.Hidden;//setting visibility
            rbRandom.Visibility = Visibility.Hidden;
            lblChoice.Visibility = Visibility.Hidden;
        }
        public void ChoiceVisible()
        {
            rbManipulate.Visibility = Visibility.Visible;//setting visibility
            rbRandom.Visibility = Visibility.Visible;
            lblChoice.Visibility = Visibility.Visible;
        }
        public void CoinNumVisible()
        {
            txtInput.Visibility = Visibility.Visible;//setting visibility
            lblManipulatedTitle.Visibility = Visibility.Visible;
            cmbConfirm.Visibility = Visibility.Visible;
        }
        public void CoinNumHidden()
        {
            txtInput.Visibility = Visibility.Hidden;//setting visibility
            lblManipulatedTitle.Visibility = Visibility.Hidden;
            cmbConfirm.Visibility = Visibility.Hidden;
        }

        public void SliderVisible()
        {
            slChance.Visibility = Visibility.Visible;//setting visibility
            lblSlider.Visibility = Visibility.Visible;
        }
        public void SliderHidden()
        {
            slChance.Visibility = Visibility.Hidden;//setting visibility
            lblSlider.Visibility = Visibility.Hidden;
        }
    }
}
using CulmProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CulmProject
{
    class CoinFlip
    {
        Random rand = new Random();
        public int cf;
        public int randPercent;
        public int coinNum;
        public int chance;
        public int reading;
        public int temp;
        public int heads;
        public int tails;

        public int[] flipResults;
        public CoinFlip()
        {
            cf = 0;
            randPercent = 0;
            chance = 0;
            reading = 0;
            temp = 0;
            heads = 0;
            tails = 0;
        }

        public void Flip()
        {
            cf = rand.Next(1, 3);
        }



        public void coins()
        {
            for(int i = 0; i < coinNum; i++)
            {
                Flip();
                Array.Resize(ref flipResults, coinNum);
                flipResults[i] = cf;
            }
        }

        public void RandomFlip()
        {
            for(int i = 0;i < coinNum; i++)
            {
                if(flipResults[i] == 1)
                {
                    tails++;
                }
                else if (flipResults[i] == 2)
                {
                    heads++;
                }
            }
        }

        public void ManipulatePercent()
        {
            for(int i = 0;i < coinNum; i++)
            {
                randPercent = rand.Next(1, 101);

                if(randPercent <= chance)
                {
                    flipResults[i] = 2;
                    heads++;
                }
                else if(randPercent > chance)
                {
                    flipResults[i] = 1;
                    tails++;
                }
            }
        }
    }
}

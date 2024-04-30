using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG
{
    public class Anim
    {
        //way to animate "writing" the text.
        public static void Say(string text, int delay = 10) //The higher the delay, the longer between letters
        {
            foreach (char c in text) //iterates every character in text...
            {
                //to add the delay between each character
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }
        
        //create bars for negotiation mechanic
        public static void Negotiation(string negStat, string fill, string empty, int value) //Interest/Patience: , "█", "x", interest/patience variable 
        {
            int fillerAmount = value % 6; //get how many fillers are necessary. Use mod6 because that returns 1 when the enemy's negotiation value equals 1
            Console.Write(negStat); //type out whether it's the Interest or Patience bar
            for (int i = 0; i < 5; i++) //go through every point of the bar
            {
                if (i < fillerAmount) //when a space should be filled...
                    Console.Write(fill); //fill it with the symbol
                else //...
                    Console.Write(empty); //use the symbol for empty
            }
            Console.WriteLine(""); //linebreak
        }
    }
}

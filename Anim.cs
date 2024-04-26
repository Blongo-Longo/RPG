using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Anim
    {
        public static void Say(string text, int delay = 10) //way to animate "writing" the text. The higher the delay, the longer between letters
        {
            foreach (char c in text) //iterates every character in text...
            {
                //to add the delay between each character
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}

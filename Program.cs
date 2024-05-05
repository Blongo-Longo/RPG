using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;

namespace RPG
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
            //Encounters.FirstEncounter();
        }


        /*TODO: - After shop is created, adjust Noble and Rogue money benefit (career starting cash / extra money after battle)
         */

        static void Start()
        {
            //variables
            bool ancestChoice = false;
            bool careerChoice = false;
            char choice;
            //Preamble
            //Console.ReadKey(); //delete this - for showing people and the screen share isn't quick enough
            Anim.Say(
                "The Shopkeeper\n" +
                "A medival fantasy shop-em-up by <Some Cunt>\n" +
                "\n" //+
                //"First, Adventurer, tell me about yourself. What is your name?\n"
                );
            /*currentPlayer.playerName = Console.ReadLine();
            if (currentPlayer.playerName == "")
            {
                currentPlayer.playerName = "Dumpy";
                Anim.Say("Ah. A secret, is it? Well, in that case you will be called \"Dumpy\"\n");
            }
            Anim.Say(
                $"{currentPlayer.playerName}, tell me, which skin do you call yours?\n" +
                 "[Avian] - Cunning feathered people. Collect more coin after battles.\n" +
                 "[Chelonian] - A proud Tortoisefolk. Your shell protects you from damage.\n" +
                 "[Dwarf] - A people sturdy in body and stubborn of will. You start with more health.\n" +
                 "[Elf] - A lot of these about. Too many, if you ask me. Allrounders.\n" +
                 "[Goblin] - Clever folk, quick in mind and daggers. Retaliations hit enemies harder.\n" +
                 "[Human] - Created thousands of languages to find the best words possible. Charming, though.\n"
                 );
            while (ancestChoice == false)
            {
                ancestChoice = true;
                currentPlayer.currentAncestry = Console.ReadLine().ToLower();
                switch (currentPlayer.currentAncestry)
                {
                    case "avian": //bird. more money after fights. CHANGE TO SOMETHING BETTER LATER
                        Anim.Say("Easily distracted by shiny things.");
                        currentPlayer.playerMoneyIncrease += 5;
                        break;
                    case "chelonian": //turtle. physical def bonus
                        Anim.Say("A hard-shelled one.");
                        currentPlayer.playerFort += 1;
                        break;
                    case "dwarf": //HP bonus
                        Anim.Say("A body strong as a barrel.");
                        currentPlayer.playerMaxHP += 5;
                        currentPlayer.playerCurHP += 5;
                        break;
                    case "elf": //no bonus
                        Anim.Say("One who meddles in everything, then.");
                        break;
                    case "goblin": //counter bonus
                        Anim.Say("Quick of feet and blade.");
                        currentPlayer.playerCounter += 1;
                        break;
                    case "human": //negotiation bonus
                        Anim.Say("You look like it.");
                        currentPlayer.playerCharm += 1;
                        break;
                    default: //on invalid input
                        Anim.Say("You'll have to choose one by writing it out\n");
                        ancestChoice = false;
                        break;
                }
            }
            Anim.Say(
                $" Good Choice.\n" +
                "Now for your expertise. What is your career?\n" +
                "[Beserker] - Brutal fighters that cut down any foe. Higher base attack.\n" +
                "[Commoner] - Anyone can be an adventurer. No bonus.\n" +
                "[Guard] - Make sure you are safe to fight another day. Start with simple armour.\n" +
                "[Noble] - Who needs skills when you are wealthy? Start with extra gold.\n" +
                "[Rogue] - Your foes better hit you or suffer the consequences. Strong retaliation.\n" +
                "[Swindler] - It is other's foolish generosity to believe you quickly. Charming.\n"
                );
            while (careerChoice == false)
            {
                careerChoice = true;
                currentPlayer.currentCareer = Console.ReadLine().ToLower();
                switch (currentPlayer.currentCareer)
                {
                    case "beserker": //base attack bonus
                        Anim.Say("A ferocious foe. ");
                        currentPlayer.playerPow += 1;
                        break;
                    case "commoner": //no bonus
                        Anim.Say("Greatness comes from humble beginnings. ");
                        break;
                    //Add Duelist, Counter +1
                    case "guard": //starts with armour
                        Anim.Say("A shield incarnate. ");
                        currentPlayer.playerArmour = 1;
                        break;
                    case "noble": //munneh
                        Anim.Say("Fleeing responsibilities, are we? ");
                        currentPlayer.playerMoney += 50; //contextless value. Adjust when shops are implemented
                        break;
                    case "rogue": //Adds fixed amount to money after battle. CHANGE TO %?
                        Anim.Say("Make them pay. ");
                        currentPlayer.playerMoneyIncrease += 5; //contextless value. Adjust when shops are implemented
                        break;
                    case "swindler":
                        Anim.Say("A disarming smile can be a weapon in itself. ");
                        currentPlayer.playerCharm += 1;
                        break;
                }
            }
            */
            Anim.Say("\n" +
                "You wake up in your room. It's a shabby, simple bedroom. The light plays through the cracked window " +
                "upon a miriade of slow dancing dust particles. On your left, your coin purse sits on the night stand " +
                "as a moth flees your closet.\n"
            );
            //choice point: beginning
            Anim.Say("What do you want to do?\n");
            Anim.Say("[a] get up - [b] take a moment to fully wake - [c] lie in just five more minutes\n");
            choice = Console.ReadKey().KeyChar; //read input, convert

            switch (choice)
            {
                //get up
                case 'a':
                    Anim.Say("\n" +
                    "You quickly push the blanket to the side. Always having been one to get things over quickly, you get dressed " +
                    "and ready.\n"
                    );
                    LeaveRoom();
                    break;
                //take moment
                case 'b':
                    Anim.Say("\n" +
                    "Slowly letting the sleep drift from you, you get another cozy moment under the blankets. As the light filters " +
                    "through your window and brings you into reality, you remember the payment for your last adventure. The small " +
                    "pouch with coins sits atop the nightstand. With soft, gentle movements, you get ready.\n" +
                    "You collect your things and leave the room. Today may be a bit of a cloudy spring morning, just like yesterday. " +
                    "Hopefully it clears up over the next few hours.\n" +
                    "" +
                    "You gain 100 Gold"
                    );
                    Program.currentPlayer.playerMoney += 100;
                    Outside();
                    break;
                //five more minutes
                case 'c':
                    Anim.Say("\n" +
                    "Hm... what if... you just lay in... for... five... mo...\n" +
                    "Your conciousness slips away. The view of your room fades. The darkness slowly yields. Hazily, a pasture comes into " +
                    "view. The green grass contrasting with the clear blue skies. A huge oak tree stands proudly in the middle, branches " +
                    "outstretched as if to grab a piece of the heavens itself. The soft breeze plays in your hair and cools your body.\n" +
                    "Everywhere.\n" +
                    "You suddenly notice that you stand here, buck-naked. As blood rushes to your head, you notice that the branches of the " +
                    "tree are not just populated by leaves. Among them are a lot of woodnymphs. They are looking directly at you.\n"
                    );
                    Dream();
                    break;
                //other
                default: Anim.Say("You just lay there, unable to choose. Existance can be scary.\n"); GameOver(); break;
            }
            void LeaveRoom()
            {
                //choice point: leave room
                Anim.Say("[a] take a look around - [b] leave\n");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    //look around
                    case 'a':
                        Anim.Say("\n" +
                        "As you give the room another look, you remember your coin purse! You take it and step out.\n"
                        );
                        currentPlayer.playerMoney += 100;
                        Anim.Say($"You gain 100 coins.\n");
                        Outside();
                        break;
                    //leave
                    case 'b':
                        Anim.Say("\n" +
                            "No time to dwell, you get your coat and leave your small abode.\n"
                            );
                        Outside();
                        break;
                    //other
                    default:
                        Anim.Say("\n" +
                            "You just... stand there. A while later, you blink, shake your head and wonder how long you've been zoned out as you leave\n"
                            );
                        break;
                }
            }

            void Dream()
            {
                Anim.Say("[a] present yourself confidently - [b] hide yourself as best you can - [c] demand to know what they're doing, ogling you like this\n");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    //present confidently
                    case 'a':
                        Anim.Say("\n" +
                            "Always being one that grabs attention by the scruff of its neck and twists it, you strike a pose fully revealing your best sides " +
                            "and most interesting physical aspects. There is a murmur going though the nymphs. Like the wind blowing through leaves in waltz " +
                            "tab. You develop an ebb and flow, where they study you for an amount of time until quieting down, leading you to change your pose. " +
                            "Somewhere within this process, you wake up pleasantly. Feeling good about yourself, though unsure why. Sometimes days just start " +
                            "well, don't they?");
                        break;
                    //hide
                    case 'b':
                        Anim.Say("\n" +
                        "Thinking quickly, you dart to a close bush. It's a bit scratchy, but you feel safe now. As you look up, most of the nymphs have either " +
                        "left or just vanished (as dreams tend to do), but one remains. They have buried their face in their hands. As the wind gently roams " +
                        "around them, you can't help to feel drawn to them. Their fuller form, cracked bark-skin and beautifully autumnal leaves just speak to you. " +
                        "You notice that you are now the one ogling and quickly look down to the grass. Just as you feel the confidence to talk to them, they raise " +
                        "their head from their hands. You see a beautiful face, eyes shyly darting to your direction.\n They smile, open their mouth and greet " +
                        "you with a soft\n" +
                        "\"PIG GUTS! FRESH AND LOVELY PIG GUTS!\"\n" +
                        "You jerk awake, damning the butcher next door for waking you so rudely. You are about to throw the blanket to the side and really tell " +
                        "him your opinion, but before you can something faintly touches the back of your hand.\n" +
                        "It is a single leaf that must've been blown in through your window. It has the most beautiful sunset-red colouration you have ever seen. " +
                        "\'How odd.\' you think, \'Isn't it Spring?\'\n" +
                        "Whatever the case may be, you decide to take it with you. It's really beautiful.\n" +
                        "You gained (Soph-miro's Leaf)"
                        );
                        currentPlayer.inventory.Add("soph-miro's leaf"); //The nymph's leaf, named after extinct Sophora Toromiro Tree
                        break;
                    //demand answers
                    case 'c':
                        Anim.Say("\n" +
                        "\"What are you gawking at, huh?\" your voice rings out over the long grass, starling the woodland creatures. \"At least " +
                        "say something nice!\" Surprised that a mortal would talk to them this way, most of them seem to vanish into the canopy. One stays. " +
                        "Their body is covered with brilliant flowers of all shapes and colours. They give you a daring smirk, tilt their head and call out: " +
                        "\"Oh, there is nice to be said about me, but you? How could a mere human like you even know the word beautiful before meeting me? " +
                        "Much less think they should be compared such?\"\n" +
                        "What do you answer?\n" +
                        "\"[a] I said something nice, not beautiful. However did you come to that conclusion?\" (daring the nymph)\n\"[b] Uh, please don't mind me!\" (retreating)\n"
                        );
                        choice = Console.ReadKey().KeyChar;
                        switch (choice)
                        {
                            //dare the nymph
                            case 'a':
                                Anim.Say("\n" +
                                    "The nymph's smile grows. There is a fire in their eyes. \"I suppose\", she responds, \"you are not horribly different from us.\" " +
                                    "Their gaze wanders over you. \"But arrogance is cheap, young person. There is but one thing I am interested in. It's just a " +
                                    "matter of whether you can keep up!\" They lunge at you and push you to the ground. They are surprisingly strong. As you start " +
                                    "to resist, they shush you. \"Don't worry.\", they whisper, \"I'll only hurt you if you want me to.\"\n" +
                                    " \n" +
                                    "After a pleasant dream, you wake up. Sweat runs down your neck and you feel a weird sense of pride. You move and notice that " +
                                    "something else was touching your neck. You find a breathtakingly gorgeous flower, of a kind you don't remember seeing before, " +
                                    "gently laid on your pillow. However, something feels familiar about it.\n" +
                                    "You gained (Strchnos' Flower)."
                                    );
                                currentPlayer.inventory.Add("strchnos' flower"); //The nymph's flower, named after extinct toxic flower
                                break;
                            //retreat
                            case 'b':
                                Anim.Say("\n" +
                                    "The nymph frowns at your cowardice. \"I had expected more from you. Well, never hurts to confirm prejudice.\"\n" +
                                    "With that she vanishes, as does the dream. You blink awake with a sense of defeat. After a moment, you shake your head, " +
                                    "lightly slap your cheeks to fully wake up and take a deep breath. Today can only become better now.\n"
                                    );
                                break;
                            //other
                            default: Anim.Say("You stand there, your mouth agape. The nymph's expression quickly changes to disappointment. They are in a foul mood and not keen to keep you around. Do you know what happens when you die in a dream? You \n"); GameOver(); break;
                        }
                        break;
                    //other
                    default:
                        Anim.Say("\n" +
                        "Unable to decide, you freeze in the wind that was so refreshing just a moment earlier. " +
                        "You start to hear laughter. First restrained, but quickly getting louder and nastier. \"They don't even have leaves!\" \"Like a slug!\" " +
                        "\"They look like they should be a politicizer!\" For dream reasons, these banal insults punch through to you. Their laughter now cackling " +
                        "and eerie, their bodies contorting and breaking with disgusting fleshy sounds. They morph into one form. A wall of viscera and a smell of " +
                        "seriously acidic apple wine flood over you. You shut your eyes and-\n"
                        );
                        GameOver();
                        break;
                }
            }
            
            void Outside()
            {
                //Console.Clear(); //clear console from previous text
                Anim.Say("\n" +
                    "As you leave, you feel the reassuring pressure of the ring on your finger.\n" +
                    "This is a (Ring of Weapons).\n" +
                    "The Ring of Weapons can shift into anything you want to use as a weapon. It can also absorb any future weapon you find, " +
                    "gaining the benefits of that weapon while still retaining the shape you've chosen.\n" +
                    "So, what will it be?\n"
                    );
                    currentPlayer.weaponName = Console.ReadLine(); //get form of weapon from player. Yes, this can result in stupid stuff. But let the player have fun.

                while (currentPlayer.weaponName == "")
                {
                    Anim.Say("Don't be afraid to choose.\n");
                    currentPlayer.weaponName = Console.ReadLine(); //get form of weapon from player. Yes, this can result in stupid stuff. But let the player have fun.
                }
                Anim.Say($"A small glyph depicting a stylized {currentPlayer.weaponName} appears on the ring, barely noticable. " +
                    $"You ready yourself for adventure.\n");
                Anim.Say(
                    "A fresh breeze blows as the town begins to bustle with life. You already hear the creaking merchant carts roll by, " +
                    "sellers calling out their wares and birds chirping friendly songs. At the corner, you see the three old Debating Men " +
                    "(as most people affectionatelly call them). Like always, they are already deep in a discussion, though the subject is hard " +
                    "to make out at this distance. In the other direction, you see a child struggling to lift a bucket out of the town well.\n" +
                    "What do you do?\n" +
                    "[a] go to the market - [b] listen in on the debate - [c] see if the kid needs help\n"
                    );
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case 'a': //go to market
                        Anim.Say("MARKET STUFF");
                        break;
                    case 'b': //listen to debate
                        Anim.Say(
                            "\"... and thus be a man naught but a two-legged creature without feathers!\" Imanele the Elder finished his " +
                            "argument. No sooner had he stopped talking that the other two fell into tones of ridicule. \"A featherless " +
                            "biped, a man?!\" Echallon Of Iron scoffed. Singraek Bynthe picked up from that with a gravelly voice. \"That " +
                            "would make any child of mine not be like me for years! You tell me mine daughter was but a creature, even though " +
                            "she ate from our tablecloth and wore fabric made by her father?\" \"Another point as well, Ima,\" Echallon interjected. " +
                            "\"In you entire tale have you not once mentioned what man be to you. Be it humans like you or their loins? As " +
                            "a Lizardfolk of which you haven't seen under the fabric, would you not call me a man were I to don a feathered hat?\" " +
                            "Imanele tried to cut in, but Singraek waved him off, genuine anger about the very idea seeping through. \"Of course! " +
                            "Our bond of dozens of years portends you shall find an exclusion for both of our complaints! Ponder what these tells " +
                            "of your argument, friend.\" \"Ah yes, what friends you be! Not providing me a moment of response!\" the Elder " +
                            "interjected quickly. \"Of course 'man' shall guide to the common understanding of our combined idea of beings such " +
                            "as we see us, as- DON'T YOU THINK TO INTERRUPT ME!\" \"Then speak he swift!\" \"I shall, after fitting you to a sum of " +
                            "shoes, Reptile- Be that as it may, I do no contain in this a definition of privates. These shallth be musings on " +
                            "what was called Civilized Beings in our spring years, as us all three rightfully fought counter those labels. " +
                            "The sense I tried to impart -you boney rags- be the sense of kinship we feel shall be the norm. By being thus, " +
                            "the mass of focus be on viewing as many such like us, not a boundary derived to exclude or shun!\"\n" +
                            "A moments pause. Each of them looking to the other two, as they stew in the rhetoric. Simulatneously grasping " +
                            "and formulating a counter to the point just made. Gazes given to each other, like knives and embraces at the " +
                            "same time." //continue? What can be player choices here?
                            );
                        break;
                    case 'c': //see if kid needs help
                        Anim.Say("\n" +
                            "You mosey over to the well. The child is grunting and cursing, as she contineously tries to lift the " +
                            "heavy bucket and fails. \"Bwooming gwove! Why ahh you so heaby?\" she cusses as you arrive.\n" +
                            "[a] ask if she needs help - [b] grab the bucket - [c] look for her parents\n"
                            );
                        choice = Console.ReadKey().KeyChar;
                        Anim.Say(""); //spacer
                        switch (choice)
                        {
                            case 'a': //help
                                Anim.Say("\n" +
                                    "\"Do you need help, young lady?\". She tries again and fails again before answering. \"Yea. " +
                                    "But I wanna do it myself!, I need to be stwong!\" She hasn't looked up, her eyes fixed on the " +
                                    "bucket she clutches with two tiny hands.\n" +
                                    "[a] \"Strong? What for?\" - [b] carry the bucket yourself - [c]\"Then you have to do it.\"\n"
                                    );
                                choice = Console.ReadKey().KeyChar;
                                switch (choice)
                                {
                                    case 'a': //help
                                        Anim.Say("\n" +
                                            "As you ask that, she grabs the bucket tighter. \"Mama said that. She is in bed. She is " +
                                            "in bed a lot.\" Finally, she looks up with determination in her eyes. \"So I said I will" +
                                            "be stwongah dan eben de Backsmif!\"\n" +
                                            "[a] help her with the bucket - [b] - [c] leave her to it \n"
                                            );
                                        choice = Console.ReadKey().KeyChar;
                                        switch (choice)
                                        {
                                            case 'a':
                                                Anim.Say("" +
                                                    "");
                                                break;
                                            case 'b':
                                                Anim.Say("" +
                                                    "");
                                                break;
                                            case 'c':
                                                goto LEAVE_GIRL;
                                        }
                                        break;
                                    case 'b': //grab the bucket (forcefully)
                                        Anim.Say("");
                                        goto GRAB_BUCKET;
                                    case 'c': //leave
LEAVE_GIRL:
                                        Anim.Say("\n" +
                                            "You shrug. \"You will probably manage.\" You turn, stepping away as you hear her struggle. " +
                                            "After a few paces, you hear something clattering behind you. You don't bother checking what " +
                                            "that was. There are always tons of noises around, even this early. "
                                            );
                                        break;
                                    default: Anim.Say("You watch her struggle on for a while, zoned out. You better go and see to other things"); break;
                                        //^check for an end to (or looping back of) this defaulting
                                }
                                break;
                            case 'b': //grab bucket
GRAB_BUCKET:
                                Anim.Say(
                                    "You grab the bucket off her hands. Her big eyes look up. \"Bu-\" before she can protest, you ask " +
                                    "her \"Where do you live again?\" A moment of shock passes over her, then she calls out \"Meanie!!! " +
                                    "Mama said I need to bwing her watah!\"" +
                                    "[a] try to calm her - [b] leave her to it then"
                                    );
                                choice = Console.ReadKey().KeyChar;
                                switch (choice)
                                {
                                    case 'a':
                                        Anim.Say(
                                            "You give her a soft smile. \"I'm sure your Mama is thristy" +
                                            "and would like to drink right now. Better to get this to her quickly. You can bring the next bucket\"" //CONTINUE WRITING
                                            );
                                        break;
                                    case 'b': //leave girl. Have to repeat the content from LEAVE_GIRL label, for some reason goto doesn't work here?
                                        Anim.Say(
                                            "You shrug. \"You will probably manage.\" You turn, stepping away as you hear her struggle. " +
                                            "After a few paces, you hear something clattering behind you. You don't bother checking what " +
                                            "that was. There are always tons of noises around, even this early. "
                                            );
                                        break;
                                }
                                break;
                            case 'c': //look for parents
                                Anim.Say(
                                    "You gaze around, keeping part of your attention on the small child so you can intervene if " +
                                    "she hurts herself. There are a smattering of people around, a few of them even peaking in " +
                                    "your direction, but none with an air of duty. The only thing you find in their eyes is " +
                                    "curiosity. \"Do you know where your parents are?\" you ask tentatively. The girl has put " +
                                    "down the bucket for the moment. Her hands are still on it, but she rests with long breaths. " +
                                    "\"Yea. Mama is at home. She needs dat watah.\" You let a moment pass to give her the opportunity " +
                                    "to continue, but she does not.\n" +
                                    "[a] ask more about her guardians - [b] ask if you can help - [c] leave"
                                    );
                                choice = Console.ReadKey().KeyChar;
                                switch (choice)
                                {
                                    case 'a':
                                        Anim.Say(
                                            "\"Only your Mama or is there someone else? An uncle or an aunt maybe?\" you ask. " +
                                            "She just quietly shakes her head. \"But now I can do stuff! I'm alweady big!\" \"I'm " +
                                            "sure you are.\"\n" +
                                            "[a] \"...but it's never bad to accept help.\" - [b] \"You'll manage.\""
                                            );
                                        choice = Console.ReadKey().KeyChar;
                                        switch (choice)
                                        {
                                            case 'a':
                                                Anim.Say("");
                                                break;
                                            case 'b':
                                                goto LEAVE_GIRL2; //Copy of LEAVE_GIRL above
                                        }
                                        break;
                                    case 'b':
                                        Anim.Say("");
                                        break;
                                    case 'c':
LEAVE_GIRL2: //Copy of LEAVE_GIRL above
                                        Anim.Say("\n" +
                                            "You shrug. \"You will probably manage.\" You turn, stepping away as you hear her struggle. " +
                                            "After a few paces, you hear something clattering behind you. You don't bother checking what " +
                                            "that was. There are always tons of noises around, even this early. "
                                            );
                                        break;
                                    default: Anim.Say(""); break;
                                }
                                break;
                            default: Anim.Say(""); GameOver(); break;
                        }
                        break;
                    default: Anim.Say(""); GameOver(); break;
                }
            }


            void GameOver()
            {
                Anim.Say("GAME OVER\n");
            }
        }
    }
}

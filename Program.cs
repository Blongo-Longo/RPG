namespace RPG
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
        }


        /*TODO: - After shop is created, adjust Noble and Rogue money benefit (career starting cash / extra money after battle)
         */

        static void Start()
        {
            //variables
            bool ancestChoice = false;
            bool careerChoice = false;
            char choice;
            char subchoice;
            char dreamChoice;
            //Preamble
            //Console.ReadKey(); //delete this - for showing people and the screen share isn't quick enough
            Anim.Say(
                "The Shopkeeper\n" +
                "A medival fantasy shop-em-up by <Some Cunt>\n" +
                "\n" +
                "First, Adventurer, tell me about yourself. What is your name?"
                );
            currentPlayer.playerName = Console.ReadLine();
            if (currentPlayer.playerName == "")
            {
                currentPlayer.playerName = "Dumpy";
                Anim.Say("Ah. A secret, is it? Well, in that case you will be called \"Dumpy\"");
            }
            Anim.Say(
                $"{currentPlayer.playerName}, tell me, which skin do you call yours?\n" +
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
                        Anim.Say("You'll have to choose one by writing it out");
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
                        Anim.Say("A ferocious foe.");
                        currentPlayer.playerPow += 1;
                        break;
                    case "commoner": //no bonus
                        Anim.Say("Greatness comes from humble beginnings.");
                        break;
                    //Add Duelist, Counter +1
                    case "guard": //starts with armour
                        Anim.Say("A shield incarnate.");
                        currentPlayer.playerArmour = 1;
                        break;
                    case "noble": //munneh
                        Anim.Say("Feeling responsibilities, are we?");
                        currentPlayer.playerMoney += 50; //contextless value. Adjust when shops are implemented
                        break;
                    case "rogue": //Adds fixed amount to money after battle. CHANGE TO %?
                        Anim.Say("Make them pay.");
                        currentPlayer.playerMoneyIncrease += 5; //contextless value. Adjust when shops are implemented
                        break;
                    case "swindler":
                        Anim.Say("A disarming smile can be a weapon in itself.");
                        currentPlayer.playerCharm += 1;
                        break;
                }
            }

            Anim.Say(
                "You wake up in your room. It's a shabby, simple bedroom. The light plays through the cracked window " +
                "upon a miriade of slow dancing dust particles. On your left, your sword leans against the night stand " +
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
                    goto LEAVE_ROOM;
                //take moment
                case 'b':
                    Anim.Say("\n" +
                    "Slowly letting the sleep drift from you, you get another cozy moment under the blankets. As the light filters " +
                    "through your window and brings you into reality, you remember the payment for your last adventure. The small " +
                    "pouch with coins sits atop the nightstand. With soft, gentle movements, you get ready. As you collect your things " +
                    "and leave the room, a stiff, cold breeze brushes along your neck. Today may be a bit of a fresh spring morning. " +
                    "Hopefully it clears up over the next few hours.\n"
                    );
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
                    goto DREAM;
                //other
                default: Anim.Say("You just lay there, unable to choose. Existance can be scary.\n"); goto GAME_OVER;
            }

LEAVE_ROOM:
            //choice point: leave room
            Anim.Say("[t]ake a look around - [l]eave\n");
            subchoice = Console.ReadKey().KeyChar;
            switch (subchoice)
            {
                //look around
                case 't':
                    Anim.Say("\n" +
                    "As you give the room another look, you remember your coin purse and your sword! You take both and step out.\n"
                    );
                    currentPlayer.playerMoney = 100;
                    Anim.Say($"You have {currentPlayer.playerMoney} coins and your trusty sword in your inventory.\n");
                    break;
                //leave
                case 'l':
                    Anim.Say("\n" +
                        "No time to dwell, you get your coat and leave your small abode.\n"
                        );
                    goto OUTSIDE;
                //other
                default:
                    Anim.Say("\n" +
                        "You just... stand there. A while later, you blink, shake your head and wonder how long you've been zoned out as you leave\n"
                        );
                    break;
                }
DREAM:
            Anim.Say("[p]resent yourself confidently - [h]ide yourself as best you can - [d]emand to know what they're doing, ogling you like this\n");
            dreamChoice = Console.ReadKey().KeyChar;
            switch (dreamChoice)
            {
                //present confidently
                case 'p':
                    Anim.Say("\n");
                    break;
                //hide
                case 'h':
                    Anim.Say("\n" +
                    "Thinking quickly, you dart to a close bush. It's a bit scratchy, but you feel safe now. As you look up, most of the nymphs have either " +
                    "left or just vanished (as dreams tend to do), but one remains. They have buried their face in their hands. As the wind gently roams " +
                    "around them, you can't help to feel drawn to them. Their fuller form, cracked bark-skin and beautifully autumnal leaves just speak to you " +
                    "You notice that you are now the one ogling and quickly look down to the grass. Just as you feel the confidence to talk to them, they raise " +
                    "their head from their hands. You see a beautiful face, eyes shyly darting to your direction.\n They smile, open their mouth and greet " +
                    "you with a soft\n" +
                    "\"PIG GUTS! FRESH AND LOVELY PIG GUTS!\"\n" +
                    "You jerk awake, damning the butcher next door for waking you so rudely. You are about to throw the blanket to the side and really tell " +
                    "him your opinion, but before you can something faintly touches the back of your hand.\n" +
                    "It is a single leaf that must've been blown in through your window. It has the most beautiful sunset-red colouration you have ever seen. " +
                    "\'How odd.\' you think, \'Isn't it Spring?\'\n" +
                    "Whatever the case may be, you decide to take it with you. It's really beautiful.\n"
                    );
                    //ADD: Soph-miro's Leaf to inventory (The nymph's leaf, named after extinct Sophora Toromiro Tree)
                    break;
                //demand answers
                case 'd':
                    Anim.Say("\n" +
                    "\"What are you gawking at, huh?\" your voice rings out over the long grass, starling the woodland creatures. \"At least " +
                    "say something nice!\" Surprised that a mortal would talk to them this way, most of them seem to vanish into the canopy. One stays. " +
                    "Their body is covered with brilliant flowers of all shapes and colours. They give you a daring smirk, tilt their head and call out: " +
                    "\"Oh, there is nice to be said about me, but you? How could a mere human like you even know the word beautiful before meeting me? " +
                    "Much less think they should be compared such?\"\n" +
                    "What do you answer?\n" +
                    "\"[I] said something nice, not beautiful. However did you come to that conclusion?\" (daring the nymph)\n\"[U]h, please don't mind me!\" (retreating)\n"
                    );
                        subchoice = Console.ReadKey().KeyChar;
                        switch (subchoice)
                        {
                            //dare the nymph
                            case 'i':
                                Anim.Say("\n" +
                                    "The nymph's smile grows. There is a fire in their eyes. \"I suppose\", she responds, \"you are not horribly different from us.\" " +
                                    "Their gaze wanders over you. \"But arrogance is cheap, young person. There is but one thing I am interested in. It's just a " +
                                    "matter of whether you can keep up!\" They lunge at you and push you to the ground. They are surprisingly strong. As you start " +
                                    "to resist, they shush you. \"Don't worry.\", they whisper, \"I'll only hurt you if you want me to.\"\n" +
                                    " \n" +
                                    "After a pleasant dream, you wake up. Sweat runs down your neck and you feel a weird sense of pride. You move and notice that " +
                                    "something else was touching your neck. You find a breathtakingly gorgeous flower, of a kind you don't remember seeing before, " +
                                    "gently laid on your pillow. However, something feels familiar about it.\n"
                                    );
                                //ADD: Strchnos' Flower to inventory (The nymph's flower, named after extinct toxic flower)
                                break;
                            //retreat
                            case 'u':
                                Anim.Say("\n" +
                                    "The nymph frowns at your cowardice. \"I had expected more from you. Well, never hurts to confirm prejudice.\"\n" +
                                    "With that she vanishes, as does the dream. You blink awake with a sense of defeat. After a moment, you shake your head, " +
                                    "lightly slap your cheeks to fully wake up and take a deep breath. Today can only become better now.\n"
                                    );
                                break;
                            //other
                            default: Anim.Say("You stand there, your mouth agape. The nymph's expression quickly changes to disappointment. They are in a foul mood and not keen to keep you around. Do you know what happens when you die in a dream? You \n"); goto GAME_OVER;
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
                            goto GAME_OVER;
                    }
OUTSIDE:
            Anim.Say("This is where more content goes :3\n");

GAME_OVER:
            Anim.Say("GAME OVER\n");
        }
    }
}

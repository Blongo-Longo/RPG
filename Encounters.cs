using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Encounters
    {
        static Random rand = new Random();
        //Encounters
        public static void FirstEncounter()
        {
            Anim.Say(
                ""
                );
            Console.ReadKey();
            GeneralEncounter(false, true, false, "Human Rogue", "", 5, 4, 4, 3, 1, 2);
        }
        /*TODO: - FINISH TUTORIAL
         *      - SEE HOW TO ADD INVENTORY
         *      - IMPLEMENT NEGOTIATION SYSTEM*/
     


        //Encounter Tools
        public static void GeneralEncounter(
            bool hostile, bool enemyMoney, bool enemyItem, //enemyMoney -> does this entity have cash? | enemyItem -> does this enemy have something worth looting?
            string enemyName, string lootableItem, int lootableMoneyMax, //lootableItem -> the drops you can get | lootableMoneyMax -> maximum possible payout if the enemy has cash
            int enemyMaxHP, int enemyCurHP,  int enemyAtk, //combat stats - Atk needs to be 3 at minimum, otherwise defenses mean auto-counters on everything depending on ancestry/career
            int interest, int patience //negotiation stats
            ) //^Doesn't need defences. They could cause the player to deal 0 damage. Just up HP instead.
        {                                   

            //variables
            int playerDMG = Program.currentPlayer.playerPow + Program.currentPlayer.playerWeapon; //Player Damage when base attack and weapon are combined. Ceiling for random attacks later, can be maxed out automatically for potential stealth kills?
            int playerDEF = Program.currentPlayer.playerFort + Program.currentPlayer.playerArmour; //Player Defences when natural fortification and armour are combined
            char playerAction; //user input
            int playerAttack; //store player damage value for output
            int enemyDMG; //damage the enemy deals to the player (also store for output)
            int enemyLootCoin = 0; //Loot (Money)
            string enemyLootItem = ""; //Loot (Item) [REQUIRES INVENTORY SYSTEM]
            string reward = ""; //Full end-of-battle reward

            while (enemyCurHP > 0 || patience > 0) //while the enemy is of interest...
            {
                //enemy stat block
                Anim.Say(
                    $"\n{enemyName}\n" +
                    $"HP: {enemyCurHP} / {enemyMaxHP}\n"); //HP display
                Anim.Negotiation("Interest: ", "█", "x", interest); //test. Should return 1
                Anim.Negotiation("Patience: ", "█", "x", patience); //test. Should return 2
                //    $"Interest: {interest} / 5\n" + //interest (negotiation)
                //    $"Patience: {patience} / 5\n"); //patience (negotiation)
                if (hostile == false) { Anim.Say("open-minded\n"); } 
                else { Anim.Say("hostile\n"); }
                //^mood | v player actions
                Anim.Say(
                    "====================\n" +
                    "| [T]alk  [A]ttack |\n" +
                    "| [I]tem  [L]eave  |\n" + //change item
                    "====================\n" +
                    $"Your HP: {Program.currentPlayer.playerCurHP} / {Program.currentPlayer.playerMaxHP}\n", 5
                    );
                
                //Space for inventory or stuff

                playerAction = Console.ReadKey().KeyChar;

                switch (playerAction)
                {
                    //talk
                    case 't':
                        if (hostile == false) //if enemy isn't hostile...
                        {
                            //normal conversation NEEDS NEGOTIATION SYSTEM!!!
                            Anim.Say("\n" +
                            "Message?\n"
                            );
                        }
                        else Anim.Say($"\nYour attempt to talk to the {enemyName} gets cut short as they rush at you! There is no use in talking sense anymore!\n");
                        break;
                    //attack
                    case 'a':
                        //player turn
                        if (hostile == false) //only show first aggression code when enemy is open-minded on attack
                        {
                            Anim.Say($"\nYou lunge forward! {enemyName} turns aggressive!");
                            hostile = true; //turn enemy hostile
                            interest = 0;
                            patience = 0;
                        }

                        
                        playerAttack = rand.Next(1, playerDMG+1) + rand.Next(1, playerDMG+1); //deal damage to enemy. Has to add one on max range to get a maximum of playerDMG as a result. Two random rolls instead of *2 for a better distribution
                        if (playerAttack == playerDMG * 2 && playerAttack > 2) //if player deals max damage... (doesn't count if you could only deal two damage max, since that would then always trigger)
                        {
                            Anim.Say($"\nA critical hit! You deal {playerAttack} damage!\n"); //Crit ideas: gives extra damage? (maybe through one extra rand roll) - guarantees an item? - heals?
                        }
                        else
                        {
                            Anim.Say($"\nYou dealt {playerAttack} damage!\n");
                        }
                        enemyCurHP -= playerAttack;
                        //enemy turn
                        enemyDMG = rand.Next(1,enemyAtk+1) - playerDEF; //subtract player defenses from enemy attack
                        if (enemyDMG <= 0) //if enemy wouldn't deal any damage...
                        {
                            //COUNTER!
                            Anim.Say($"The {enemyName} tries to strike you, but you excellently parry the attack, getting a quick stab in as retaliation!\n");
                            enemyCurHP -= Program.currentPlayer.playerCounter; //Deal counter damage to enemy
                            Anim.Say($"The {enemyName} suffers an additional {Program.currentPlayer.playerCounter} damage!\n");
                        }
                        else //enemy deals some damage...
                        {
                            Anim.Say($"The {enemyName} wounds you for {enemyDMG}!\n");
                            Program.currentPlayer.playerCurHP -= enemyDMG; //deal damage to player
                        }
                        break;
                    // item
                    case 'i':
                        Console.WriteLine("\n" +
                            "INVENTORY MESSAGE"
                            );
                        //inventory system?
                        break;
                    //leave
                    case 'l':
                        Anim.Say("\n" +
                            "You attempt to leave\n"
                            );

                        break;
                    //other
                    default: Anim.Say("\nYou stand there, unable to decide on something\n"); break;
                }
            }
            //end of battle
            Anim.Say($"You killed the {enemyName}!");

            //check if enemy has any loot. If so, add it to the reward:
            if (enemyMoney == true)
            { 
                //enemy money plus potential extra from career
                enemyLootCoin = rand.Next(2, lootableMoneyMax+1) + Program.currentPlayer.playerMoneyIncrease; 
                reward += $"\n* {enemyLootCoin} gold coins";
            }
            if (enemyItem == true) { reward += $"\n* {lootableItem}"; } 
            if (reward != "") //if there is a reward...
            {
                Anim.Say($" While rifling through their possessions, you find: {reward}"); //no \n at the end, because the rewards already have a line break in them. Space at front because else it would graft wrong onto the killed message
                Program.currentPlayer.playerMoney += enemyLootCoin; //
                //TODO: Add inventory system so I can add items to player inventory
            }
            Console.WriteLine(""); //Line break for following text
        }
    }
}

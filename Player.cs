﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Player
    {
        public string playerName; //name
        public string currentAncestry; //species
        public string currentCareer; //class/job
        public int playerMaxHP = 10; //max health
        public int playerCurHP = 10; //current health
        public int playerMoney = 0; //coin
        public int playerMoneyIncrease = 0; //x modifier for money after battle
        public int playerPow = 1; //player power, i.e. natural damage (not modified by weapon yet)
        public int playerWeapon = 0; //weapon damage
        public string weaponName = ""; //player-decided weapon name
        public int playerCounter = 1; //damage on counter
        public int playerFort = 0; //player fortification, i.e. natural defences (not modified by armour yet)
        public int playerArmour = 0; //armour defence
        public int playerCharm = 0; //negotiation mod

        //super primitive INVENTORY (possible items below just to keep them in mind)
        public List<string> inventory = new List<string>();
        //from DREAM:
        //soph-miro's leaf -> gift from the shy Nymph
        //strchnos' flower -> gift from the arrogant/kinky Nymph


        //These Career/Ancestry enums are NOT actually giving any benefit. Benefit is in a switch statement on choice
        //If the choices actually give a bigger effect like custom abilities, maybe change those into extra classes
        public string[] pAncestry = {
            "Avian", //Bird-creatures. playerMoneyIncrease +1 because they find shinies
            "Chelonian", //Turtle-creatures. playerFort +1
            "Dwarf", //more HP
            "Elf", //Default. Gets NOTHING. fuck elves
            "Human", //Charm +1
            "Goblin" //Counter +1
            };
        public string[] pCareer = {
            "Berserker", //playerPow +1
            "Commoner", //Default. Gets NOTHING
            //Druid (healing?)
            "Duelist", //+1 Counter
            "Guard", //playerArmour +1 OR starts with armour. Depends on Inventory system
            "Noble", //starts with Money +x. Depends on shop
            "Rogue", //gains more Gold after fights (Dieb Focus)
            "Swindler" //Charm +1
        };
    }
}

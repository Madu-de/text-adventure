using System;
using System.Collections.Generic;
using System.Text;
using UserClass;
using Monsters;
using learnCsharp;
using ItemClass;

namespace GameClass
{
    internal class Game
    {
        public static int rounds = 1;
        public static void play()
        {
            while (User.Health >= 0)
            {
                Random random = new Random();
                int rand = random.Next(2);
                switch (rand)
                {
                    case 1:
                        foundAMonster();
                        break;
                    default:
                        foundAnItem();
                        break;
                }
                rounds++;
            }
        }
        private static void foundAMonster()
        {
            string input = "";
            Monster monster = Monster.GetRandomMonster();

            while (true)
            {
                Program.WriteLine("Du hast ein Monster entdeckt!");
                Console.WriteLine("Es heißt " + monster.Name + ", hat " + monster.HP + " Leben und macht " + monster.Damage + " Schaden.");
                Console.WriteLine("Möchtest du es bekämpfen (fight) oder gehen (go)?");
                input = Console.ReadLine();
                if(input == "fight" || input == "go")
                {
                    break;
                }
            }
            if(input == "fight")
            {
                while (input == "fight" && monster.HP > 0 && User.Health > 0)
                {
                    monster.HP -= User.Damage;
                    if (monster.HP <= 0)
                    {
                        Program.WriteLine("Herzlichen Glückwunsch! Du hast das Moster bekämpfen können!");
                        Console.WriteLine("Klicke auf eine Taste um weiter zu spielen!");
                        Console.ReadKey();
                        return;
                    }
                    User.Health -= monster.Damage;
                    if(User.Health <= 0)
                    {
                        Game.tod();
                        return;
                    }
                    Program.WriteLine("Du hast dem Monster " + User.Damage + " Leben schaden gemacht!");
                    Console.WriteLine("Es hat nurnoch " + monster.HP + " Leben.");
                    Console.WriteLine("Das Monster hat dir  " + monster.Damage + " Leben schaden gemacht!");
                    Console.WriteLine("Du hast nurnoch " + User.Health + " Leben.");
                    Console.WriteLine("Möchtest du weiter kämpfen (fight) oder doch lieber gehen (go)?");
                    input = Console.ReadLine();
                }
                
            }
                
        }
        private static void foundAnItem()
        {
            string input = "";
            Item item = Item.GetRandomItem();
            while(true)
            {
                Program.WriteLine("Du hast ein Item entdeckt!");
                Console.WriteLine("Möchtest du es trinken (y) oder nicht (n)?");
                input = Console.ReadLine();
                if(input == "y" || input == "n")
                {
                    break;
                }
            }
            if(input == "y")
            {
                User.Health += item.Health;
                User.Health -= item.Damage;
                Program.WriteLine("Du hast das Item zu dir genommen!");
                Console.WriteLine("Das Item hat dir " + item.Health + " Leben erbracht und " + item.Damage + " Leben genommen.");
                Console.WriteLine("Du hast insgesammt " + (item.Health - item.Damage) + " Leben erhalten!");
                Console.WriteLine("Klicke auf eine Taste um weiter zu spielen!");
                Console.ReadKey();

            }
        }
        public static void tod()
        {
            Program.WriteLine("Du bist Tod!");
        }
    }
}

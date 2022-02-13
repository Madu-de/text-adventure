using System;
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
            while (User.Health > 0)
            {
                Random random = new Random();
                int rand = random.Next(3);
                switch (rand)
                {
                    case 1:
                        foundAMonster();
                        break;
                    case 2:
                        foundAItem();
                        break;
                    default:
                        foundAnBottle();
                        break;
                }
                rounds++;
            }
            Game.tod();
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
                if (User.invSlot1 != null)
                {
                    Console.WriteLine("1 um Item 1 zu benutzen");
                }
                if (User.invSlot2 != null)
                {
                    Console.WriteLine("2 um Item 2 zu benutzen");
                }
                if (User.invSlot3 != null)
                {
                    Console.WriteLine("3 um Item 3 zu benutzen");
                }
                input = Console.ReadLine();
                if(input == "fight" || input == "go" || input == "1" || input == "2" || input == "3")
                {
                    break;
                }
            }
            if(input == "fight" || input == "1" || input == "2" || input == "3")
            {
                while (input == "fight" || input == "1" || input == "2" || input == "3" && monster.HP > 0 && User.Health > 0)
                {
                    if(input == "1")
                    {
                        monster.HP -= User.invSlot1.Damage;
                        Program.WriteLine("Du hast dem Monster " + User.invSlot1.Damage + " Leben schaden gemacht!");
                        User.invSlot1 = null;
                    } else if(input == "2")
                    {
                        monster.HP -= User.invSlot2.Damage;
                        Program.WriteLine("Du hast dem Monster " + User.invSlot2.Damage + " Leben schaden gemacht!");
                        User.invSlot2 = null;
                    } else if(input == "3")
                    {
                        monster.HP -= User.invSlot3.Damage;
                        Program.WriteLine("Du hast dem Monster " + User.invSlot3.Damage + " Leben schaden gemacht!");
                        User.invSlot3 = null;
                    } else
                    {
                        monster.HP -= User.Damage;
                        Program.WriteLine("Du hast dem Monster " + User.Damage + " Leben schaden gemacht!");
                    }
                    if (monster.HP <= 0)
                    {
                        User.addXp(20 * User.LvL);
                        Program.WriteLine("Herzlichen Glückwunsch! Du hast das Monster bekämpfen können!");
                        Program.spieleWeiter();
                        return;
                    }
                    User.Health -= monster.Damage;
                    if(User.Health <= 0)
                    {
                        Game.tod();
                        return;
                    }
                    Console.WriteLine("Es hat nurnoch " + monster.HP + " Leben.");
                    Console.WriteLine("Das Monster hat dir  " + monster.Damage + " Leben schaden gemacht!");
                    Console.WriteLine("Du hast nurnoch " + User.Health + " Leben.");
                    Console.WriteLine("Möchtest du weiter kämpfen (fight) oder doch lieber gehen (go)?");
                    if (User.invSlot1 != null)
                    {
                        Console.WriteLine("1 um Item 1 zu benutzen");
                    }
                    if (User.invSlot2 != null)
                    {
                        Console.WriteLine("2 um Item 2 zu benutzen");
                    }
                    if (User.invSlot3 != null)
                    {
                        Console.WriteLine("3 um Item 3 zu benutzen");
                    }
                    input = Console.ReadLine();
                }
                
            }
            if (input == "go")
            {
                Random random = new Random();
                int rnd = random.Next(10); // Wahrscheinlichkeit 10%
                if (rnd == 3)
                {
                    User.Health -= monster.Damage;
                    Program.WriteLine(monster.Name + " hat dich wärend des Weglaufens gesehen und angegriffen!");
                    Console.WriteLine("Du hast " + monster.Damage + " Leben weniger!");
                    Program.spieleWeiter();
                }
            }
                
        }
        private static void foundAnBottle()
        {
            string input = "";
            Bottle item = Bottle.GetRandomBottle();
            while(true)
            {
                Program.WriteLine("Du hast eine Flasche entdeckt!");
                Console.WriteLine("Möchtest du sie trinken (y) oder nicht (n)?");
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
                if(User.Health <= 0)
                {
                    Game.tod();
                } else
                {
                    Program.WriteLine("Du hast die Flasche zu dir genommen!");
                    Console.WriteLine("Sie hat dir " + item.Health + " Leben erbracht und " + item.Damage + " Leben genommen.");
                    Console.WriteLine("Du hast insgesammt " + (item.Health - item.Damage) + " Leben erhalten!");
                    Program.spieleWeiter();
                }
            }
        }
        public static void foundAItem()
        {
            string input = "";
            Item item = Item.getRandomItem();
            while (true)
            {
                Program.WriteLine("Du hast ein Item entdeckt!");
                Console.WriteLine("Es ist ein(e) " + item.Name);
                Console.WriteLine("Möchtest du sie aufsammeln (y) oder nicht (n)?");
                input = Console.ReadLine();
                if (input == "y" || input == "n")
                {
                    break;
                }
            }
            if(input == "y")
            {
                if(User.invSlot1 == null)
                {
                    User.invSlot1 = item;
                } else if(User.invSlot2 == null)
                {
                    User.invSlot2 = item;
                } else if(User.invSlot3 == null)
                {
                    User.invSlot3 = item;
                } else
                {
                    Program.WriteLine("Dein Inventar ist voll!");
                    Program.spieleWeiter();
                    return;
                }
                Program.WriteLine("Das Item wurde hinzugefügt.");
                Program.spieleWeiter();
            }
        }
        public static void tod()
        {
            Program.WriteLine("Du bist Tod!");
        }
    }
}

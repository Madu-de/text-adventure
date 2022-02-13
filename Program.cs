using System;
using UserClass;
using GameClass;

namespace learnCsharp
{
    class Program
    {
        static void Main()
        {
            User.load();
            if(User.Alter >= 10)
            {
                Game.play();
                Console.ReadKey();
            } else
            {
                Program.WriteLine("Du bist zu jung für das Spiel!");
            }
        }
        public static void WriteLine(string input)
        {
            Console.Clear();
            if(User.Health > 0)
            {
                Console.WriteLine(User.Name + " hat " + User.Health + " Leben und macht " 
                                  + User.Damage + " Leben Schaden. Du bist in Runde " + Game.rounds);
                Console.WriteLine("Level: " + User.LvL + " Xp: " + User.Xp);
                if(User.invSlot1 != null)
                {
                    Console.WriteLine("Inv1: " + User.invSlot1.Name);
                }
                if(User.invSlot2 != null)
                {
                    Console.WriteLine("Inv2: " + User.invSlot2.Name);
                }
                if(User.invSlot3 != null)
                {
                    Console.WriteLine("Inv3: " + User.invSlot3.Name);
                }
            }
            else
            {
                Console.WriteLine("Willkommen im Monsterspiel! (inspiriert von Asston)");
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine(input);
        }
        public static void spieleWeiter()
        {
            Console.WriteLine("Klicke auf eine Taste um weiter zu spielen!");
            Console.ReadKey();
        }
    }
}
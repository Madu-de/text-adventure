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
                Console.WriteLine(User.Name + " hat " + User.Health + " Leben und machst " + User.Damage + " Leben Schaden. Du bist in Runde " + Game.rounds);
            } else
            {
                Console.WriteLine("Willkommen im Monsterspiel! (inspiriert von Asston)");
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine(input);
        }
    }
}
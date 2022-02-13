using System;
using ItemClass;
using learnCsharp;

namespace UserClass
{
    internal class User
    {
        public static string Name { get; set; }
        public static int Alter { get; set; }
        public static int Health { get; set; }
        public static int Damage { get; set; }
        public static int LvL { get; set; }
        public static float Xp { get; set; }

        // Inventory
        public static Item invSlot1 { get; set; }
        public static Item invSlot2 { get; set; }
        public static Item invSlot3 { get; set; }


        public static void load()
        {
            User.Name = getName();
            User.Alter = getAlter();
            User.Health = 20;
            User.Damage = 5;
            User.LvL = 1;
        }
        static string getName()
        {
            Program.WriteLine("Wie soll dein Charakter heißen?");
            string name = Console.ReadLine();
            Console.Clear();
            return name;
        }
        static int getAlter()
        {
            Program.WriteLine("Wie alt bist du?");
            int alter = int.Parse(Console.ReadLine());
            Console.Clear();
            return alter;
        }
        public static void addXp(int value)
        {
            User.Xp += value;
            while(User.Xp >= 100)
            {
                addLvL(1);
                User.Xp -= 100;
            }
        }
        private static void addLvL(int value)
        {
            User.LvL++;
            User.Health += 2 * User.LvL;
            User.Damage += 2 * User.LvL;
        }
    }
}

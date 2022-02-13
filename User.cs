using System;
using System.Collections.Generic;
using System.Text;
using ItemClass;
using learnCsharp;

namespace UserClass
{
    internal class User
    {
        public static string  Name { get; set; }
        public static int Alter { get; set; }
        public static int Health { get; set; }
        public static int Damage { get; set; }
        public static float LvL { get; set; } 


        public static void load()
        {
            User.Name = getName();
            User.Alter = getAlter();
            User.Health = 20;
            User.Damage = 5;
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
    }
}

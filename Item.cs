using System;

namespace ItemClass
{
    internal class Bottle
    {
        public int Damage { get; set; }
        public int Health { get; set; }

        public Bottle(int _damage, int _health)
        {
            Damage = _damage;
            Health = _health;
        }
        public static Bottle GetRandomBottle()
        {
            Random random = new Random();
            return new Bottle(random.Next(10), random.Next(10));
        }
    }
    internal class Item
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Item(string _name, int _damage)
        {
            Name = _name;
            Damage = _damage;
        }

        public static Item getRandomItem()
        {
            Random random = new Random();
            string name = "";
            int damage = 0;
            switch(random.Next(5))
            {
                case 1:
                    name = "Holzschwert";
                    damage = 10;
                    break;
                case 2:
                    name = "Eisenschwert";
                    damage = 20;
                    break;
                case 3:
                    name = "Schleuder";
                    damage = 5;
                    break;
                case 4:
                    name = "Diamantaxt";
                    damage = 50;
                    break;
                default:
                    name = "Stein";
                    damage = 1;
                    break;
            }
            Item item = new Item(name, damage);
            return item;
        }
    }
}

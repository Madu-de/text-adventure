using System;
using System.Collections.Generic;
using System.Text;

namespace ItemClass
{
    internal class Item
    {
        public int Damage { get; set; }
        public int Health { get; set; }

        public Item(int _damage, int _health)
        {
            Damage = _damage;
            Health = _health;
        }
        public static Item GetRandomItem()
        {
            Random random = new Random();
            return new Item(random.Next(10), random.Next(10));
        }
    }
}

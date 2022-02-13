using System;
using System.Collections.Generic;
using System.Text;

namespace Monsters
{
    class Monster
    {
        // Eigenschaften
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }

        // Constructor
        public Monster(string _name, int _hp, int _damage)
        {
            Name = _name;
            HP = _hp;
            Damage = _damage;
        }

        public static Monster GetRandomMonster()
        {
            Random random = new Random();
            int spawnDragonProbability = random.Next(999999999);
            if(spawnDragonProbability == 2)
            {
                return new Monster("Drache des Schreckens!", 100, 100);
            } else
            {
                return new Monster(GetRandomName(), random.Next(50), random.Next(50));
            }
        }
        public static string GetRandomName()
        {
            Random random = new Random();
            int rnd = random.Next(20);
            string name = "";

            switch (rnd)
            {
                case 1:
                    name = "Hans";
                    break;
                case 2:
                    name = "Ahmed";
                    break;
                case 3:
                    name = "Lisa";
                    break;
                case 4:
                    name = "Balian";
                    break;
                case 5:
                    name = "Felipe";
                    break;
                case 6:
                    name = "Gerian";
                    break;
                case 7:
                    name = "Momme";
                    break;
                case 8:
                    name = "Batu";
                    break;
                case 9:
                    name = "Joris";
                    break;
                case 10:
                    name = "Erik";
                    break;
                case 11:
                    name = "Liam";
                    break;
                case 12:
                    name = "Igor";
                    break;
                case 13:
                    name = "Thies";
                    break;
                case 14:
                    name = "Leif";
                    break;
                case 15:
                    name = "Henrik";
                    break;
                case 16:
                    name = "Rasmus";
                    break;
                case 17:
                    name = "Frau Pikay";
                    break;
                case 18:
                    name = "Eva";
                    break;
                case 19:
                    name = "Lilli";
                    break;
                case 20:
                    name = "Jacob";
                    break;
                default:
                    name = "Lina";
                    break;

            }

            return name;
        }
    }

}

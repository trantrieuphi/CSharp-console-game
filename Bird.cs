using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstProject
{
    class Bird: Animal
    {
        private const int MAX_LEVEL = 10;
        private const int MAX_POWER = 50;
        private const int MAX_HP = 500;
        private const int MAX_MP = 100;
        private const int MP_Ultimate = 20;
        private string name = "Bird";
        public Bird() : base()
        {
            Species = SpeciesType.Monter;
            Random random = new Random();
            Level = random.Next(1, MAX_LEVEL);
            Power = random.Next(1, MAX_POWER);
            Hp = random.Next(1, MAX_HP);
            Mp = random.Next(1, MAX_MP);
        }

        public override void information()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Species: " + Species);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Power: " + Power);
            Console.WriteLine("Hp: " + Hp);
            Console.WriteLine("Mp: " + Mp);
        }

        public override int attack(Skill skill)
        {
            switch (skill)
            {
                case Skill.Normal:
                    return Power;
                case Skill.Ultimate:{
                    if(Mp < MP_Ultimate){
                        Console.WriteLine("Not enough MP, use normal attack");
                        return Power;
                    } else {
                        Mp -= MP_Ultimate;
                        return Power * 2;
                    }
                }
                default:
                    return 0;
            }
        }

        public override void takeDamage(int damage)
        {
            Hp -= damage;
        }

        public override void doneTurn()
        {
            Mp += 10 + Level;
            if(Mp > MAX_MP){
                Mp = MAX_MP;
            }
        }

    }
}
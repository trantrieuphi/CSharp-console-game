
using System;
using System.Diagnostics;

namespace firstProject
{
    class Program
    {   
        public void Fight(Human human, Animal monter)
        {
            Random random = new Random();
            int firstHit = random.Next(0, 2);
            // 0 is human first hit
            // 1 is monter first hit
            while (human.Hp > 0 && monter.Hp > 0)
            {
                if (firstHit == 0)
                {
                    Console.WriteLine("Human attack:");
                    int choice;
                    Console.WriteLine("1. Normal attack");
                    Console.WriteLine("2. Ultimate attack");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        int damage = human.attack(Skill.Normal);
                        Console.WriteLine("Normal attack");
                        Console.Write("=>");
                        Console.WriteLine("Your damage: " + damage);
                        monter.takeDamage(damage);
                    }
                    else if (choice == 2)
                    {
                        int damage = human.attack(Skill.Ultimate);
                        Console.WriteLine("Ultimate attack");
                        Console.Write("=>");
                        Console.WriteLine("Your damage: " + damage);
                        monter.takeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice, use normal attack");
                        int damage = human.attack(Skill.Normal);
                        Console.Write("=>");
                        Console.WriteLine("Damage: " + damage);
                        monter.takeDamage(damage);
                    }
                    Console.WriteLine("Monter Hp: " + monter.Hp);
                    human.doneTurn();
                    firstHit = 1;
                }
                else
                {
                    Console.WriteLine("Monter attack");
                    Random random1 = new Random();
                    int choice1 = random1.Next(0, 2);
                    if (choice1 == 0)
                    {
                        int damage = monter.attack(Skill.Normal);
                        Console.WriteLine("Normal attack");
                        Console.Write("=>");
                        Console.WriteLine("Monter damage: " + damage);
                        human.takeDamage(damage);
                    }
                    else
                    {
                        int damage = monter.attack(Skill.Ultimate);
                        Console.WriteLine("Ultimate attack");
                        Console.Write("=>");
                        Console.WriteLine("Monter damage: " + damage);
                        human.takeDamage(damage);
                    }
                    Console.WriteLine("Human Hp: " + human.Hp);
                    monter.doneTurn();
                    firstHit = 0;
                }
                Console.WriteLine("====================================");
                human.information();
                Console.WriteLine("====================================");
                monter.information();
                Console.WriteLine("====================================");
                Console.WriteLine("====================================");
            }
        }
        static void Main()
        {
            Console.WriteLine("Hello, welcome to the game");
            Animal monter;
            Human human = new Human();
            Console.WriteLine("Enter your name: ");
            human.Name = Console.ReadLine();
            Random random = new Random();
            MonterType monterType = (MonterType)random.Next(0, 2);
            switch (monterType)
            {
                case MonterType.Pig:
                    monter = new Pig();
                    break;
                case MonterType.Bird:
                    monter = new Bird();
                    break;
                default:
                    monter = new Pig();
                    break;
            }
            Console.WriteLine("====================================");
            Console.WriteLine("Your information");
            human.information();
            Console.WriteLine("====================================");
            Console.WriteLine("Monter information");
            monter.information();
            Console.WriteLine("====================================");
            Console.WriteLine("Start fight");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");
            Program program = new Program();
            program.Fight(human, monter);
            if (human.Hp > 0)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You lose");
            }

        }

        
    }

}
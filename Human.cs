namespace firstProject
{
    class Human : Animal
    {
        private const int MAX_LEVEL = 10;
        private const int MAX_POWER = 100;
        private const int MAX_HP = 100;
        private const int MAX_MP = 100;
        private const int MP_Ultimate = 20;
        private string name;
        private string job;

        public Human() : base()
        {
            Random random = new Random();
            Level = random.Next(1, MAX_LEVEL);
            Power = random.Next(1, MAX_POWER);
            Hp = random.Next(1, MAX_HP);
            Mp = random.Next(1, MAX_MP);
            name = "No name";
            Species = SpeciesType.Human;
            job = "No name";
        }

        public string Name
        {  
            get {return name;}
            set {name = value;}
        }

        public string Job
        {
            get {return job;}
            set {job = value;}
        }

        public override void information()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Job: " + job);
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
                    return this.Power;
                case Skill.Ultimate:{
                    if(Mp < MP_Ultimate){
                        Console.WriteLine("Not enough MP, use normal attack");
                        return this.Power;
                    } else {
                        Mp -= MP_Ultimate;
                        return this.Power * 2;
                    }
                }
                default:
                    return 0;
            }
        }

        public override void takeDamage(int damage)
        {
            this.Hp -= damage;
        }

        public override void doneTurn()
        {
            this.Mp += 10 + Level;
            if(this.Mp > MAX_MP){
                this.Mp = MAX_MP;
            }
        }
    }
}
namespace firstProject
{
    abstract class Animal
    {
        private int level;
        private int power;
        private int hp;
        private int mp;
        private SpeciesType species;

        public Animal()
        {
            level = 0;
            power = 0;
            hp = 0;
            mp = 0;
            species = SpeciesType.Unknown;
        }

        public Animal(SpeciesType species, int level, int power, int hp, int mp)
        {
            this.level = level;
            this.power = power;
            this.hp = hp;
            this.mp = mp;
            this.species = species;
        }

        public int Level
        {
            get {return level;}
            set {level = value;}
        }

        public int Power
        {
            get {return power;}
            set {power = value;}
        }

        public int Hp
        {
            get {return hp;}
            set {hp = value;}
        }

        public int Mp
        {
            get {return mp;}
            set {mp = value;}
        }

        public SpeciesType Species
        {
            get {return species;}
            set {species = value;}
        }

        public abstract void information();

        public abstract int attack(Skill skill);

        public abstract void takeDamage(int damage);

        public abstract void doneTurn();

    }
}
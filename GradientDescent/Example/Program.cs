namespace Example
{

    public abstract class Animal
    {
        public string Name;
        public int Weight;

        public Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public Animal(int weight)
            : this("Unammed", weight) { }

        public virtual void Print()
        {
            Console.WriteLine($"{Name}, that weighs {Weight}");
        }
    }

    public enum ShellTypes
    {
        Broken,
        Swirly,
        Missing
    }

    public class Snail : Animal
    {
        public int ShellDiameter;
        public ShellTypes ShellType;
        public Snail(string name, int weight, ShellTypes shellType)
            : base(name, weight)
        {
            ShellType = shellType;
        }

        public Snail(string name, int weight, int diameter)
            :this (name, weight, diameter < 1 ? ShellTypes.Broken : ShellTypes.Swirly)
        {
            this.ShellDiameter = diameter;
        }

        public Snail(string name, int weight)
            :this(name, weight, ShellTypes.Missing) {}

    }

    public class Cheetah : Animal
    {
        public int MaxSpeed;

        public Cheetah(string name, int weight, int maxSpeed)
            :base (weight)
        {
            MaxSpeed = maxSpeed;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
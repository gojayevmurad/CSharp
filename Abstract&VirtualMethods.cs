namespace AbstractVIrtualMethods
{

    public abstract class Vehicle
    {
        public string? Model { get; set; }
        public string? Vendor { get; set; }
        public int Capacity { get; set; }

        public abstract void Print();
        public abstract void Move();
    }

    class Airplane : Vehicle
    {
        public string? PilotName { get; set; }

        public override void Move()
        {
            Console.WriteLine("I am flying by air");
        }

        public override void Print()
        {
            Console.WriteLine($"Airplane: {Model} {Vendor} {Capacity}");
            Console.WriteLine($"Pilot : {PilotName}");
        }
    }

    class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("I am moving like car :-)");
        }

        public override void Print()
        {
            Console.WriteLine($"Car: {Model} {Vendor} {Capacity}");
        }
    }

    class Boeng : Airplane
    {
        public override void Move()
        {
            Console.WriteLine("BOEING TURBO 747");
        }
    }

    abstract class Unit
    {
        public string? Name { get; set; }
        public int Defence { get; set; }
        public int Attack { get; set; }

        public Unit()
        {
            
        }

        protected Unit(string name, int defence, int attack)
        {
            Name = name;
            Defence = defence;
            Attack = attack;
        }

        public virtual void LetsAttack()
        {
            Console.WriteLine("Attack");
        }

        public virtual void LetsDefence()
        {
            Console.WriteLine("Defence");
        }

    }

    class Warrior : Unit
    {
        public int Level { get; set; }

        public Warrior(string name, int defence , int attack , int level)
            :base(name,defence,attack)
        {
            Level = level;
        }

        public override void LetsAttack()
        {
            Console.WriteLine($"I attack as warrior with my level {Level}");
        }

    }

    class Commander : Warrior
    {
        public Commander(string name, int defence, int attack, int level) : base(name, defence, attack, level)
        {

        }
    }

    class Archer : Unit
    {

    }

    public static class NetworkResponse
    {
        public static readonly string BadRequest = "BadRequest";
        public static readonly string NotFound = "NotFound";
    }

    public static class NetworkProtocols
    {
        public static readonly string TCP = "Tcp";
        public static readonly string UDP = "Udp"; 
    }

    class MyArray
    {
        public int[] arr { get; set; }

    }

    public class Program
    {

        static void Practice1()
        {
            Vehicle[] vehicles = {
                new Airplane{
                    Vendor = "Boeng",
                    Model = "M-747",
                    Capacity = 180,
                    PilotName = "John Johnlu"
                },
                new Boeng{
                    Vendor = "Boeng S",
                    Model = "M-747",
                    Capacity = 180,
                    PilotName = "Leyla Mammadova"
                },
                new Car
                {
                    Capacity = 5,
                    Model = "K5",
                    Vendor = "KIA"
                }
            };


            foreach (var vehicle in vehicles)
            {
                vehicle.Print();
                vehicle.Move();
                Console.WriteLine();
            }
        }

        static void Practice2()
        {
            Unit warriow = new Warrior("Barbar", 100, 90, 4);
            warriow.LetsDefence();
            warriow.LetsAttack();

            string error = "Not Found";

            if (error == NetworkResponse.BadRequest)
            {

            }
            else if (error == NetworkResponse.NotFound)
            {

            }


            string pr = Console.ReadLine();

            if (pr == NetworkProtocols.UDP)
            {

            }
            else if (pr == NetworkProtocols.TCP)
            {

            }
        }

        static void Main(string[] args)
        {


        }
    }
}
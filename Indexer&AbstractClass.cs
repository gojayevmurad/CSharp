using System.ComponentModel;
using System.Reflection.Emit;

namespace Indexer
{
    class Age
    {
        //const int yead; // error
        const int year = 100;
        //readonly int year2 = 100; // ok
        readonly int year2;

        public Age(int year)
        {
            //year = 200;// error
            //year2 = 222; // ok ==>constructor
            //year2 = year; // ok
        }

        public void SetData()
        {
            //year = 200; // error
            //year2 = 222; // error
        }
    }

    class Car
    {
        public Guid Id { get; set; }
        public string? Model { get; set; }
        public string? Vendor { get; set; }
        public string? Engine { get; set; }

        public Car()
        {
            Id = Guid.NewGuid();
        }

        public Car(string? model, string? vendor, string? engine)
            : this()
        {
            Model = model;
            Vendor = vendor;
            Engine = engine;
        }

        public override string ToString()
        {
            return $@"
            ID : {Id}
            Model : {Model}
            Vendor : {Vendor}
            Engine : {Engine}
            ";
        }
    }

    class CarGallery
    {
        public Car[] Cars { get; set; }

        public CarGallery(int size)
        {
            Cars = new Car[size];
        }

        public Car this[int index]
        {
            get => Cars[index];
            set => Cars[index] = value;
        }

        public void Show()
        {
            foreach (var car in Cars)
            {
                Console.WriteLine(car);
            }
        }

    }

    public abstract class Human
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }

        public Human()
        {

        }

        protected Human(string name, string surname)
        {
            Surname = surname;
            Name = name;
        }

        protected Human(string? name, string? surname, DateTime? birthday)
            : this(name, surname)
        {
            Birthday = birthday;
        }

        public void Show()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
        }
    }

    public class Student : Human
    {
        public double Average { get; set; }

        public Student(string name, string surname, double average)
            :base(name, surname)
        {
            Average = average;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Average : {Average}");
        }

    }

    public abstract class Employee : Human
    {
        public double Salary { get; set; }

        protected Employee(string name, string surname, double salary)
            : base(name, surname)
        {
            Salary = salary;
        }
        
        protected Employee(string name, string surname, DateTime birthday, double salary)
            : base(name, surname, birthday)
        {
            Salary = salary;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Salary : {Salary}");
        }
    }

    class Manager : Employee
    {
        public Manager(string name, string surname, double salary, string team) 
            : base(name, surname, salary)
        {
            Team = team;
        }

        public string? Team { get; set; }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Team : {Team}");
        }
    }

    class Programmer : Employee
    {
        public Programmer(string name, string surname, double salary, string lang)
            : base(name, surname, salary)
        {
            Language = lang;
        }

        public string? Language { get; set; }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Language : {Language}");
        }
    }

    public class Program
    {
        static void Practice1()
        {
            Car car1 = new Car
            {
                Model = "K5",
                Vendor = "KIA",
                Engine = "2.0"
            };

            Car car2 = new Car
            {
                Model = "Sonata",
                Vendor = "Hyundai",
                Engine = "2.0"
            };

            CarGallery gallery = new CarGallery(10);
            gallery[0] = car1;
            gallery[1] = car2;
            gallery.Show();

        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Guid.NewGuid());

            //Student student = new Student("Anvar", "Mammadov", 12);
            //student.Show();

            Manager m1 = new Manager("Mike", "Mammadov", 1230, "PANDA");
            Manager m2 = new Manager("Aysel", "Mammadova", 1230, "PANDA");

            Programmer p1 = new Programmer("John", "Hasanov", 2800, "Python");
            Programmer p2 = new Programmer("Jack", "Hasanli", 2801, "Javascript");

            Employee[] employees = { m1, m2, p1, p2 };

            foreach (var item in employees){

                if(item is Manager m) m.Show();
                else if(item is Programmer p) p.Show();
                else item.Show();

                Console.WriteLine();
            }

        }
    }
    
}
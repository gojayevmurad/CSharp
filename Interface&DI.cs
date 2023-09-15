using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Interface
{
    #region Custom Exception

    class PaymentException: ApplicationException
    {

        public decimal Money { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public PaymentException(decimal money, string? errorMessage, DateTime paymentDate)
        {
            Money = money;
            ErrorMessage = errorMessage;
            PaymentDate = paymentDate;

        }

        public override string Message => $@"
            Money : {Money}
            PaymentDate : {PaymentDate}
            Error : {ErrorMessage}
        ";
    }

    #endregion

    #region Simple Interfaces ex1
    class Car { }

    class Mercedess : Car { }
    class SportMercedess : Mercedess, ISport
    {
        public void Turbo()
        {
            throw new NotImplementedException();
        }

        public void TurboPlus()
        {
            throw new NotImplementedException();
        }
    }

    class BMW : Car { }
    class SportBMW : BMW, ISport
    {

        public void Turbo()
        {
            throw new NotImplementedException();
        }

        public void TurboPlus()
        {
            throw new NotImplementedException();
        }
    }

    interface ISport
    {
        void Turbo();
        void TurboPlus();
    }

    #endregion

    #region Simple Interfaces ex2
    abstract class Human
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirtDate { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {BirtDate.ToLongDateString()}";
        }

    }

    abstract class Employee : Human
    {
        public string? Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Position : {Position} Salary : {Salary}";
        }
    }

    interface IManager
    {
        void Organize();
        void Control();
        void MakeBudget();
    }

    interface IWorker
    {
        void Work();
        bool IsWorking();
    }

    class Director : Employee, IManager
    {
        public void Control()
        {
            Console.WriteLine("I am BOSS, i will control you");
        }

        public void MakeBudget()
        {
            Console.WriteLine("no money :=)");
        }

        public void Organize()
        {
            Console.WriteLine("i organize best for you");
        }
    }

    class Seller : Employee, IWorker
    {
        public bool IsWorking()
        {
            return true;
        }

        public void Work()
        {
            Console.WriteLine("2 in 1");
        }
    }

    class Cashier : Employee, IWorker
    {
        public bool IsWorking()
        {
            return true;
        }

        public void Work()
        {
            Console.WriteLine("empty cashier -_-");
        }
    }

    #endregion

    #region Dependecy Injection main

    interface IDatabse
    {
        public string? Name { get; set; }

        void Add();
        void Delete();
        void Update();
    }

    class SqlDatabase : IDatabse
    {
        public string? Name { get; set; }

        public void Add()
        {
            Console.WriteLine("I add data to Sql DB");
        }

        public void Delete()
        {
            Console.WriteLine("I delete data from Sql DB");
        }

        public void Update()
        {
            Console.WriteLine("I update data in Sql DB");
        }
    }

    class MongoDB : IDatabse
    {
        public string? Name { get; set; }

        public void Add()
        {
            Console.WriteLine("I add data to Mongo DB");
        }

        public void Delete()
        {
            Console.WriteLine("I delete data from Mongo DB");
        }

        public void Update()
        {
            Console.WriteLine("I update data in Mongo DB");
        }
    }

    class DataFactory
    {
        private readonly IDatabse _database;

        public DataFactory(IDatabse database)
        {
            _database = database;
        }

        public void Add()
        {
            _database.Add();
        }

        public void Delete()
        {
            _database.Delete();
        }

        public void Update()
        {
            _database.Update();
        }

    }

    #endregion

    #region Dependecy Injection 2

    interface ICalculate
    {
        void Calculate();

    }

    interface A:ICalculate
    {
        void Show();
        void Calculate();
    }

    interface B:ICalculate
    {
        void Add();
        void Calculate();
    }


    class Concrete : A, B
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Calculate()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Standart Interfaces

    class Student :IComparable<Student> 
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student? other)
        {
            if (this.Age > other?.Age) return 1;
            else if (this.Age < other?.Age) return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"Name : {Name} Age : {Age}";
        }

    }

    class Auditory:IEnumerable
    {
        public Student[]? Students { get; set; }

        public Auditory()
        {
            Students = new Student[]
            {
                new Student
                {
                    Name = "Leyla",
                    Age = 23
                },
                new Student
                {
                    Name = "Eli",
                    Age = 24
                },
                new Student
                {
                    Name ="Ruad",
                    Age = 15
                }
            };
        }

        public void Show()
        {
            foreach (var item in Students)
            {
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Age : {item.Age}");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Students.GetEnumerator();
        }
    }

    #endregion

    internal class Program
    {

        static void Pay(decimal money)
        {
            if(money < 0)
            {
                throw new PaymentException(money, $"Payment money was not enought, your balance {0}", DateTime.Now);
            }
        }

        static void PracticeException()
        {
            try
            {
                Pay(-12);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            };
        }

        static void PracticeInterfaces()
        {
            Director director = new Director
            {
                Name = "John",
                Surname = "Johnlu",
                BirtDate = DateTime.Now,
                Position = "CEO",
                Salary = 11000,
            };

            director.Control();
            director.MakeBudget();
            director.Organize();

            List<IWorker> workers = new List<IWorker>
            {
                new Seller()
                {
                    Name ="David",
                    Surname= "Mammadov"
                },
                new Cashier()
                {
                    Name = "Hikmet",
                    Surname= "Ramizli"
                },
            };

            foreach (var item in workers)
            {
                if (item is Employee s)
                {
                    Console.WriteLine(s.Name);
                    Console.WriteLine(s.Surname);
                }
                item.Work();
                Console.WriteLine();
            }

        }

        static void DependecyInjetionMain()
        {
            DataFactory dataFactory = new DataFactory(new MongoDB());
            dataFactory.Add();
            dataFactory.Delete();
            dataFactory.Update();
        }

        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            auditory.Show();
            Array.Sort(auditory.Students);
            //auditory.Show();

            foreach (var item in auditory){
                if(item is Student s)
                {
                    Console.WriteLine($"Name : {s.Name}");
                    Console.WriteLine($"Age : {s.Age}");
                }
            }

        }
    }
}
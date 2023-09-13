using System.Globalization;

namespace ClassesAndStruct
{

    //struct Point
    //{
    //    public int X;
    //    public int Y;
    //}


#if false
    class Point
    {
        public int X;
        public int Y;
    }

    class Student {

        private string? name;
        private string? surname;
        private int age;

        public Student(string? name, string? surname, int age){
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }
            
    }
#endif


    class Teacher
    {
        //public double Salary { get; set; } // auto property
        private double salary;

        public double Salary
        {
            get {
                return salary; 
            }

            set {
                if (value > 0){
                    salary = value;
                }
            }
        }


        public Teacher(double salary)
        {
            Salary = salary;
        }
    }

    class Student
    {
        public int Id { get; set; } = default; 
        public string? Name { get; set; } = String.Empty;
        public string? Surname { get; set; } = "No Surname";

        private int age;

        public Student()
        {
            
        }

        public Student(int id, string? name, string? surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }

        public int Age
        {
            get => age;
            set {
                if (value > 0)
                {
                    age = value; 
                }
            }
        }

        public void Show()
        {
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age : {Age}");
        }

        public int GetDoubleAge() => age * 2;

    }

    class CarProp
    {
        public int Id { get; set; }
        public string? Volume { get; set; }
        public string? Model { get; set; }
        public string? Vendor { get; set; }
        public DateTime ProduceDate { get; set; }

        public CarProp(string? volume, string? model, string? vendor, DateTime produceDate)
        {
            Volume = volume;
            Model = model;
            Vendor = vendor;
            ProduceDate = produceDate;
        }

        public void Show()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Volume : {Volume}");
            Console.WriteLine($"Model : {Model}");
            Console.WriteLine($"Vendor : {Vendor}");
            Console.WriteLine($"Vendor : {Vendor}");
            Console.WriteLine($"ProduceDate: {ProduceDate}");
        }

        public int GetCarAge() => DateTime.Now.Year - ProduceDate.Year;

    }

    class CarPropFul
    {
        private int id;
        private string volume;
        private string model;
        private string vendor;
        private DateTime produceDate;

        public CarPropFul(int id, string volume, string model, string vendor, DateTime produceDate)
        {
            Id = id;
            Volume = volume;
            Model = model;
            Vendor = vendor;
            ProduceDate = produceDate;
        }

        public DateTime ProduceDate
        {
            get { return produceDate; }
            set { produceDate = value; }
        }


        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public string Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public void Show()
        {
                Console.WriteLine($"Id : {Id}");
                Console.WriteLine($"Volume : {Volume}");
                Console.WriteLine($"Model : {Model}");
                Console.WriteLine($"Vendor : {Vendor}");
                Console.WriteLine($"Vendor : {Vendor}");
                Console.WriteLine($"ProduceDate: {ProduceDate}");
        }

        public int GetCarAge() => DateTime.Now.Year - ProduceDate.Year;

    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Show()
        {
            Console.WriteLine($"X : {X}");
            Console.WriteLine($"Y : {Y}");
        }

    }

    class Counter
    {
        private int min;
        private int max;
        private int currentData;

        public Counter(){
            Min = 0;
            Max = 100;
            currentData = min;
        }

        public Counter(int min, int max, int currentData)
        {
            Min = min;
            Max = max;
            this.currentData = currentData;
        }

        public int GetCurrentData() => currentData;


        public int Max{
            get { return max; }
            set { 
                if(value > Min) max = value;
            }
        }

        public int Min{
            get { return min; }
            set {
                min = value;
            }
        }

    }

    internal class Program
    {


        static void Change(in int[] arr)
        {
            arr[0] = 100;

            //arr = null;
        }

        static void CultureInfoClass()
        {
            double amount = 1234.95;
            var data = amount.ToString("C", CultureInfo.GetCultureInfo("en-US"));
            var data2 = amount.ToString("C", CultureInfo.GetCultureInfo("en-gb"));
            Console.WriteLine(data);
            Console.WriteLine(data2);
        }

        static void IntroducingClass()
        {
            Point[] points = new Point[10];

            for (int i = 0; i < 10; i++)
            {
                points[i] = new Point();
            }

            //.? null conditional operator
            Console.WriteLine(points[0]?.X);

            Point point = new Point();
            point.Y = 0;
            point.X = 0;
        }


        static void Main(string[] args){
            #region lesson
            //Student student = new Student("John", "Johnlu", 45);
            //Console.WriteLine(student.GetAge());

            //Teacher teacher = new Teacher(3400);
            //Console.WriteLine(teacher.Salary);

            //Student student = new Student(100, "Rafiq", "Mammadov", 33);
            //Console.WriteLine(student.GetDoubleAge());
            //student.Show();

            //Car => id , volume , model , vendor, produceDate
            //Show, GetCarAge()

            //CarProp car = new CarProp("Mercedess", "GL500", "3.4", new DateTime(2002,11,04));
            //car.Show();
            //Console.WriteLine(car.GetCarAge());

            #endregion

            #region practice
            Point point = new Point(12, 11);
            #endregion
        }
    }
}
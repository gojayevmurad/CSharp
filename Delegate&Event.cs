namespace Delegate
{


    // FindAll => Predicate
    // Select => Func
    // ForEach => Action

    #region Custom Delegate

    class CustomManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello Message");
        }

        public void ShowPresentation()
        {
            Console.WriteLine("Welcome to the presentation");
        }

        public void SendMessage2(string text)
        {
            Console.WriteLine($"Hello {text} Message");
        }

        public void ShowPresentation2(string text)
        {
            Console.WriteLine($"Welcome to the presentation {text}");
        }

    }




    class MyMath
    {
        public int Add(int num1, int num2)
        {
            Console.WriteLine("Add");
            return num1 + num2;
        }

        public int Mult(int num1, int num2)
        {
            Console.WriteLine("Mult");
            return num1 * num2;
        }

        public int Div(int num1, int num2)
        {
            Console.WriteLine("Div");
            return num1 / num2;
        }

    }
    #endregion

    public delegate void Notify();

    class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;
        public void StartProcess()
        {
            Console.WriteLine("Process started");
            Thread.Sleep(3000);
            OnProcessCompleted();
        }

        private void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }

    class Student
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname} {BirthDate.ToLongDateString()}";
        }

    }

    internal class Program
    {
        delegate void MyDelegate();
        delegate void MyDelegateParam(string text);
        delegate int MyMathDel(int num1, int num2);

        static void PrintText()
        {
            Console.WriteLine("Text printed by the help of Action del");
        }

        static void ShowInfo()
        {
            Console.WriteLine("You're .Net developer");
        }

        static void ShowData(string name, int age)
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Age : {age}");
        }

        static int Calculate(float n1, float n2)
        {
            return (int)(n1 + n2);
        }

        static double Calculate(double n1, double n2)
        {
            return n1 + n2;
        }

        static void Display(Student s)
        {
            Console.WriteLine(s);
        }

        static void ShowAge(Student s)
        {
            Console.WriteLine(DateTime.Now.Year - s.BirthDate.Year);
        }

        static string Fullname(Student s)
        {
            return $"{s.Name} {s.Surname}";
        }

        #region Simple Event



        #endregion

        static void Main(string[] args)
        {

            ProcessBusinessLogic businessLogic = new ProcessBusinessLogic();
            businessLogic.ProcessCompleted += BusinessLogic_ProcessCompleted;

            businessLogic.StartProcess();

        }

        private static void BusinessLogic_ProcessCompleted()
        {
            Console.Beep(900, 500);
            Console.Beep(400, 500);
            Console.WriteLine("Process completed");
        }

        private static void PredicatePractice()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name = "Vuqar",
                    Surname = "Aslanov",
                    BirthDate = new DateTime(1999,8,31)
                },
                new Student
                {
                    Name = "Turqay",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2003,3,24)
                },
                new Student
                {
                    Name = "Elnur",
                    Surname = "Ekberli",
                    BirthDate = new DateTime(2005,10,26)
                },
                new Student
                {
                    Name = "Revan",
                    Surname = "Hacizade",
                    BirthDate = new DateTime(2008,1,1)
                },
                new Student
                {
                    Name ="Ulvi",
                    Surname="Poladov",
                    BirthDate = new DateTime(2007, 7, 24)
                },
                new Student
                {
                    Name = "Nihat",
                    Surname = "Quliyev",
                    BirthDate = new DateTime(2006,7,16)
                },
                new Student
                {
                    Name = "Ilkin",
                    Surname = "Agazade",
                    BirthDate = new DateTime(2004, 8, 3)
                },
                new Student
                {
                    Name="Eli",
                    Surname = "Eliyev",
                    BirthDate = new DateTime(2000, 10, 21)
                },
                new Student
                {
                    Name = "Enver",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2001, 7, 19)
                },
                new Student
                {
                    Name = "Ruad",
                    Surname = "Dunyamaliyev",
                    BirthDate = new DateTime(2008, 5, 17)
                }
            };

            #region Predicate

            Predicate<Student> myPred = new Predicate<Student>(OnlyWinterStudents);


            var results = students.FindAll(myPred);

            results.ForEach(Display);

            //foreach (var item in students)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }

        private static bool OnlySpringStudents(Student obj)
        {
            return obj.BirthDate.Month == 3 || obj.BirthDate.Month == 4 || obj.BirthDate.Month == 5;
        }

        private static bool OnlyWinterStudents(Student obj)
        {
            return obj.BirthDate.Month == 1 || obj.BirthDate.Month == 2 || obj.BirthDate.Month == 12;
        }

        private static void FuncAndActionPractice()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name = "Vuqar",
                    Surname = "Aslanov",
                    BirthDate = new DateTime(1999,8,31)
                },
                new Student
                {
                    Name = "Turqay",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2003,3,24)
                },
                new Student
                {
                    Name = "Elnur",
                    Surname = "Ekberli",
                    BirthDate = new DateTime(2005,10,26)
                },
                new Student
                {
                    Name = "Revan",
                    Surname = "Hacizade",
                    BirthDate = new DateTime(2008,1,1)
                },
                new Student
                {
                    Name ="Ulvi",
                    Surname="Poladov",
                    BirthDate = new DateTime(2007, 7, 24)
                },
                new Student
                {
                    Name = "Nihat",
                    Surname = "Quliyev",
                    BirthDate = new DateTime(2006,7,16)
                },
                new Student
                {
                    Name = "Ilkin",
                    Surname = "Agazade",
                    BirthDate = new DateTime(2004, 8, 3)
                },
                new Student
                {
                    Name="Eli",
                    Surname = "Eliyev",
                    BirthDate = new DateTime(2000, 10, 21)
                },
                new Student
                {
                    Name = "Enver",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2001, 7, 19)
                },
                new Student
                {
                    Name = "Ruad",
                    Surname = "Dunyamaliyev",
                    BirthDate = new DateTime(2008, 5, 17)
                }
            };

            #region Action
            //Action<Student> action = new Action<Student>(Display);
            //action += ShowAge;

            //students.ForEach(action);
            #endregion

            #region Func

            Func<Student, string> myFunc = new Func<Student, string>(Fullname);

            //var result = students.Select(Fullname).ToList();
            var result = students.Select(myFunc).ToList();

            result.ForEach(s =>
            {
                Console.WriteLine(s);
            });


            #endregion

        }

        private static void FuncPractice()
        {
            //Func<float , float, int> func = new Func<float, float, int>(Calculate);
            //var result = func.Invoke(1.35f, 2.76f);
            //Console.WriteLine(result);

            Func<double, double, double> func = new Func<double, double, double>(Calculate);
            var result = func.Invoke(1.1, 2.2);
            Console.WriteLine(result);
        }

        private static void ActionPractice()
        {
            //Action action = new Action(PrintText);
            //action += ShowInfo;
            //action.Invoke();

            Action<string, int> action = new Action<string, int>(ShowData);
            action.Invoke("Tofiq", 42);
        }

        private static void Delegate3()
        {
            MyMath myMath = new MyMath();
            MyMathDel myMathDel = new MyMathDel(myMath.Add);
            myMathDel += myMath.Mult;
            myMathDel += myMath.Div;

            var result = myMathDel.Invoke(20, 10);
            Console.WriteLine(result);
        }

        private static void Delegate2(CustomManager manager)
        {
            MyDelegateParam myDel = manager.SendMessage2;
            myDel += manager.ShowPresentation2;

            myDel.Invoke("John");
        }

        private static void Delegate1()
        {

            CustomManager manager = new CustomManager();
            MyDelegate myDelegate = new MyDelegate(manager.SendMessage);

            myDelegate += manager.ShowPresentation;
            myDelegate.Invoke();
            myDelegate -= manager.SendMessage;
            myDelegate.Invoke();
        }
    }
}
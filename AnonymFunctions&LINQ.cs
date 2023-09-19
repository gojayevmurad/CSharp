using System.Runtime.InteropServices;

namespace AnonymMethods
{
    public delegate void MyDelegate();
    public delegate void MyDelegateParam(int i);
    public delegate double MyDelDouble(double n1, double n2);


    public class Student
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public double Score { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname} {BirthDate.ToLongDateString()}";
        }

    }

    internal class Program
    {
        public static void DoSomething()
        {
            Console.WriteLine("I did something . . .");
        }        
        public static void DoSomething2()
        {
            Console.WriteLine("I did something2 . . .");
            throw new Exception();
        }

        static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Foo()
        {
            Console.WriteLine("Foo method works");
        }


        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name = "Vuqar",
                    Surname = "Aslanov",
                    BirthDate = new DateTime(1999,8,31),
                    Score = 85
                },
                new Student
                {
                    Name = "Turqay",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2003,7,24),
                    Score = 88
                },
                new Student
                {
                    Name = "Elnur",
                    Surname = "Ekberli",
                    BirthDate = new DateTime(2005,10,26),
                    Score = 77
                },
                new Student
                {
                    Name = "Revan",
                    Surname = "Hacizade",
                    BirthDate = new DateTime(2008,1,1),
                    Score = 80
                },
                new Student
                {
                    Name ="Ulvi",
                    Surname="Poladov",
                    BirthDate = new DateTime(2007, 7, 24),
                    Score = 44
                },
                new Student
                {
                    Name = "Nihat",
                    Surname = "Quliyev",
                    BirthDate = new DateTime(2006,7,16),
                    Score = 33
                },
                new Student
                {
                    Name = "Ilkin",
                    Surname = "Agazade",
                    BirthDate = new DateTime(2004, 8, 3),
                    Score = 77
                },
                new Student
                {
                    Name="Eli",
                    Surname = "Eliyev",
                    BirthDate = new DateTime(2000, 10, 21),
                    Score  = 90
                },
                new Student
                {
                    Name = "Enver",
                    Surname = "Mammadov",
                    BirthDate = new DateTime(2001, 7, 19),
                    Score = 93
                },
                new Student
                {
                    Name = "Ruad",
                    Surname = "Dunyamaliyev",
                    BirthDate = new DateTime(2008, 5, 17),
                    Score = 88
                }
            };

            //var result = students.FindAll(delegate (Student s)
            //{
            //    return s.BirthDate.Month >= 3 && s.BirthDate.Month <= 5;
            //});

            //result.ForEach(delegate (Student s)
            //{
            //    Console.WriteLine(s);
            //});

            //var result = students.FindAll(s => s.BirthDate.Month >= 3 &&  s.BirthDate.Month <= 5);

            //result.ForEach(s => Console.WriteLine(s));

            // LINQ => Language Integrated Query

            // 1
            //var count = students.Count(s=> s.Name.ToLower().StartsWith('e'));
            //Console.WriteLine(count);

            // First , FirstOrDefault, Single, SingleOrDefault
            //Student item = students.First(s => s.Name == "Eli");
            //Console.WriteLine(item);


            //Student item = students.FirstOrDefault(s => s.Name == "Eli");

            //if(item == default)
            //{
            //    Console.WriteLine("not found");
            //}
            //else
            //{
            //    Console.WriteLine(item);
            //}

            //var item = students.Single(s => s.Surname == "Mammadov");
            //Console.WriteLine(item);


            //var item = students.SingleOrDefault(s => s.Surname == "Mammadov");
            //Console.WriteLine(item);

            //////////////////////////////////////////////

            //var totalScore = students.Sum(s => s.Score);
            //Console.WriteLine(totalScore);

            //var average = students.Average(s => s.Score);
            //Console.WriteLine(average);

            //var list = students.Skip(5).ToList();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //var list = students.SkipWhile(s => s.Score >= 75).ToList();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


            //var list = students.Take(3);

            //foreach ( var student in list)
            //{
            //    Console.WriteLine(student);
            //}

            //var list = students.TakeWhile(s => s.BirthDate.Month >= 3 && s.BirthDate.Month <= 5).ToList();
            //foreach ( var student in list)
            //{
            //    Console.WriteLine(student);
            //}

            //List<Student> bestStudents = students.Where(s => s.Score >= 80).ToList();

            //foreach (var student in bestStudents)
            //{
            //    Console.WriteLine(student);
            //}

            //var result = students
            //            .Where(s => s.BirthDate.Month > 6)
            //            .OrderBy(s => s.Score);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var index = students.FindLastIndex(s => s.Surname == "Mammadov");
            //Console.WriteLine(index);

        }

        #region Anonym Functions

        private static void MyDelegateDoublePractice()
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

            MyDelDouble myDelDouble = new MyDelDouble(delegate (double n1, double n2)
            {
                return n1 + n2;
            });

            myDelDouble += delegate (double n1, double n2)
            {
                return n1 * n2;
            };

            Console.WriteLine(myDelDouble.Invoke(10, 20));
        }

        private static void MyDelWithParamPractice()
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

            MyDelegateParam del = new MyDelegateParam(delegate (int i)
            {
                Console.WriteLine($"data is {i}");
            });

            del += delegate (int data)
            {
                for (int i = 0; i < data; i++)
                {
                    Console.WriteLine("Hello World");
                }
            };

            del.Invoke(5);
        }

        private static void MyDelegateWithParam()
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
            MyDelegate del = new MyDelegate(delegate
            {
                Console.WriteLine("Hello world");
            });

            del += delegate
            {
                Console.WriteLine("Something going");
                Console.WriteLine("Some code works");
            };

            //del -= delegate
            //{
            //    Console.WriteLine("Something going");
            //    Console.WriteLine("Some code works");
            //}; // nothing happend

            //del += Foo;// ok
            //del -= Foo; // ok

            del.Invoke();
        }

        private static void DelegateExceptionHandling()
        {
            //try
            //{
            //    DoSomething();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    DoSomething();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            HandleException(DoSomething);
            HandleException(DoSomething2);
        }
        #endregion

    }
}
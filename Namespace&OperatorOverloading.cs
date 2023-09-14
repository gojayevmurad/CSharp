
    namespace MyLibrary
    {
        public class Console
        {
            public static void WriteLine(object obj){
                System.Console.WriteLine(obj);
            }
        }
    }

    namespace Protocols 
    {
        namespace HTTP
        {
            namespace Client
            {
                class HttpClient
                {

                }
            }
        }
    }

namespace Namespaces_OperatorOverloading
{
    using PHC =  Protocols.HTTP.Client;


    class Student
    {
        public string? Name { get; set; }
        public string?  Surname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"${Name} - {Surname} - {Age}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Student s)
            {
                return this.Age == s.Age;
            }
            return false;
        }

        public static bool operator true(Student s)
        {
            return s.Age >= 18;
        }

        public static bool operator false(Student s)
        {
            return s.Age < 18;
        }

    }


    class Car
    {
        public string? Model { get; set; }
        public double Engine { get; set; }
        public int HorsePower { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Model} - {Engine} - {HorsePower} - {Year}";
        }

        public static bool operator true (Car s)
        {
            return (s.Engine >= 2  && s.HorsePower  >= 200 && s.Year >= 2012);
        }

        public static bool operator false(Car s)
        {
            return (s.Engine < 2 && s.HorsePower < 200 && s.Year < 2012);
        }

        public override bool Equals(object? obj)
        {
            if(obj is Car s)
            {
                return (this.Engine == s.Engine  && this.HorsePower == s.HorsePower);
            }

            return false;
        }

    }

    public class Helper
    {
        private static Random? MyRandom;

        public static int GetRandom()
        {
            MyRandom = new Random();
            return MyRandom.Next();
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"X : {X}  Y : {Y}";
        }

        public static Point operator ++ (Point p)
        {
            p.X++;
            p.Y++;

            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;

            return p;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point { X = p1.X - p2.X, Y = p1.Y - p2.Y };
        }

        public override bool Equals(object? obj)
        {
            if(obj is Point p)
            {
                return this.X == p.X && this.Y == p.Y;
            }

            return false;
        }

        public static bool operator == (Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

    }

    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        public override string ToString()
        {
            return $"X-{X} Y-{Y} Z-{Z}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Vector v)
            {
                return this.X == v.X && this.Y == v.Y && this.Z == v.Z;
            }
            return false;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        public static Vector operator ++ (Vector v)
        {
            v.X++; v.Y++; v.Z++;
            return v;
        }

        public static Vector operator --(Vector v)
        {
            v.X--; v.Y--; v.Z--;
            return v;
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            Vector newVector = new Vector
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y,
                Z = v1.Z + v2.Z
            };
            return newVector;
        }

        public static Vector operator - (Vector v1, Vector v2)
        {
            Vector newVector = new Vector
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y,
                Z = v1.Z - v2.Z
            };
            return newVector;
        }

        public static Vector operator * (Vector v1, Vector v2)
        {
            Vector newVector = new Vector
            {
                X = v1.X * v2.X,
                Y = v1.Y * v2.Y,
                Z = v1.Z * v2.Z
            };

            return newVector;
        }

        public static Vector operator / (Vector v1, Vector v2)
        {
            Vector newVector = new Vector
            {
                X = (v1.X / v2.X),
                Y = (v1.Y / v2.Y),
                Z = (v1.Z / v2.Z)
            };
            return newVector;
        }

        public static bool operator > (Vector v1, Vector v2)
        {
            if(v1.X > v2.X) return true;

            return false;
        }

        public static bool operator < (Vector v1, Vector v2)
        {
            if( v1.X < v2.X)return true;

            return false;
        }

        public static bool operator <= (Vector v1, Vector v2)
        {
            if (v1.X <= v2.X) return true;
            return false;
        }

        public static bool operator >= (Vector v1, Vector v2)
        {
            if (v1.X >= v2.X) return true;
            return false;
        }
        
    }

    class Program
    {
        static void Practice1()
        {
                MyLibrary.Console.WriteLine("Salam c#");
                Console.WriteLine("Hi");

                PHC.HttpClient httpClient = new PHC.HttpClient();

        }

        static void Practice2()
        {
            Student student = new Student
            {
                Age = 32,
                Name = "John",
                Surname = "Johnlu"
            };

            Student student1 = new Student
            {
                Age = 32,
                Name = "John",
                Surname = "Johnlu"
            };

            object obj = null;

            Console.WriteLine(student.Equals(student1));
            Console.WriteLine(student);
        }

        static void Practice3()
        {
            //Point point = new Point
            //{
            //    X = 55,
            //    Y = 62
            //};

            //Console.WriteLine(point.ToString());
            //Console.WriteLine(++point);
            //Console.WriteLine(point--);

            var p1 = new Point
            {
                Y = 30,
                X = 40,
            };

            var p2 = new Point
            {
                Y = 30,
                X = 40,
            };


            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1.Equals(p2));

            if (p1 == p2)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
        }

        static void Main(string[] args)
        {

            /*
             * Vector
             * x,y, z
             * ++ , -- **
             * + , * , - , / ** 
             *  > < >= <= **
             *  == != ** 
             *  ToString **
             *  Equals **
             */
            Vector v1 = new Vector { X = 1, Y = 1, Z = 1 };

            Vector v2 = new Vector { X = 2, Z = 2, Y = 2 };

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine(v1+=v2);
            Console.WriteLine(v1+=v2);
            Console.WriteLine(v1 + v2);
            Console.WriteLine(v1);

        }

    }

}
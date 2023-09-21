using System.Collections;

namespace ExtensionMethod
{

    class Student
    {
        public int Score { get; set; }
    }

    static class Extention
    {
        public static int CountOfWords(this string input)
        {
            return input.Split(' ').Length;
        }

        public static int CountOfVovels (this List<char> input)
        {
            var vowels = "aeuio";
            return input.Count(l=> vowels.Contains(char.ToLower(l)));
        }
        public static int CountOfLetters (this List<char> input, List<char> letters)
        {
            return input.Count(l=> letters.Contains(char.ToLower(l)));
        }
    }


    class User
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {Age}";
        }

        public override int GetHashCode()
        {
            return $"{Name} {Surname} + {Age}".GetHashCode();
        }

    }

    interface IReader
    {

    }

    //empty -> // all types
    //where T : class // reference type
    //where T : struct // value type
    class Point<T> where T : class, IReader, new() 
    {
        public T? Data1 { get; set; }
        public T? Data2 { get; set; }
    }

    class Book : IReader
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Point<string> point = new Point<string>
            //{
            //    Data1 = "Apple",
            //    Data2 = "Samsung"
            //};

            Point<Book> point = new Point<Book>();

        }

        private static void GenNonGenPractice()
        {
            Stack stack = new Stack();

            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);

            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}


            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Queue<int> ints = new Queue<int>();

            Hashtable ht = new Hashtable();
            ht.Add("apple", 1.80);
            ht.Add("Pear", 4.50);
            ht.Add("Redbull", 0);

            foreach (var item in ht.Keys)
            {
                Console.WriteLine($"{item} - {ht[item]}");
            }

            Dictionary<string, string> ypx = new Dictionary<string, string>();
            ypx["10-KY-248"] = "Chevrolet Cruze";
            ypx["10-LL-010"] = "Mercedes Mayback";
            ypx["77-ZZ-777"] = "Nissan Patrol";

            Console.WriteLine(ypx["10-KY-248"]);

            foreach (var item in ypx)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            Console.WriteLine("-----------------------");

            Dictionary<User, string> pairs = new Dictionary<User, string>();
            pairs[new User { Name = "Elvin", Surname = "Camalzade", Age = 10 }] = "Elvin";
            pairs[new User { Name = "Vuqar", Surname = "Aslanov", Age = 24 }] = "Vuqar";


            var u1 = new User { Name = "Elvin", Surname = "Camalzade", Age = 10 };
            var u2 = new User { Name = "Elvin", Surname = "Camalzade", Age = 10 };

            pairs[u1] = "Ekber";
            pairs[u2] = "Elvin";

            Console.WriteLine(pairs[u1]);


            foreach (var item in pairs)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
        }

        private static void NonGeneric()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(10);
            arrayList.Add(20);
            arrayList.Add(20);
            arrayList.Add("Hello");
            arrayList.Add(10.2);

            
            arrayList.TrimToSize();
            Console.WriteLine(arrayList.Capacity);
            arrayList.TrimToSize();
            Console.WriteLine(arrayList.Capacity);
            Console.WriteLine(arrayList.Count);

            //arrayList.AddRange(arrayList);

            arrayList.Remove(20);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }


            //string text = "Hello";
            //object obj = text; // normal

            //int age = 100;
            //// boxing => value type to reference
            //object obj = age;
            //// uboxing
            //int result = (int)obj;


            //List<int> ints = new List<int>();
            //ints.Add(1);
            //ints.Add(2);
            //ints.Add(3);
        }

        private static void ExtentionPractice()
        {
            //var letters = "Hello how are you ".ToCharArray().ToList();

            //Console.WriteLine(letters.CountOfVovels());
            //Console.WriteLine(letters.CountOfLetters(new List<char> { 'e' }));



            //List<Student> list = new List<Student>();

            ////  Scoru umimu telebelerin ortalama scorundan boyuk olan telebeleri
            ////  gosterin

            //var result = list
            //    .Where(s => s.Score > list.Average(s => s.Score));

            //foreach (var student in result)
            //{
            //    Console.WriteLine(student.Score);
            //}



            string text = "Hello world and programmers";
            Console.WriteLine(text.CountOfWords());
        }
    }
}
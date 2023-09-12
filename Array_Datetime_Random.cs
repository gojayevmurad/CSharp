using System.Net.Security;

namespace Arrays
{
    internal class Program
    {

        static void CheckedUnchecked()
        {
            //unchecked is default
            checked
            {
                int value = int.Parse(Console.ReadLine());
                int data = int.MaxValue + value;
                Console.WriteLine(data);
            }
        }

        static void SafeUnsafe(){
            int data = 100;
            unsafe{
                int* ptr = &data;
            }
        }

        static void ArrayClone()
        {
#if false
            string[] students = { "Rocky", "Leyla", "Tofiq" };
            string[]? students2 = students.Clone() as string[];

            students2[0] = "Arif";

            foreach (var item in students){
                Console.WriteLine($"{item}");
            }

#endif

#if false
            string[] students = { "Rocky", "Leyla", "Tofiq" };
            var copyResult = students.Clone();


            if(copyResult is string[] students2){
                students2[0] = "Arif";

                foreach (var item in students)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("can not convert");
            }

#endif

            string[] fruits = { "Apple", "PineApple", "Mango", "Pumela" };
            string[] copy_fruits = new string[fruits.Length];

            Array.Copy(fruits, 0, copy_fruits, 0, fruits.Length);

            foreach (var item in copy_fruits){
                Console.WriteLine(item);
            }


        }

        static void CreateAndReadArr(){

            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers[0]);

            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += 10;
                Console.WriteLine(numbers[i]);
            }


            string[] students = { "Rocky", "Leyla", "Tofiq" };
            string[] students2 = students;

            Console.WriteLine(students.Length);

            students2[0] = "Arif";

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
            }
        }

        static void AddArray(){

            string[]? fruits = { "Apple", "PineApple", "Mango", "Pumela" };

            Array.Resize(ref fruits, fruits.Length+1);
            fruits[fruits.Length - 1] = "New Fruit";

            foreach (var item in fruits){
                Console.WriteLine(item);
            }

        }

        static int[] RemoveAt(int[]source, int index)
        {
            int[] destination = new int[source.Length - 1];
            if (index > 0)
            {
                Array.Copy(source, 0, destination, 0, index);
            }
            if(index < source.Length-1){
                Array.Copy(source, index+1, destination, index, source.Length-index-1);
            }
            return destination;
        }

        static void RectangularArr()
        {
            int[,] myarr = new int[3, 2]
            {
                {1,2 },
                {3,4 },
                {5,6 },
            };

            foreach (var item in myarr)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{myarr[i, j]}".PadLeft(5));
                }
            }
        }

        static void JaggedArray()
        {
            int[][] numbers = new int[2][];
            numbers[0] = new int[5] { 1, 2, 3, 4, 5 };
            numbers[1] = new int[3] { 10, 20, 30 };

            foreach (var array in numbers){

                foreach (var item in array)
                {
                    Console.Write($"{item}".PadRight(5));
                }
                Console.WriteLine();
            }

            for(int i = 0; i<numbers.Length; i++){

                for(int j = 0;j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]}".PadRight(5));
                }
                Console.WriteLine();
            }

        }

        static void DateTimes()
        {
            DateTime current = DateTime.Now;
            DateTime dateTime = new DateTime(2002, 11, 04);
            DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime tomorrow = DateTime.Now.AddDays(1);


            Console.WriteLine(current);
            Console.WriteLine(current.ToShortDateString());
            Console.WriteLine(current.ToLongDateString());
            Console.WriteLine(current.ToShortTimeString());
            Console.WriteLine(current.ToLongTimeString());
            Console.WriteLine(current.Day);
            Console.WriteLine(current.DayOfWeek);
            Console.WriteLine(current.DayOfYear);



            Console.WriteLine(today.ToLongDateString());
            Console.WriteLine(tomorrow.ToLongDateString());
            Console.WriteLine(yesterday.ToLongDateString());


            Console.WriteLine(today);
            Console.WriteLine(today.AddHours(15));

            Console.WriteLine(dateTime.DayOfWeek);

            var difference = current - dateTime;

            Console.WriteLine(difference.TotalDays);

            DateTime dateTime2 = new DateTime(1, 1, 1);
            DateTime dateTime3 = new DateTime(1, 1, 1);


            Console.WriteLine(dateTime3.Equals(dateTime2));

        }

        static void Random()
        {
            Random random = new Random();
            Console.WriteLine(random.Next(1, 100));
            Console.WriteLine(random.NextDouble());
            Console.WriteLine(random.Next(1, 100) + random.NextDouble());
        }

        static void LogErrors()
        {
            try
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine(num1 / num2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var errorMessage = $@"
                    Error Message : {ex.Message}
                    Error Detail : {ex.StackTrace}    
                    Error Date : {DateTime.Now}

";
                File.WriteAllText("error.txt", errorMessage);
                throw;
            }

        }

        static void Main(string[] args){
            //One Dimensional Array

            //CreateAndReadArr();
            //ArrayClone();
            //AddArray();
            //RemoveAt()
#if false
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in numbers)
            {
                Console.Write($"{i} ");
            }
    
            Console.WriteLine();

            numbers = RemoveAt(numbers, 5);

            foreach (int i in numbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
#endif

            // Multidimensional Arrays
            //1. Rectangular
            //2. Jagged Array

            //RectangularArr();
            //JaggedArray();


        }
    }
}
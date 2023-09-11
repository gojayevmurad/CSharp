using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

namespace String
{
    public class Program
    {

        enum Days { Monday = 1, Tuesday, Wednesday, Thurday, Friday, Saturday, Sunday };

        static void ShowData(dynamic data){
            Console.WriteLine(data);
        }

        static int AddData(int num1, int num2)
        {
            return num1 + num2;
        }

        static void Change(ref int num)
        {
            num = 0;
        }

        static void Change(int[] arr)
        {
            arr[0] = 555;
        }



        static void DeleteSymbols(ref string text){

            text = text.Replace("/", "");
            text = text.Replace("?", "");

        }


        static void Main(string[] args)
        {
            #region
            //string text = "   John123    ";
            //Console.WriteLine(text);
            //Console.WriteLine(text.Length);
            //Console.WriteLine(text.Trim());


            //string message = "Sa??l?a???m";
            //message = message.Replace("?","");
            //Console.WriteLine(message);

            //string fruits = "Apple,Mango,Melon,PineApple,Banana";
            //var result = fruits.Split(',');
            //for (int i = 0; i < result.Length; i++){
            //    Console.WriteLine(result[i]);
            //}


            //string text = "Product\\GetAll {name : 'John Johnlu'}";
            //var result = text.Split(" ", 2);
            //for (int i = 0; i < result.Length; i++) {
            //    Console.WriteLine(result[i]);
            //}


            //string email = "david123@gmail.com";
            //var result = email.Split("@");
            //if (result[1] == "gmail.com")
            //{
            //    Console.Beep(800, 1000);
            //    Console.Beep(600, 1000);
            //}

            //string text1 = "salam";
            //string text2 = "salam";

            //Console.WriteLine(text1.Equals(text2));
            //Console.WriteLine(text1.CompareTo(text2));
            //Console.WriteLine(text1 == text2);

            //string site = "www.google.com";
            //Console.WriteLine(site.StartsWith("www"));
            //Console.WriteLine(site.EndsWith("com"));


            //string text = "Hello guys";
            //text += " Lebron James";
            //text = text.Insert(5, " Hello");
            //Console.WriteLine(text);

            //var firstIndex = text.IndexOf('L');
            //var lastIndex = text.LastIndexOf('L');


            //var domain = "www.dim.gov.az";
            //Console.WriteLine(domain);
            //var removedString = domain.Remove(5); // (5) => start 5  & (5,5) start index 5 remove 5 character
            //Console.WriteLine(removedString);

            //var text = "Programmer";
            //var subText = text.Substring(4, 3);
            //Console.WriteLine(subText);

            //var text = "Salam John";
            //Console.WriteLine(text.Contains("lam"));

            //var text = "Programmer";
            //var data = text.ToCharArray();

            //foreach(var item in data){
            //    Console.WriteLine(item);
            //}


            //mutable 
            //immutable

            //string text = "Salam";
            //string text2 = text;

            //text += "Hi";

            //Console.WriteLine(text);
            //Console.WriteLine(text2);

            //string text = "Hello";
            //text += " World";
            //text += " Bye bye";
            //Console.WriteLine(text);

            /*
                Hello 
                Hello World
                Hello World Bye bye;
            */




            //StringBuilder sb = new StringBuilder();
            //sb.Append("Hello");
            //sb.Append(" World");
            //sb.Append(" Bye bye");

            //var sb2 = sb;
            //sb2.Append(" Edited");
            //Console.WriteLine(sb2);
            //Console.WriteLine(sb);


            //Stopwatch stopwatch = new Stopwatch();

            //string text = "";
            //stopwatch.Start();
            //for (int i = 0; i < 50000; i++)
            //{
            //    text += " Hello world";
            //}
            //stopwatch.Stop();

            //Stopwatch stopwatch1 = new Stopwatch(); 

            //stopwatch1.Start();

            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 0; i<50000; i++){
            //    stringBuilder.Append(" Hello World");
            //}
            //stopwatch1.Stop();

            //Console.WriteLine(stopwatch.Elapsed.Milliseconds);
            //Console.WriteLine(stopwatch1.Elapsed.Milliseconds);


            //int age = null; // err
            //int? age = null; // ok
            //string text = null;

            //string? text = null;

            //if (string.IsNullOrEmpty(text)){

            //}

            #endregion


            #region

            //Console.WriteLine($"Today is {Days.Tuesday}");
            //Console.WriteLine($"Today is {(int)Days.Tuesday}");

            //Days today = Days.Tuesday;

            //int day = int.Parse(Console.ReadLine());
            //switch ((Days)day)
            //{
            //    case Days.Monday:
            //        Console.WriteLine("Bazar ertəsi");
            //        break;
            //    case Days.Tuesday:
            //        Console.WriteLine("Çərşənbə axşamı");
            //        break;
            //    case Days.Wednesday:
            //        break;
            //    case Days.Thurday:
            //        break;
            //    case Days.Friday:
            //        break;
            //    case Days.Saturday:
            //        break;
            //    case Days.Sunday:
            //        break;
            //    default:
            //        break;
            //}
            #endregion

            #region
            //string? text = null;

            //int? age = null;

            //Console.WriteLine(age.GetValueOrDefault());

            //if (age.HasValue){
            //    Console.WriteLine(age);
            //}
            //else
            //{
            //    Console.WriteLine("Value is null");
            //}

            //if(text is null)
            //{
            //    Console.WriteLine("Text is null");
            //}
            //else
            //{
            //    Console.WriteLine(text);
            //}

            //Console.ReadLine();

            #endregion


            //int? age = 123;
            //// ?? null coalasing operator
            //var result = (age ?? 100);

            //Console.Write(result);

            /*
             * what is checked vs unchecked 
             */

            /*
             * what it safe vs unsafe
             * and which is default
             */


            /*
                ShowData(AddData(10,20));
                int number = 555;
                Console.WriteLine(number);
                Change(ref number);
                Console.WriteLine(number);

                Console.WriteLine("==========================");

                int[] arr = { 1, 2, 3 };
                Console.WriteLine(arr[0]);
                Change(arr);
                Console.WriteLine(arr[0]);
            */


           

        }
    }
}
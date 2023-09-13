namespace ConsoleApp1
{

    public static class Validations
    {
        public static bool CheckPAN(string pan) {
            if (pan.Length == 16) return true;
            throw new ArgumentException("PAN should be 16 digits");
        }
    }


    internal class Program
    {

        static int Calc(int x) => 10 / x;

        static void Handle1(){
            try{
                int result = Calc(0);
                Console.WriteLine(result);
            }
            catch (DivideByZeroException ex){
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
        }

        static void Handle2()
        {
            string[] data = new string[3] { "salam", "516", "data" };
            try
            {
                //Console.WriteLine(data[10]); // index out of => IndexOutOfRangeException
                //byte d = byte.Parse(data[1]); // overflow exception => OverflowException
                //int d = int.Parse(data[0]); // format exception => FormatException
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int GetDiv(int num1, int num2)
        {
            if(num2 != 0) return num2 / num1;
            
            
            throw new DivideByZeroException("You can not divide by Zero");
        }

        static void Handle3()
        {
            try
            {
                GetDiv(10, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Display(string data)
        {
            if(data==null)
            {

                throw new ArgumentNullException("Null Data");

            }else if (data.Trim() == string.Empty)
            {

                throw new Exception("Data can not be empty");

            }

            Console.WriteLine(data);
        }

        static void Handle4()
        {
            try
            {
                Display(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Inner exception");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        static int GetData(int[] arr, int index)
        {
            try
            {
                return arr[index];
            }
            catch (IndexOutOfRangeException ex) when (index<0)
            {
                throw new ArgumentOutOfRangeException("Parameter index can not be negative");
            }
            catch (IndexOutOfRangeException ex) when (index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("Parameter index can not be greater or equal size of array");
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };

            try
            {
                var a = GetData(arr, -100);
                Console.WriteLine(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
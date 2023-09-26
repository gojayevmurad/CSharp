using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace FileStrm
{

    class A : IDisposable
    {

        public void Dispose() {

        }

    }

    class Book
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Title { get; set; }

        public override string ToString()
        {
            return $@"
                ID : {Id}
                Author : {Author}
                Genre : {Genre}
                Title : {Title}
            ";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
#if false

            #region FileStream Text Write
            //FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            //try
            //{

            //    string text = Console.ReadLine();
            //    byte[] bytes = Encoding.Default.GetBytes(text);

            //    fs.Write(bytes, 0, bytes.Length);
            //}
            //finally 
            //{
            //    fs.Close();
            //    fs.Dispose();
            //}

            using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                string text = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
            }

            var a = new A();

            using (var  b = new A())
            {

            }


            #endregion

#endif
#if false
            #region FileStream Text Read
            using (var fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);

                string text = Encoding.Default.GetString(bytes);
                Console.WriteLine(text);
            }

            #endregion
#endif
#if false
            #region StreamWriter Write
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Saint-Exupery",
                    Genre="Children's Literature",
                    Title="Little Prince"
                },
                new Book
                {
                    Id= 2,
                    Author = "Robert Kiyosaki",
                    Genre = "Self Improvement",
                    Title = "Cash Flow"
                },
                new Book
                {
                    Id= 3,
                    Author = "Robert Kiyosaki, Sheron Letcher",
                    Genre = "Self Improvement",
                    Title = "Rich Dad, Poor Dad"
                }
            };

            using (var fs = new FileStream("book.txt", FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs, Encoding.ASCII))
                {
                    books.ForEach(b => sw.WriteLine(b));
                }
            }

            #endregion
#endif

#if false
            #region StreamReader Read

            using (var fs = new FileStream("book.txt", FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fs, Encoding.ASCII))
                {
                    Console.WriteLine("From file : ");
                    var text = sr.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            #endregion
#endif

#if false
            #region Binary Writer

            using (var fs = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    var book = new Book
                    {
                        Id = 1,
                        Author = "Saint-Exupery",
                        Genre = "Children's Literature",
                        Title = "Little Price"
                    };

                    bw.Write(book.Id);
                    bw.Write(book.Author);
                    bw.Write(book.Genre);
                    bw.Write(book.Title);
                    Console.WriteLine("Process Completed");
                }
            };
            #endregion
#endif

#if false
            #region Binary Reader
            using (var fs = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                using (var br = new BinaryReader(fs))
                {
                    var book = new Book
                    {
                        Id = br.ReadInt32(),
                        Author = br.ReadString(),
                        Genre = br.ReadString(),
                        Title = br.ReadString(),
                    };

                    Console.WriteLine("Binary Read");
                    Console.WriteLine(book);
                }
            }
            #endregion
#endif

            // File

            // FileInfo

            // Directory

            // Directory Info
            DirectoryInfo dir = new DirectoryInfo(".");
            //Console.WriteLine(dir.FullName);
            //Console.WriteLine(dir.Name);
            //Console.WriteLine(dir.Parent);
            //Console.WriteLine(dir.CreationTime);
            //Console.WriteLine(dir.CreateSubdirectory("Apple"));

            //var files = dir.GetDirectories();
            //foreach (var file in files)
            // {
            //     Console.WriteLine(file);
            // }

            //create folders

            //var path = SpecialDirectories.Desktop;
            //DirectoryInfo directory = new DirectoryInfo(path);

            //foreach (var item in directory.GetDirectories())
            //{
            //    if (item.Name.Contains("myfile"))
            //        Directory.Delete(item.FullName);
            //}


            //for (int i = 0; i < path.Length; i++)
            //{
            //    directory.CreateSubdirectory($"myfile-{i}");
            //}


            // start calc 100 times

            //for (int i = 0; i < 100; i++)
            //{
            //    Process.Start("calc.exe");
            //}


            //FileInfo file = new FileInfo("book.txt");
            //Console.WriteLine(file.FullName);
            //Console.WriteLine(file.Extension);
            //Console.WriteLine(file.CreationTime);

            //File.WriteAllText("mytest.txt", "Hello world");

            string name = Console.ReadLine();

            if(File.Exists(name))
            {
                Console.WriteLine("We have that File");
            }
            else
            {
                Console.WriteLine("doesn't exist");
            }


        }
    }
}
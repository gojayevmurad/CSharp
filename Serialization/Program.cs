using System.Net.Security;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{

    class Car
    {
        [JsonProperty("CarModel")]
        public string? Model { get; set; }
        public string? Vendor { get; set; }
        //[JsonIgnore]
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Model?.PadRight(15)} {Vendor} {Year}";
        }
    }


    internal class Program
    {
#if false
        #region XML Serialization
        static void XmlSerialize()
        {
            var army = new TranslatorArmy
            {
                Name = "Step IT Academy",
                Location = "Koroglu Rehimov 81",
                Translators = new List<Translator>
                {
                    new Translator (1,"Tural", "Eliyev")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "C++",
                                Degree = 42,
                                Lessons = 68
                            },
                            new Subject
                            {
                                Name = "C#",
                                Degree = 46,
                                Lessons = 64
                            }
                        }
                    },
                    new Translator (2, "Eli", "Mammadov")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "Adobe Photoshop",
                                Degree = 42,
                                Lessons = 30
                            },
                            new Subject
                            {
                                Name = "PHP",
                                Degree = 43,
                                Lessons = 35
                            }
                        }
                    },
                    new Translator (3, "Leyla", "Eliyeva")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "HTML/CSS",
                                Degree = 42,
                                Lessons = 30
                            },
                            new Subject
                            {
                                Name = "Angular 16",
                                Degree = 42,
                                Lessons = 35
                            }
                        }
                    }
                }
            };

            var xml = new XmlSerializer(typeof(TranslatorArmy));

            using (var fs = new FileStream("TranslatorArmy.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, army);
            }
        }

        static void XmlDeserialize()
        {
            TranslatorArmy army = null;
            var xml = new XmlSerializer(typeof(TranslatorArmy));

            using (var fs = new FileStream("TranslatorArmy.xml", FileMode.OpenOrCreate))
            {
                army = xml.Deserialize(fs) as TranslatorArmy;
            }

            Console.WriteLine(army);

        }
        #endregion

        #region Binary Serialization

        static void BinarySerializer()
        {
            var army = new TranslatorArmy
            {
                Name = "Step IT Academy",
                Location = "Koroglu Rehimov 81",
                Translators = new List<Translator>
                {
                    new Translator (1,"Tural", "Eliyev")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "C++",
                                Degree = 42,
                                Lessons = 68
                            },
                            new Subject
                            {
                                Name = "C#",
                                Degree = 46,
                                Lessons = 64
                            }
                        }
                    },
                    new Translator (2, "Eli", "Mammadov")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "Adobe Photoshop",
                                Degree = 42,
                                Lessons = 30
                            },
                            new Subject
                            {
                                Name = "PHP",
                                Degree = 43,
                                Lessons = 35
                            }
                        }
                    },
                    new Translator (3, "Leyla", "Eliyeva")
                    {
                        Subjects = new List<Subject>
                        {
                            new Subject
                            {
                                Name = "HTML/CSS",
                                Degree = 42,
                                Lessons = 30
                            },
                            new Subject
                            {
                                Name = "Angular 16",
                                Degree = 42,
                                Lessons = 35
                            }
                        }
                    }
                }
            };

            var bf = new BinaryFormatter();
            using (var fs = new FileStream("file.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, army);
            }
            Console.WriteLine("OK");
        }

        static void BinaryDeserializer()
        {
            TranslatorArmy army = null;
            var bf = new BinaryFormatter();
            using (var fs = new FileStream("file.bin", FileMode.OpenOrCreate))
            {
                army = bf.Deserialize(fs) as TranslatorArmy;
                Console.WriteLine(army);
            }

        }


        #endregion
#endif

        #region JSON Serialization

        public static List<Car> Cars = new List<Car> {
                    new Car
                    {
                        Model = "Mustang",
                        Vendor = "Ford",
                        Year = 1964
                    },
                    new Car
                    {
                        Model = "Charger",
                        Vendor = "Dodge",
                        Year = 1965
                    },
                    new Car
                    {
                        Model = "Veyron",
                        Vendor = "Bugatti",
                        Year = 2020
                    }
                };


        static void WriteJson()
        {

            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("cars.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, Cars);
                }
            }

        }

        static List<Car> ReadJson()
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("cars.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    Cars = serializer.Deserialize<List<Car>>(jr);
                    return Cars;
                }
            }
        }

        #endregion


        static void Main(string[] args)
        {
            //WriteJson();
            Cars = ReadJson();
            foreach (var item in Cars)
            {
                Console.WriteLine(item);
            }
        }
#if false
        #region XML
        public static void OldReadXML()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load("cars.xml");
            var root = doc.DocumentElement;

            if (root.HasChildNodes)
            {
                foreach (XmlNode car_node in root.ChildNodes)
                {
                    var c = new Car
                    {
                        Model = car_node.Attributes[0].Value,
                        Vendor = car_node.Attributes[1].Value,
                        Year = int.Parse(car_node.Attributes[2].Value),
                    };
                    Console.WriteLine(c);
                }
            }

        }

        public static void WriteXML()
        {
            List<Car> cars = new List<Car> {
                    new Car
                    {
                        Model = "Mustang",
                        Vendor = "Ford",
                        Year = 1964
                    },
                    new Car
                    {
                        Model = "Charger",
                        Vendor = "Dodge",
                        Year = 1965
                    },
                    new Car
                    {
                        Model = "Veyron",
                        Vendor = "Bugatti",
                        Year = 2020
                    }
                };

            using (var writer = new XmlTextWriter("cars.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                foreach (var car in cars)
                {
                    writer.WriteStartElement("Car");
                    writer.WriteAttributeString(nameof(car.Model), car.Model);
                    writer.WriteAttributeString(nameof(car.Vendor), car.Vendor);
                    writer.WriteAttributeString(nameof(car.Year), car.Year.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        #endregion
#endif

    }

}
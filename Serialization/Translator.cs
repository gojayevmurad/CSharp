using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    public class Translator
    {
        public List<Subject> Subjects { get; set; }
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string? Name { get; set; }
        [XmlAttribute]
        public string? Surname { get; set; }
        [XmlAttribute]
        public string Fullname => $"{Name} {Surname}";

        public Translator(){}

        public Translator(int id, string? name, string? surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            if (Subjects != null)
            {
                foreach (Subject subject in Subjects)
                {
                    Console.WriteLine(subject);
                }
            }
            return $"{Id} - {Fullname}";
        }
    }
}

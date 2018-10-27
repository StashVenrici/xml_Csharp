using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
	

namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML");
            CreateXMLFile();


            Console.ReadKey();
        }
        //generating XML file - arraylist of users
        public static void CreateXMLFile()
        {
            var listUsers = new List<User>()
                {
                    new User { Name="Vasea Pupkin", Age=25, Company="Pupkin Company"},
                    new User { Name="John Smith", Age=29, Company="Hollywood"},
                    new User { Name="Britnie Lopes", Age=45, Company="Umbrella"}
                };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<User>));
            TextWriter Filestream = new StreamWriter(@"D:\Users.xml");
            serialiser.Serialize(Filestream, listUsers);
            Filestream.Close();
        }
    }
}

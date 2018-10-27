using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
	

namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML");
            CreateXMLFile();
            ReadXMLFile();

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
        //read
        public static void ReadXMLFile()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(@"D:\Users.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("User");
            for ( i = 0; i <= xmlnode.Count - 1; i++)
            {
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                Console.WriteLine(str);
            }
            fs.Close();
            Console.WriteLine("End of file.");
        }
    }
}

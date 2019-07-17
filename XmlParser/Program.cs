using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument doc = new XmlDocument();
            //var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };

            string filePath = $@"C:\Users\example.xml";
            //FileInfo file = new FileInfo(filePath);

            //using (XmlReader reader=XmlReader.Create(filePath))
            //{
            //    while (reader.Read())
            //    {
            //      var c= reader.GetAttribute("register");

            //        if (c.)
            //        {

            //        }
            //        Console.ReadLine();
            //    }
            //}


            XDocument doc = XDocument.Load(filePath);
            var register = doc.Root.Elements().Select(t => t.Element("register"));
            var registers = doc.Descendants("register");
            var elemnts = doc.Elements().Select(t=>t.Element("registers"));

            //foreach (var item in elemnts)
            //{
            //    XNode s;
            //    if (item!=null)
            //     if(item.HasAttributes)
            //         s = item.FirstNode;
            //}

            foreach (var item in registers)
            {
                var nodes = item.Nodes();
                foreach (XElement node in nodes)
                {
                    var x = node.Value;
                    
                    XNode xs = node;
                   
                }
                var s = item.Value;
                
            }



        }
    }
}

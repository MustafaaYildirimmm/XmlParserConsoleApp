using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string sedas_Endex = $@"C:\Users\msft_\Desktop\HAYEN\TASKS\SEDAS-XMLPARSER\sedas_Ro_1_tld.xml";
            string sedas_LoadProfile = $@"C:\Users\msft_\Desktop\HAYEN\TASKS\SEDAS-XMLPARSER\sedas_lp_1_btm.xml";

            //for endex
            string meterId = "metering-point-id";
            string valueId = "value-id";
            string timespan = "timestamp";
            string element = "register";

            //for load Profile
            string locKey = "Loc-Key";
            string custKey = "Cust-Key";
            string profileDate = "START-DATETIME";
            string interval = "INTERVAL";
            string value = "V";

            Dictionary<DateTime, int> values = new Dictionary<DateTime, int>();


            //endex parser
            XDocument endexDoc = XDocument.Load(sedas_Endex);

            var registers = endexDoc.Descendants(element).Select(t => new
            {
                EtsoCode = t.Attribute(meterId).Value, Values = t.Attribute(valueId).Value, EndexDate = t.Attribute(timespan).Value
            });


            var endex = registers.GroupBy(t => new
            {
                t.EtsoCode,
                t.EndexDate
            }).Select(s => new
            {
                MeterId=s.Key.EtsoCode,
                EndexDate=s.Key.EndexDate,
                ValueId=s.Select(t=>t.Values).ToList()
            });


            //load profle parser
            XDocument loadDoc = XDocument.Load(sedas_LoadProfile);

            XNamespace adlcp = "http://example.com/adlcp";

            var adta = loadDoc.Descendants(sedas_LoadProfile);

            var sadsa = adta.Elements();
            //var data = loadDoc.Descendants(sedas_LoadProfile).Elements("DATA").Select(t => new
            //{
            //    EtsoCode = t.Element(locKey).Value,
            //    Name = t.Element(custKey).Value
            //});

            //var data = loadDoc.Descendants(sedas_LoadProfile).ToList();

            //List<LoadProfile> loadProfiles = new List<LoadProfile>();

            //foreach (var item in data)
            //{
            //    LoadProfile profile = new LoadProfile();



            //    profile.EtsoCode = item.Element(locKey).Value;
            //    profile.Name = item.Element(custKey).Value;
            //    profile.Values.Add()

            //}

        }

    }
}


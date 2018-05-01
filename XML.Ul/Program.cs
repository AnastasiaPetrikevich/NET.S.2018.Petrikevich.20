using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XML.Logic.CreateXML;

namespace XML.Ul
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> url = new List<string>();
            url.Add("https://github.com/AnzhelikaKravchuk?tab=repositories");
            url.Add("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
            url.Add("https://habrahabr.ru/company/it-grad/blog/341486/");

            CreateXmlFromUrl(url, @"C:\Users\Анастасия\Desktop\xmlFile.xml");
        }
    }
}

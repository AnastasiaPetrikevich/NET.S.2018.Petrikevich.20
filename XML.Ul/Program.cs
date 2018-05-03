using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML.Logic;
using XML.Logic.Logger;
using static XML.Logic.CreateXML;

namespace XML.Ul
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProvider provider=new FileProvider(@"C:\Users\Анастасия\Source\Repos\XML\XML.Ul\url.txt", new Parser(), new NLogger());
            CreateXmlFromUrl(provider.Load(), @"C:\Users\Анастасия\Source\Repos\XML\XML.Ul\xmlFile.xml");
        }
    }
}

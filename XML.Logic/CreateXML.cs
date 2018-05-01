using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XML.Logic
{
    public static class CreateXML
    {
        public static void CreateXmlFromUrl(IEnumerable<string> urlList, string fileName)
        {
            XDocument document = new XDocument();
            foreach (var item in urlList)
            {
                document.Add(CreateXmlFromUrl(item));
            }

            document.Save(fileName);
        }

        private static XElement CreateXmlFromUrl(string url)
        {
            XElement rootElement = new XElement("urlAdresses");
            var tempStrings = UrlSubstring(url).Split('/');

            XAttribute hostName = new XAttribute("host name", tempStrings[0]);
            rootElement.Add(hostName);

            XElement urlElement = new XElement("url");
            for (int i = 1; i < tempStrings.Length; i++)
            {
                if (!tempStrings[i].Contains('?'))
                {
                    XElement element = new XElement("segment", tempStrings[i]);
                    urlElement.Add(element);
                }

                else
                {
                    var tempElements = tempStrings[i].Split('?');
                    for (int j = 0; j < tempElements.Length; j++)
                    {
                        if (!tempElements[j].Contains('='))
                        {
                            XElement element = new XElement("segment", tempElements[j]);
                            urlElement.Add(element);
                        }

                        else
                        {
                            XElement parametrsElement = new XElement("parametrs");
                            var tempAttribute = tempElements[j].Split('=');
                            XAttribute attribute = new XAttribute("values", tempAttribute[1]);
                            parametrsElement.Add(attribute);
                            attribute = new XAttribute("key", tempAttribute[0]);
                            parametrsElement.Add(attribute);
                            rootElement.Add(parametrsElement);
                        }
                    }
                }
            }
            rootElement.Add(urlElement);

            return rootElement;
        }
        
        private static string UrlSubstring(string url)
        {
            if (url.Contains("http://"))
            {
                return url.Substring(7);
            }

            if (url.Contains("https://"))
            {
                return url.Substring(8);
            }

            throw new ArgumentException($"nameof(url) wrong url.");
        }
    }
}

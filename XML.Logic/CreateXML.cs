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
        /// <summary>
        /// Create XML document.
        /// </summary>
        /// <param name="urlList"></param>
        /// <param name="fileName"></param>
        public static void CreateXmlFromUrl(IEnumerable<URL> urlList, string fileName)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("urlAddresses");
            
            foreach (var item in urlList)
            {
                root.Add(CreateXmlElement(item));
            }

            document.Add(root);
            document.Save(fileName);
        }

        /// <summary>
        /// Create XML element from URL.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns>XML element.</returns>
        private static XElement CreateXmlElement(URL url)
        {
            XElement xmlElement = new XElement("urlAdresses");
            XElement hostElement = new XElement("host", new XAttribute("name", url.HostName));
            xmlElement.Add(hostElement);

            XElement uri = new XElement("uri");
            foreach (var item in url.Segments)
            {
                uri.Add(new XElement("segment", item));
            }
            xmlElement.Add(uri);

            XElement parameters = new XElement("parameters");
            foreach (var item in url.ParametersKeyValue)
            {
                parameters.Add(new XElement("parameter", new XAttribute("value", item.Value), 
                    new XAttribute("key", item.Key)));
            }
            xmlElement.Add(parameters);

            return xmlElement;
        }
    }
}

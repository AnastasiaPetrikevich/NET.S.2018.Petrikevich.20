using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Logic
{
    public class Parser
    {
        /// <summary>
        /// Parse url string.
        /// </summary>
        /// <param name="sourceString">url to parse.</param>
        /// <returns>parsed string</returns>
        public URL Parse(string sourceString)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException(nameof(sourceString));
            }

            URL url = new URL();
            url.TransmissionProtocol = UrlSubstring(sourceString)[0];

            var parseString = UrlSubstring(sourceString)[1].Split('/', '?');
            url.HostName = parseString[0];
            for (int i = 1; i < parseString.Length; i++)
            {
                if (!parseString[i].Contains("="))
                {
                    url.Segments.Add(parseString[i]);
                }
                else
                {
                    var parameters = parseString[i].Split('=');
                    url.ParametersKeyValue.Add(new KeyValuePair<string, string>(parameters[0], parameters[1]));
                }
            }
            
            return url;
        }
        
        /// <summary>
        /// Give url without transmission protocol.
        /// </summary>
        /// <param name="url">Url string.</param>
        /// <returns>String.</returns>
        private static string[] UrlSubstring(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Contains("http://"))
            {
                return new[] { "http://", url.Substring(7) };
            }

            if (url.Contains("https://"))
            {
                return new[] { "https://", url.Substring(8) };
            }

            throw new ArgumentException($"{nameof(url)} wrong url.");
        }
    }
}

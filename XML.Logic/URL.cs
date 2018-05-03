using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Logic
{
    /// <summary>
    /// URL representation.
    /// </summary>
    public class URL
    {
        public string TransmissionProtocol{ get; set; }
        public string HostName { get; set; }
        public List<string> Segments { get; set; } =  new List<string>();
        public List<KeyValuePair<string, string>> ParametersKeyValue { get; set; } =
            new List<KeyValuePair<string, string>>();

    }
}

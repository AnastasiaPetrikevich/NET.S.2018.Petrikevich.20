using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrinterFactory
    {
        internal Printer CreatePrinter(string name, string model)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            switch (name)
            {
                case "Canon":
                    return new CanonPrinter(model);
                case "Epson":
                    return new EpsonPrinter(model);
                default:
                    throw new ArgumentException($"Unknown printer {nameof(name)} {nameof(model)}.");
            }
        }
    }
}

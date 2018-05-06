using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public sealed class PrintEventArgs : EventArgs
    {
        public string Name { get; }

        public string Model { get; }

        public string Time { get; }

        public PrintEventArgs(Printer printer)
        {
            Name = printer.Name;
            Model = printer.Model;
            Time = DateTime.Now.ToShortTimeString();
        }
    }
}

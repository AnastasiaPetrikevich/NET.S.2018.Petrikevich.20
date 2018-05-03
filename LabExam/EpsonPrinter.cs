using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// inherited from the Printer. 
    /// </summary>
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            Name = "Epson";
            Model = "231";
        }

        public EpsonPrinter(string model)
        {
            Name = "Epson";
            Model = model;
        }

        public override void Print(FileStream fs)
        {
            using (fs)
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    // simulate printing
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }

    }
}
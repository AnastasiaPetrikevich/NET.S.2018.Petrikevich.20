﻿using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// inherited from the Printer. 
    /// </summary>
    internal class CanonPrinter : Printer
    {

        public CanonPrinter()
        {
            Name = "Canon";
            Model = "123x";
        }

        public CanonPrinter(string model)
        {
            Name = "Canon";
            Model = model;
        }

        protected override void SimulatePrint(Stream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

    }
}
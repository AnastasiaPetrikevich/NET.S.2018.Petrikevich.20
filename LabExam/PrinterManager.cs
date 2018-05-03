using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{
    internal class PrinterManager : IEnumerable<Printer>
    {
        public static List<Printer> Printers { get; set; }

        /// <summary>
        /// added field for logging
        /// </summary>
        private readonly ILogger logger;

        public PrinterManager(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Printers = new List<Printer>();
        }

        /// <summary>
        /// Add logging.
        /// </summary>
        public void Add(string name, string model)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (name == "Canon")
            {
                var canonPrinter = new CanonPrinter(model);
                if (!Printers.Contains(canonPrinter))
                {
                    Printers.Add(canonPrinter);
                    Console.WriteLine("Printer added.");
                    logger.Debug("Printer successfully added.");
                }
            }

            if (name == "Epson")
            {
                var epsonPrinter = new EpsonPrinter(model);
                if (!Printers.Contains(epsonPrinter))
                {
                    Printers.Add(epsonPrinter);
                    Console.WriteLine("Printer added.");
                    logger.Debug("Printer successfully added.");
                }
            }

            else
            {
                Console.WriteLine("Unknown printer model.");
                logger.Debug("Unknown printer model.");
            }


        }

        /// <summary>
        /// Added events and logging.
        /// </summary>
        /// <param name="printer">printer</param>
        public void Print(Printer printer)
        {
            logger.Debug("Print started.");

            using (var o = new OpenFileDialog())
            {
                o.ShowDialog();
                var f = File.OpenRead(o.FileName);
                printer.Print(f);
            }
            
            logger.Debug("Print finished.");
        }

        public bool Contains(Printer printer)
        {
            var equalityComparer = EqualityComparer<Printer>.Default;

            return Printers.Contains(printer, equalityComparer);
        }

        public void Subscribe(Printer printer)
        {
            printer.PrintEvent += Printing;
        }

        public void Unsubscribe(Printer printer)
        {
            printer.PrintEvent -= Printing;
        }

        public void Printing(object sender, PrintEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public IEnumerator<Printer> GetEnumerator()
        {
            foreach (Printer printer in Printers)
            {
                yield return printer;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NLog;

namespace LabExam
{
    internal sealed class PrinterManager : IEnumerable<Printer>
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

            var printer = new PrinterFactory().CreatePrinter(name, model);

            if (!Printers.Contains(printer))
            {
                printer.StartPrint += (sender, args) => logger.Debug($"Printer {printer.Name} {printer.Model} start printing at {args.Time}");
                printer.EndPrint += (sender, args) => logger.Debug($"Printer {printer.Name} {printer.Model} end printing at {args.Time}");

                Printers.Add(printer);
                Console.WriteLine("Printer added.");
                logger.Debug("Printer successfully added.");
            }
        }


        /// <summary>
        /// Added events and logging.
        /// </summary>
        /// <param name="printer">printer</param>
        public void Print(Printer printer)
        {
            if (!Printers.Contains(printer))
            {
                throw new ArgumentException($"No such printer {nameof(printer)}.");
            }
            
            logger.Debug("Print started.");
            using (var o = new OpenFileDialog())
            {
                o.ShowDialog();
                using (var file = File.OpenRead(o.FileName))
                {
                    printer.Print(file);
                }
            }
            logger.Debug("Print finished.");

        }

        public bool Contains(Printer printer)
        {
            var equalityComparer = EqualityComparer<Printer>.Default;

            return Printers.Contains(printer, equalityComparer);
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
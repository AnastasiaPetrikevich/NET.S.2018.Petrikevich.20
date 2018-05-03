using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExam
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");
            Console.WriteLine("4:Show printers");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(new CanonPrinter());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new EpsonPrinter());
            }

            if (key.Key == ConsoleKey.D4)
            {
                Show();
            }

            while (true)
            {
                // waiting
            }
        }

        private static void Print(EpsonPrinter epsonPrinter)
        {
            PrinterManager manager = new PrinterManager(new NLogger());
            manager.Print(epsonPrinter);
            
        }

        private static void Print(CanonPrinter canonPrinter)
        {
            PrinterManager manager = new PrinterManager(new NLogger());
            manager.Print(canonPrinter);
           
        }
       
        private static void CreatePrinter()
        {
            PrinterManager manager = new PrinterManager(new NLogger());

            Console.WriteLine("Enter printer name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter printer model: ");
            var model = Console.ReadLine();

            manager.Add(name, model);
        }

        
        private static void Show()
        {
            PrinterManager manager = new PrinterManager(new NLogger());

            foreach (Printer printer in manager)
                {
                    Console.WriteLine(printer.ToString());
                }
            
        }

    }
}

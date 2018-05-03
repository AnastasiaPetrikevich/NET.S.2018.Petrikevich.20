using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public sealed class PrintEventArgs : EventArgs
    {
        private string message;

        public PrintEventArgs(string message)
        {
            this.message = message;
        }

        public string Message => message;
    }
}

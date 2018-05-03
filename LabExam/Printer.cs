using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// made an abstract clss for inheritance.
    /// </summary>
    internal abstract class Printer : IEquatable<Printer>
    {
        public string Name { get; set; }

        public string Model { get; protected set; }

        public abstract void Print(FileStream fs);


        public bool Equals(Printer other)
        {
            if ((this.Name == other.Name && this.Model == other.Model) || (ReferenceEquals(this, other)))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Printer)obj);
        }

        public override string ToString()
        {
            return $"name: {Name}, model: {Model}";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Model.GetHashCode();
        }


        public event EventHandler<PrintEventArgs> PrintEvent = delegate { };

        protected virtual void OnPrint(PrintEventArgs e) => PrintEvent?.Invoke(this, e);
        
        public void Printed(string message)
        {
            OnPrint(new PrintEventArgs(message));
        }

    }
}
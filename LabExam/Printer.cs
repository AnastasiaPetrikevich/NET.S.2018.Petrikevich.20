using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// made an abstract clss for inheritance.
    /// </summary>
    public abstract class Printer : IEquatable<Printer>
    {
        public string Name { get; protected set; }

        public string Model { get; protected set; }

        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public void Print(Stream fileStream)
        {
            OnStartPrint(new PrintEventArgs(this));
            SimulatePrint(fileStream);
            OnEndPrint(new PrintEventArgs(this));

        }

        protected abstract void SimulatePrint(Stream fileStream);


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


        public event EventHandler<PrintEventArgs> StartPrint = delegate { };

        protected virtual void OnStartPrint(PrintEventArgs e) => StartPrint?.Invoke(this, e);

        public event EventHandler<PrintEventArgs> EndPrint = delegate { };

        protected virtual void OnEndPrint(PrintEventArgs e) => EndPrint?.Invoke(this, e);

        public void StartPrinted(string message)
        {
            OnStartPrint(new PrintEventArgs(message));
        }

        public void EndPrinted(string message)
        {
            OnEndPrint(new PrintEventArgs(message));
        }

    }
}
namespace Employee
{
    public abstract class Employee
    {
        const decimal TaxRate = (decimal)0.2;

        public string Name { get; set; }

        public Employee(string name) // constructor
        {
            Name = name;
        }

        protected abstract decimal CalculatePay();
    }

    class Program()
    {
        static void Main()
        {
            
        }
    }
}
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

    interface IReportable
    {
        string GenerateReport();
    }

    public class FullTimeEmployee : Employee, IReportable
    {
        const decimal TaxRate = (decimal)0.2;

        public decimal AnnualSalary { get; set; }
        public FullTimeEmployee(string name, decimal annual_salary) : base(name)
        {
            AnnualSalary = annual_salary;
        }

        protected override decimal CalculatePay()
        {
            decimal Tax = TaxRate * AnnualSalary;
            return AnnualSalary - Tax;
        }

        public string GenerateReport()
        {
            string Output = $"{Name} is a full-time employee. Their annual salary is {AnnualSalary:C2}, or {CalculatePay():C2} after tax.";
            return Output;
        }
    }

    public class Contractor : Employee, IReportable
    {
        const decimal TaxRate = (decimal)0.2;

        public decimal Rate { get; set; }
        public decimal Hours { get; set; }
        public Contractor(string name, decimal rate, decimal hours) : base(name)
        {
            Rate = rate;
            Hours = hours;
        }

        protected override decimal CalculatePay()
        {
            decimal Tax = TaxRate * Rate * Hours;
            return Rate * Hours - Tax;
        }

        public string GenerateReport()
        {
            string Output = $"{Name} is a contractor. Their hourly rate is {Rate:C2}, and their total number of hours worked is {Hours}, which comes out to {CalculatePay():C2} after tax.";
            return Output;
        }
    }

    class Program()
    {
        static void Main()
        {
            FullTimeEmployee employee_1 = new("Alice", 100000);
            Contractor employee_2 = new("Bob", 25, 400);
            Console.WriteLine(employee_1.GenerateReport());
            Console.WriteLine(employee_2.GenerateReport());
        }
    }
}
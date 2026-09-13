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

    public class FullTimeEmployee : Employee
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
    }

    public class Contractor : Employee
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
    }

    class Program()
    {
        static void Main()
        {
            
        }
    }
}
namespace Topic1A
{
    class Program
    {
        const double tax_rate = 0.2;

        static double CalculatePay(double hours, double rate)
        {
            try
            {
                if ((hours < 0) || (rate < 0))
                {
                    throw new ArgumentException("Hours and Rate must be positive.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }

            var gross = hours * rate;
            var tax = gross * tax_rate;
            var net = gross - tax;
            return net;
        }

        static void Main()
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Hours worked: ");
            double hours = double.Parse(Console.ReadLine());

            Console.Write("Hourly Rate: ");
            double rate = double.Parse(Console.ReadLine());

            double net_pay = CalculatePay(hours, rate);
            Console.WriteLine($"{name} earned ${net_pay:F2} after tax.");
        }
    }
}
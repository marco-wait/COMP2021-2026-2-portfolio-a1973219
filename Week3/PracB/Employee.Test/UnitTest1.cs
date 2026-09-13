namespace Employee.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void FullTimeEmployee_Calculates_Pay()
        {
            var employee_1 = new FullTimeEmployee("John", 100);
            decimal expected_pay = 100 - (Employee.TaxRate * 100);
            Assert.Equal(expected_pay, employee_1.CalculatePay());
        }

        [Fact]
        public void Contractor_Calculates_Pay()
        {
            var employee_2 = new Contractor("Jane", 20, 5);
            decimal expected_pay = employee_2.Rate * employee_2.Hours * (1 - Employee.TaxRate);
            Assert.Equal(expected_pay, employee_2.CalculatePay());
        }
    }
}
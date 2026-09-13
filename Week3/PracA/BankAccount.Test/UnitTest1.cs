namespace BankAccount.Test
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_AddsToBalance_Decimal()
        {
            // testing whether Deposit method works as intended
            var a = new BankAccount("Alice", 100);
            decimal value1 = 50;
            a.Deposit(value1);
            Assert.Equal(150, a.Balance);
        }

        [Fact]
        public void Deposit_AddsToBalance_Int()
        {
            var b = new BankAccount("Bob", 100);
            int value2 = 25;
            b.Deposit(value2);
            Assert.Equal(125, b.Balance);
        }

        [Fact]
        public void Deposit_AddsToBalance_Double()
        {
            var c = new BankAccount("Charlie", 100);
            double value3 = 5.0;
            c.Deposit(value3);
            Assert.Equal(105, c.Balance);
        }

        [Fact]
        public void Withdraw_SubtractsFromBalance()
        {
            var d = new BankAccount("Dominic", 100);
            d.Withdraw(1);
            Assert.Equal(99, d.Balance);
        }

        [Fact]
        public void Withdraw_BalanceTooLow_Throws()
        {
            var e = new BankAccount("Eleanor", 100);

            bool result = false;

            try
            {
                e.Withdraw(9999);
            }
            catch (ArgumentException x) when (x.Message.Contains("balance too low"))
            {
                result = true;
            }

            Assert.True(result);
        }

        [Fact]
        public void SavingsAccount_AppliesInterestCorrectly()
        {
            var f = new SavingsAccount("Felix", 100, (decimal)2.5);
            f.ApplyInterest();
            Assert.Equal(102.5, (double)f.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_AppliesTransactionFee()
        {
            var g = new CheckingAccount("Gina", 100, (decimal)0.25);
            g.Withdraw(99);
            Assert.Equal(0.75, (double)g.Balance);
        }
    }
}

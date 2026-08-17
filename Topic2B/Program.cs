public class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

    public void Deposit(double amount)
    {
        Balance += (decimal)amount;
    }

    public void Withdraw(decimal amount)
    {
        if(Balance < amount)
        {
            throw new ArgumentException("Account balance too low.");
        }
        Balance -= amount;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new("Marco", 100);
        Console.WriteLine($"This account belongs to {account1.Owner}.");
        Console.WriteLine($"This account contains ${account1.Balance}.");
        // expected outputs should contain: Marco, $100

        decimal test1 = 50;
        account1.Deposit(test1);
        Console.WriteLine($"After depositing $50, this account now contains ${account1.Balance}.");
        // expected output: $150
    }
}
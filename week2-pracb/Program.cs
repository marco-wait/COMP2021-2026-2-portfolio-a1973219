using System.Data.SqlTypes;

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

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new("Bob", 100);
        Console.WriteLine($"This account belongs to {account1.Owner}.");
        Console.WriteLine($"This account contains ${account1.Balance}.");

        account1.Deposit(50);
        Console.WriteLine($"After depositing $50, this account now contains ${account1.Balance}.");

        account1.Withdraw(25);
        Console.WriteLine($"After withdrawing $25, this account now contains ${account1.Balance}.");
    }
}
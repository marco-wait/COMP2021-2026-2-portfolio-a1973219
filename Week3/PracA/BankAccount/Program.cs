using System.Runtime.InteropServices.Swift;

public abstract class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }
    public BankAccount(string owner, decimal balance) // constructor
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
        if (Balance < amount)
        {
            throw new ArgumentException("Account balance too low.");
        }
        Balance -= amount;
    }
}

public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; } // should be input as a percentage
    public SavingsAccount(string owner, decimal balance, decimal interest_rate) : base(owner, balance)
    {
        InterestRate = interest_rate;
    }

    public void ApplyInterest()
    {
        Balance *= InterestRate / 100 + 1; // converts interest rate value into a useful form, then multiplies account balance
    }
}

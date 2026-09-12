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
        if (Balance < amount)
        {
            throw new ArgumentException("Account balance too low.");
        }
        Balance -= amount;
    }
}
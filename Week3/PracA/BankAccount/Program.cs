public class BankAccount
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

    public virtual void Withdraw(decimal amount)
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
    public decimal InterestRate { get; set; } // represents the interest rate as a percentage
    public SavingsAccount(string owner, decimal balance, decimal interest_rate) : base(owner, balance)
    {
        InterestRate = interest_rate;
    }

    public void ApplyInterest()
    {
        Balance *= InterestRate / 100 + 1; // converts interest rate value into a useful form, then multiplies account balance
    }
}

public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }
    public CheckingAccount(string owner, decimal balance, decimal transaction_fee) : base(owner, balance)
    {
        TransactionFee = transaction_fee;
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount + TransactionFee);
    }
}

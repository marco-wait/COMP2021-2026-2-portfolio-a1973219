namespace BankComparer
{
    public class BankAccount(string owner, decimal balance)
    {
        public string Owner { get; set; } = owner;
        public decimal Balance { get; set; } = balance;

        public decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must not be negative.");
            }
            return Balance += amount;
        }

        public decimal Deposit(int amount)
        {
            return Deposit((decimal)amount);
        }

        public decimal Deposit(double amount)
        {
            return Deposit((decimal)amount);
        }

        public virtual decimal Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must not be negative.");
            }
            if (Balance < amount)
            {
                throw new ArgumentException("Balance is less than amount");
            }
            return Balance -= amount;
        }

        public override string ToString()
        {
            string info = $"""
            Account: {nameof(BankAccount)}
            Owner: {Owner}
            Balance: {Balance:F2}
            """;
            return info;
        }
    }

    public class BankComparer : IComparer<BankAccount>
    {
        public int Compare(BankAccount x, BankAccount y)
        {
            if (x.Balance == y.Balance)
            {
                return string.Compare(x.Owner, y.Owner);
            }

            return decimal.Compare(x.Balance, y.Balance);
        }
    }

    class Program
    {
        public static void DisplayAccounts(SortedSet<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        static void Main(string[] args)
        {
            BankAccount account1 = new("Alice", 40);
            BankAccount account2 = new("Bob", 93);
            BankAccount account3 = new("Charlie", 30);
            BankAccount account4 = new("David", 56);
            BankAccount account5 = new("Elise", 14);
            BankAccount account6 = new("Fred", 28);
            BankAccount account7 = new("Greg", 15);
            BankAccount account8 = new("Helen", 29);
            BankAccount account9 = new("Imogen", 100);
            BankAccount account10 = new("John", 54);

            var sortedBankSet = new SortedSet<BankAccount>(new BankComparer()) {account1, account2, account3, account4, account5, account6, account7, account8, account9, account10};
            DisplayAccounts(sortedBankSet);
            sortedBankSet.Add(new BankAccount("Mr. Monopoly", 999999999));
            DisplayAccounts(sortedBankSet);
            sortedBankSet.Add(new BankAccount("Alice", 40));
            DisplayAccounts(sortedBankSet);
        }
    }
}
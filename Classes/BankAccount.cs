namespace Classes;

public class BankAccount
{
    // Properties

    private static int s_accountNumberSeed = 123456789;
    public string Number { get; }
    public string Owner { get; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            // Adds or removes from balance depending on value it gets
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    // Constructor
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        // Initial balance when creating the account
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }
    
    // Initialises the List of transactions
    private readonly List<Transaction> _allTransactions = new List<Transaction>();

    // Methods
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        // Error catching
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
        }

        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        // StringBuilder makes multiple lines of code
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}
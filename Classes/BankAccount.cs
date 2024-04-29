namespace Classes;

public class BankAccount
{
    // Properties

    private static int _sAccountNumberSeed = 123456789;
    public string Number { get; }
    public string? Owner { get; }

    public decimal Balance
    {
        get
        {
            // Adds or removes from balance depending on value it gets
            return _allTransactions.Sum(item => item.Amount);
        }
    }

    // Constructor
    public BankAccount(string? name, decimal initialBalance)
    {
        Owner = name;
        Number = _sAccountNumberSeed.ToString();
        _sAccountNumberSeed++;
        // Initial balance when creating the account
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }
    
    // Initialises the List of transactions
    private readonly List<Transaction> _allTransactions = [];

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

    public static BankAccount NewAccount()
    {
        string? owner;
        do
        { 
            Console.WriteLine("Enter name:");
            owner = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(owner))
            { 
                Console.WriteLine("Name cannot be empty. Enter a valid name.");
                
            }
        } while (string.IsNullOrWhiteSpace(owner));
        
        Console.WriteLine("Deposit initial balance:");
        decimal initialBalance;
        while (!decimal.TryParse(Console.ReadLine(), out initialBalance) || initialBalance <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid amount.");
        }

        Console.WriteLine($"Account {_sAccountNumberSeed} was created for {owner} with {initialBalance} initial balance");
        return new BankAccount(owner, initialBalance);
    }
    public string GetAccountHistory()
    {
        // StringBuilder makes multiple lines of code
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        Console.WriteLine($"History for account number {_sAccountNumberSeed}");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}
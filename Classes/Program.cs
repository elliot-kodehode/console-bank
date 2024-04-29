using Classes;

var account = new BankAccount("<name>", 1000);

BankAccount.NewAccount();

// Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");
//
// account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
// Console.WriteLine($"Current balance: {account.Balance}");
//
// account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
// Console.WriteLine($"Current balance: {account.Balance}");
//
// Console.WriteLine(account.GetAccountHistory());

// Testing

// BankAccount invalidAccount;
// try
// {
//     invalidAccount = new BankAccount("invalid", -55);
// }
// catch (ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
//     return;
// }
//
// try
// {
//     account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
// }
// catch (InvalidOperationException e)
// {
//     Console.WriteLine("Exception caught trying to overdraw");
//     Console.WriteLine(e.ToString());
// }


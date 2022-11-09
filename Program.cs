using MiniBank.Core;

var account = new BankAccount("Aymen", 10_000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} dinars");

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
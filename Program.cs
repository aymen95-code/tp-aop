using MiniBank.Core;

Console.Write("username: ");
var username = Console.ReadLine() ?? string.Empty;
Console.Write("password: ");
var password = Console.ReadLine() ?? string.Empty;

var user = new AccountOwner {Name = username, Password = password};

var account = new BankAccount(user, 10_000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner.Name} with {account.Balance} dinars");

account.MakeWithdrawal(500, DateTime.Now, "Rent payment", "test123");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back", "this is a random password");
Console.WriteLine(account.Balance);

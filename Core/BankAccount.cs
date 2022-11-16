using MiniBank.Aspects;

namespace MiniBank.Core;

public class BankAccount
{
    public string Number { get; }
    public AccountOwner Owner { get; set; }
    public decimal Balance
    {
        get

        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }


    }
    private List<Transaction> allTransactions = new List<Transaction>();

    [SecurityAspect]
    public BankAccount(AccountOwner owner, decimal initialBalance)
    {
        this.Owner = owner;
        this.Number = Guid.NewGuid().ToString();
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance", owner.Password);
    }

    [LogAspect]
    public void MakeDeposit(decimal amount, DateTime date, string note, string password)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);

        Thread.Sleep(5000);
    }

    [LogAspect]
    public void MakeWithdrawal(decimal amount, DateTime date, string note, string password)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);

        Thread.Sleep(4360);
    }
}
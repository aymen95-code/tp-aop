namespace MiniBank.Core;

public class AccountOwner
{
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;

    public override string ToString() => $"Name: {Name}, Password: {Password}";
}

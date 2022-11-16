using System.ComponentModel.DataAnnotations;
using AspectInjector.Broker;
using MiniBank.Core;

namespace MiniBank.Aspects;


[Aspect(Scope.Global)]
[Injection(typeof(SecurityAspect))]
public class SecurityAspect : Attribute
{
    private static readonly List<AccountOwner> Credentials = new()
    {
        new() { Name = "Aymen",     Password = "test123" },
        new() { Name = "Yacine",    Password = "123456" }
    };

    [Advice(Kind.Before, Targets = Target.Constructor)]
    public void Authorize([Argument(Source.Arguments)] object[] args)
    {
        var owner = (AccountOwner)args.First();

        AccountOwner? accountExist = Credentials
            .FirstOrDefault(a => a.Name.Equals(owner.Name) && a.Password.Equals(owner.Password));

        if (accountExist is null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong credentials");
            Console.ResetColor();
            Environment.Exit(1);
        }
    }
}

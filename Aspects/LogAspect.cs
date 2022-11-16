using System.Diagnostics;
using AspectInjector.Broker;

namespace MiniBank.Aspects;

[Aspect(Scope.Global)]
[Injection(typeof(LogAspect))]
public class LogAspect : Attribute
{
    [Advice(Kind.Before, Targets = Target.Method)]
    public void LogEnter([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Entering method {name} ...");
        Console.ResetColor();
    }

    [Advice(Kind.After, Targets = Target.Method)]
    public void LogExit([Argument(Source.Name)] string name)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Leaving method {name} ...");
        Console.ResetColor();
    }

    [Advice(Kind.Around, Targets = Target.Method)]
    public object LogDuration([Argument(Source.Type)] Type type,
        [Argument(Source.Name)] string name,
        [Argument(Source.Target)] Func<object[], object> target,
        [Argument(Source.Arguments)] object[] arguments)
    {
        var sw = new Stopwatch();
        sw.Start();
        var result = target(arguments);
        sw.Stop();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[{DateTime.UtcNow}] Method {type.Name}.{name} took {sw.ElapsedMilliseconds} ms");
        Console.ResetColor();
        
        return result;
    }
}

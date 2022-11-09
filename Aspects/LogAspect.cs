using AspectInjector.Broker;

namespace MiniBank.Aspects;

[Aspect(Scope.Global)]
[Injection(typeof(LogAspect))]
public class LogAspect : Attribute {

    [Advice(Kind.Before, Targets = Target.Method)]
    public void LogEnter([Argument(Source.Name)] string name) {
        Console.WriteLine($"Entering method {name} ...");
    }

    [Advice(Kind.After, Targets = Target.Method)]
    public void LogExit([Argument(Source.Name)] string name) {
        Console.WriteLine($"Leaving method {name} ...");
    }
}

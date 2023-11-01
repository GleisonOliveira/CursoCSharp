using Microsoft.Extensions.DependencyInjection;
using OOP.WriterContext;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services
            .AddSingleton<IWriterFactory, WriterFactory>()
            .AddSingleton<EntryPoint, EntryPoint>()
            .BuildServiceProvider()
            .GetService<EntryPoint>()
            !.Start(args);
    }
}
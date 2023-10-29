// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using OOP.WriterContext;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services
            .AddSingleton<IWriterFactory, WriterFactory>()
            .AddSingleton<EntryPoint, EntryPoint>()
            .BuildServiceProvider()
            .GetService<EntryPoint>()
            ?.Start(args);
    }
}
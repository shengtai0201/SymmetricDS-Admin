using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SymmetricDS.Admin.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            Console.WriteLine($"Hello World! { configuration["name"] }");
            Console.ReadKey();
        }
    }
}

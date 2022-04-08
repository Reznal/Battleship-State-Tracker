using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Battleship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            Console.WriteLine("-------------------------ASDWFASD-----------------");

            Console.WriteLine("-------------------------ASDWFASD-----------------");

            Console.WriteLine("-------------------------ASDWFASD-----------------");

            Console.WriteLine("-------------------------ASDWFASD-----------------");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FTP.CodeChallenge
{
    public class Program
    {

        private readonly IWeatherStackService _weatherStackService;
        public Program(IWeatherStackService weatherStackService) 
        {
            _weatherStackService = weatherStackService;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public async void Run()
        {
            Console.Write("Please Enter ZipCode (UK/Canada/US): ");
            string zipCode = Console.ReadLine(); //99501
            var result = await _weatherStackService.RespondFromCurrentForecast(zipCode);
            Console.WriteLine("Should I go outside? " + (result.GoOutside ? "Yes" : "No"));
            Console.WriteLine("Should I wear sunscreen? " + (result.WearSunscreen ? "Yes" : "No"));
            Console.WriteLine("Can I fly my kite? " + (result.FlyKite ? "Yes" : "No"));
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IWeatherStackService, WeatherStackService>();
                });
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using ProjectSpace.Core.ConfigurationManagement;
using ProjectSpace.Core.Providers.ConfigurationManagement;
using ProjectSpace.Entities;
using ProjectSpace.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjectSpace.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            

            AppContainer.Setup((container) =>
            {
                container.Register<IConfigReader>(() => new DefaultConfigReader(configBuilder.Build()) , SimpleInjector.Lifestyle.Singleton);
            });

            Task.Run(async () =>
            {
                using (ExecutionContext context = ExecutionContext.New())
                {
                    IEmployeeService service = context.Get<IEmployeeService>();
                    IConfigReader config = context.Get<IConfigReader>();

                    Console.WriteLine("Hello World!");
                }
            }).Wait();

        }
    }
}

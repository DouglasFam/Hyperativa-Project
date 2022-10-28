using Hyperativa.Data.Vault;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {

                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables(prefix: "VAULT_");

                    var builtConfig = config.Build();

                    if (builtConfig.GetSection("Vault")["Role"] != null)
                    {
                        config.AddVault(options =>
                        {
                            var vaultOptions = builtConfig.GetSection("Vault");
                            options.Address = vaultOptions["Address"];
                            options.Role = vaultOptions["Role"];
                            options.MountPath = vaultOptions["MountPath"];
                            options.SecretType = vaultOptions["SecretType"];
                            options.Secret = vaultOptions["secret"];
                        });
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

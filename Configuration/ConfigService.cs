using Microsoft.Extensions.Configuration;

namespace SuperAutoMachines.Configuration
{
    public class ConfigService
    {
        public static IConfiguration Configuration;

        static ConfigService()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
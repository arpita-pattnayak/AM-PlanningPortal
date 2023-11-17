using AM.PP.JobManager.AzFn.Configuration;
using AM.PP.JobManager.AzFn.Db;
using AM.PP.JobManager.AzFn.Interface;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AM.PP.JobManager.AzFn
{
    internal class Startup : FunctionsStartup
    {
        //public IConfiguration Configuration { get; }
        private readonly ISettings _settings;

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _settings = new Settings(Configuration);
        //}

        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration config = builder.GetContext().Configuration;
            ISettings _settings = new Settings(config);
#pragma warning disable CA2000 // Dispose objects before losing scope
            ILoggerFactory loggerFactory = new LoggerFactory();
#pragma warning restore CA2000 // Dispose objects before losing scope
            builder.Services.AddSingleton(loggerFactory);
            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            builder.Services.AddSingleton<ISettings, Settings>();
            string hst = _settings.PostgreConfig.GetValue<string>("Host");
            //string connString =
            //   String.Format(
            //       "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
            //       _settings.PostgreConfig.GetValue<string>("Host)",
            //       User,
            //       DBname,
            //       Port,
            //       Password);
            string connectionString = "Server=pmrpostgredbdev.postgres.database.azure.com;Database=pmrdbdev;Port=5432;User Id=sqladmin;Password=pmrdev@2023;";
            builder.Services.AddDbContext<PPDbContext>(options =>
            {
                options.UseNpgsql(connectionString); // Replace with your PostgreSQL connection string
            });
        }
    }
}

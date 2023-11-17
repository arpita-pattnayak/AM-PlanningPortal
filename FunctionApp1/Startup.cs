using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration config = builder.GetContext().Configuration;

            //string connectionString = "Your_PostgreSQL_Connection_String";
            //builder.Services.AddDbContext<PPDbContext>(options =>
            //    options.UseNpgsql(connectionString));

            //// Add logging
            //builder.Services.AddLogging(loggingBuilder =>
            //{
            //    loggingBuilder.AddConsole();
            //});
#pragma warning disable CA2000 // Dispose objects before losing scope
            ILoggerFactory loggerFactory = new LoggerFactory();
#pragma warning restore CA2000 // Dispose objects before losing scope
            builder.Services.AddSingleton(loggerFactory);
            builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        }
    }
}

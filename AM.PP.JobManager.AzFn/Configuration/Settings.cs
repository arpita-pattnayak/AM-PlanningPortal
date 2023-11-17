using AM.PP.JobManager.AzFn.Interface;
using Microsoft.Extensions.Configuration;

namespace AM.PP.JobManager.AzFn.Configuration
{
    public class Settings : ISettings
    {
        private readonly IConfiguration _configuration;
        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IConfiguration PostgreConfig => _configuration.GetSection("Postgre");
    }
}

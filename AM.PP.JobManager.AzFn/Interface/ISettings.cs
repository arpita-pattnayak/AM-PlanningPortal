using Microsoft.Extensions.Configuration;

namespace AM.PP.JobManager.AzFn.Interface
{
    public interface ISettings
    {
        public IConfiguration PostgreConfig { get; }
    }
}

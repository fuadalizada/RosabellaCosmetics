using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace RosabellaCosmetics.WebApi.Utils
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}

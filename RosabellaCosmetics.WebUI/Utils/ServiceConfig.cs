using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RosabellaCosmetics.Business;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Business.FluentValidations;
using RosabellaCosmetics.Business.Services.Abstract;
using RosabellaCosmetics.Business.Services.Concrete;
using RosabellaCosmetics.Dal.DbContext;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Dal.Repositories.Concrete;

namespace RosabellaCosmetics.WebUI.Utils
{
    public class ServiceConfig : IInstaller
    {//.AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RosabellaCosmeticsDbContext>(option => {
                option.UseSqlServer(configuration.GetConnectionString("RosabellaCosmetics"));
            });
            services.AddMvcCore().AddRazorViewEngine();
            services.AddAuthorization();
            DependencyInjectionRepositories(services);
            DependencyInjectionServices(services);
            DependencyInjectionValidators(services);
            DependencyInjectionMappers(services);
        }

        private void DependencyInjectionRepositories(IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        private void DependencyInjectionServices(IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICustomerService, CustomerService>();
        }

        private void DependencyInjectionValidators(IServiceCollection service)
        {
            service.AddScoped<AbstractValidator<ProductDto>, ProductValidator>();
            service.AddScoped<AbstractValidator<CustomerDto>, CustomerValidator>();
        }

        private void DependencyInjectionMappers(IServiceCollection service)
        {
            var mapConfig = new MapperConfiguration(config => { config.AddProfile(new MapperConfig()); });
            IMapper mapper = mapConfig.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}

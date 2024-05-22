using IKnowCoding.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using AutoMapper;
using API.Application.Helpers;

namespace SystemTests.IntegrationTests
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveLibraryDbContextRegistration(services);

                var serviceProvider = GetInMemoryServiceProvider();

                services.AddDbContextPool<PlatformContext>(options =>
                {
                    //options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddSingleton(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutomapperProfile());
                }).CreateMapper());

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PlatformContext>();
                }
            });
        }

        private static ServiceProvider GetInMemoryServiceProvider()
        {
            return new ServiceCollection()
                .BuildServiceProvider();
        }

        private static void RemoveLibraryDbContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<PlatformContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}

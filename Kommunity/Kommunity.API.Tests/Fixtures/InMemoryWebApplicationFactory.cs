using Kommunity.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kommunity.API.Tests.Fixtures
{

    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services =>
                   {
                       //Teste özel konfigürasyonlar burada yapılabilir.
                       //Örneğin, Dapper entegrasyonu, Mock servisler, InMemory veritabanı vb.
                       var options = new DbContextOptionsBuilder<SpeakersDbContext>()
                           .UseInMemoryDatabase(databaseName: "testInMemory").Options;

                       services.AddDbContext<SpeakersDbContext>(provider=> new TestSpeakerDbContext(options));

                       var serviceProvider = services.BuildServiceProvider();
                       using var scope = serviceProvider.CreateScope();
                        var dbInMemory = scope.ServiceProvider.GetRequiredService<SpeakersDbContext>();
                       dbInMemory.Database.EnsureCreated();

                   });


        }
    }
}

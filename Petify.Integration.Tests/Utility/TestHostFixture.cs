using System;
using System.Net.Http;
using Petify.Api;
using Petify.Infrastructure.DataModel.Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Petify.Integration.Tests.Utility
{
    [Collection("Sequential")]
    public abstract class TestHostFixture : IClassFixture<CustomWebApplicationFactory<TestStartup, Startup>>
    {
        private readonly CustomWebApplicationFactory<TestStartup, Startup> _factory;
        protected readonly HttpClient Client;

        protected TestHostFixture()
        {
            _factory = new CustomWebApplicationFactory<TestStartup, Startup>();
            Client = _factory.CreateClient();
        }

        protected void GetContext(Action<PetifyContext> test)
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PetifyContext>();
                test(context);
            }
        }
    }
}

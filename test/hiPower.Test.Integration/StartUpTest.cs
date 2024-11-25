using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace hiPower.Test.Integration
{
    public class StartUpTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly ITestOutputHelper outputHelper;

        private readonly List<Type> controllerList = typeof(Program).Assembly
                                                                    .GetTypes()
                                                                    .Where(x => x.IsSubclassOf(typeof(ControllerBase)))
                                                                    .ToList();

        public StartUpTest(WebApplicationFactory<Program> factory,
                           ITestOutputHelper outputHelper)
        {
            this.factory = factory;
            this.outputHelper = outputHelper;

            this.factory = factory.WithWebHostBuilder (builder =>
            {
                builder.ConfigureServices (services =>
                {
                    controllerList.ForEach(controller => services.AddScoped(controller));
                });
            });
        }


        [Fact]
        public void ConfigureServices_ForControllers_RegisterAllDependences ()
        {
            // Arrange
            var scopeFactory = factory.Services.GetService<IServiceScopeFactory> ();
            using var scope = scopeFactory?.CreateScope();

            // Act

            // Assert
            controllerList.ForEach (item =>
            {
                if (scope is not null)
                {
                    var controller = scope.ServiceProvider.GetService(item);
                    controller.Should ().NotBeNull ();
                    outputHelper.WriteLine ($"Controller {controller?.GetType ().Name} created.");
                }
            });
        }
    }
}

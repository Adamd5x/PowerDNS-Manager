using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace hiPower.Test.Integration
{
    public class ConfigControllerTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly ITestOutputHelper outputHelper;

        public ConfigControllerTest(WebApplicationFactory<Program> factory,
                                    ITestOutputHelper helper)
        {
            this.factory = factory;
            this.outputHelper = helper;
        }

        [Fact]
        public async Task  GetConfig_RetunsOkResult()
        {
            // Arrange
            string testEndpoint = "api/config";
            HttpClient client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(testEndpoint);
            outputHelper.WriteLine ($"Testing endpoint url: {testEndpoint}");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}

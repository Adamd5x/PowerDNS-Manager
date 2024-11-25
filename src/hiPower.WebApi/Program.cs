using hiPower.Database.Extensions.DependencyInjection;
using hiPower.WebApi.Extensions.DependencyInjection;
using hiPower.Core.Extensions.DependencyInjection;
using hiPower.Infrastructure.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureWebHostServices (builder.Configuration)
                .ConfigureDbRepository (builder.Configuration)
                .ConfigureCoreServices ()
                .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.Services.UseManagerSeederAsync ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ())
{
    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

await app.RunAsync ();

public partial class Program() { }
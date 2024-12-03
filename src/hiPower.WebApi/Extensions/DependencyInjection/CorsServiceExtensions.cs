namespace hiPower.WebApi.Extensions.DependencyInjection
{
    public static class CorsServiceExtensions
    {
        private const string CorsPolicyName = "OpenPolicy";

        public static IServiceCollection AddCorsConfiguration (this IServiceCollection services)
        {
            services.AddCors (setup => {
                setup.AddPolicy (CorsPolicyName, builder => {
                    builder.AllowAnyOrigin ();
                    builder.AllowAnyHeader ();
                    builder.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCorsServices (this IApplicationBuilder app)
        {
            app.UseCors (CorsPolicyName);
            return app;
        }
    }
}

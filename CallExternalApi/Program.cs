using CallExternalApi.Clients.FileStore;
using CallExternalApi.Clients.Handlers;
using CallExternalApi.Clients.SurveyBasket;
using CallExternalApi.Clients.SurveyBasket.Services;
using Refit;

namespace CallExternalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();
            builder.Services.AddTransient<AuthHeadderHandler>();

            builder.Services
                   .AddRefitClient<ISurveyBasketClient>()
                   .ConfigureHttpClient(i =>
                   {
                       i.BaseAddress = new Uri(builder.Configuration.GetValue<string>("SurveyBasket:BaseUrl")!);
                   })
                   .AddHttpMessageHandler<AuthHeadderHandler>();
        
            builder.Services
                 .AddRefitClient<IFileStore>()
                 .ConfigureHttpClient(i =>
                 {
                     i.BaseAddress = new Uri(builder.Configuration.GetValue<string>("FileStore:BaseUrl")!);
                 });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}

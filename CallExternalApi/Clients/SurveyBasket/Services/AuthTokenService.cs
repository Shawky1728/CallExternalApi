using CallExternalApi.Clients.SurveyBasket.Contracts;
using System.Text.Json;

namespace CallExternalApi.Clients.SurveyBasket.Services
{
    public class AuthTokenService: IAuthTokenService
    {
        private readonly IConfiguration _configuration;

        public AuthTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<AuthResponse> GetTokenAsync ()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("SurveyBasket:BaseUrl")!)
            };

            var responseMessage = await client.PostAsJsonAsync("/api/auth", new
            {
                email = "admin@gmail.com",
                password = "Aa3451397#"
            });

           return await responseMessage.Content.ReadFromJsonAsync<AuthResponse>() 
                ?? throw new Exception("Failed to get auth token");
        }
    }
}

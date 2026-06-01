using CallExternalApi.Clients.SurveyBasket.Contracts;

namespace CallExternalApi.Clients.SurveyBasket.Services
{
    public interface IAuthTokenService
    {
        Task<AuthResponse> GetTokenAsync();
    }
}

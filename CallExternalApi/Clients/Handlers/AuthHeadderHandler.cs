using CallExternalApi.Clients.SurveyBasket.Services;
using System.Net.Http.Headers;

namespace CallExternalApi.Clients.Handlers
{
    public class AuthHeadderHandler : DelegatingHandler
    {
        private readonly IAuthTokenService _authTokenService;

        public AuthHeadderHandler(IAuthTokenService authTokenService)
        {
            _authTokenService = authTokenService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _authTokenService.GetTokenAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

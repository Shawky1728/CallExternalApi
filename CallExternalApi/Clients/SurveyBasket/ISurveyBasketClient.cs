using CallExternalApi.Clients.SurveyBasket.Contracts;
using Refit;

namespace CallExternalApi.Clients.SurveyBasket
{
    
    public interface ISurveyBasketClient
    {
        [Get("/api/polls")]
        Task<IEnumerable<PollResponse>> GetPolls();

        [Get("/api/polls/{id}")]
        Task<ApiResponse<PollResponse>> GetPollById(int id);

        [Get("/api/roles")]
        Task<object> GetRoles([AliasAs("includeDisabled")] bool all);

        [Get("/api/polls/{pollId}/Questions")]
        Task<object> GetQuestions( int pollId, [Query] RequestFilters requestFilters);

        [Post("/api/auth")]
        Task<AuthResponse> GetToken([Body] LoginRequest loginRequest);

        [Put("/api/polls/{pollId}")]
        Task UpdatePollAsync(int pollId, [Body] PollRequest updatePollRequest);

        [Delete("/api/polls/{pollId}")]
        Task DeletePollAsync(int pollId);
    }
}

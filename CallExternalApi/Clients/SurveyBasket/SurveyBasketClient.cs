//using CallExternalApi.Clients.SurveyBasket.Contracts;

//namespace CallExternalApi.Clients.SurveyBasket
//{
//    public class SurveyBasketClient : ISurveyBasketClient
//    {
//        private readonly IHttpClientFactory httpClientFactory;

//        public SurveyBasketClient(IHttpClientFactory httpClientFactory)
//        {
//            this.httpClientFactory = httpClientFactory;
//        }
//        public async Task<IEnumerable<PollResponse>> GetPolls()
//        {
//            var httpClient = httpClientFactory.CreateClient("SurveyBasket");
//            var polls = await httpClient.GetFromJsonAsync<IEnumerable<PollResponse>>("/api/polls");
//            return polls ?? [];
//        }
//    }
//}

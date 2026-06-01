using CallExternalApi.Clients.SurveyBasket;
using CallExternalApi.Clients.SurveyBasket.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallExternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyBasketController : ControllerBase
    {
        private readonly ISurveyBasketClient surveyBasketClient;

        public SurveyBasketController(ISurveyBasketClient surveyBasketClient)
        {
            this.surveyBasketClient = surveyBasketClient;
        }
        [HttpGet("polls")]
        public async Task<IActionResult> GetPolls()
        {
            var polls = await surveyBasketClient.GetPolls();
            return Ok(polls);

        }

        [HttpGet("polls/{id}")]
        public async Task<IActionResult> GetPollById([FromRoute] int id)
        {
            var response = await surveyBasketClient.GetPollById(id);
            if(!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, response.Error.Content);
            }
            return Ok(response.Content);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles([FromQuery] bool all)
        {
            var roles = await surveyBasketClient.GetRoles(all);
            return Ok(roles);
        }

        [HttpGet("polls/{pollId}/questions")]
        public async Task<IActionResult> GetQuestions([FromRoute] int pollId, [FromQuery] RequestFilters filters)
        {
            var questions = await surveyBasketClient.GetQuestions(pollId, filters);
            return Ok(questions);

        }

        [HttpPost("auth")]
        public async Task<IActionResult> GetToken([FromBody] LoginRequest loginRequest)
        {
            var authResponse = await surveyBasketClient.GetToken(loginRequest);
            return Ok(authResponse);
        }

        [HttpPut("polls/{pollId}")]
        public async Task<IActionResult> UpdatePoll([FromRoute] int pollId, [FromBody] PollRequest updatePollRequest)
        {
            await surveyBasketClient.UpdatePollAsync(pollId, updatePollRequest);
            return NoContent();
        }

        [HttpDelete("polls/{pollId}")]
        public async Task<IActionResult> DeletePoll([FromRoute] int pollId)
        {
            await surveyBasketClient.DeletePollAsync(pollId);
            return NoContent();
        }
    }
}

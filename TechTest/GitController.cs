namespace TechTest
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/v1")]
    public class GitController : ControllerBase
    {
        private readonly IMediator mediator;

        public GitController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{owner}/{repo}/contributors")]
        public async Task<IActionResult> GetContributors(string owner, string repo)
        {

            var response = await mediator.Send(new ContributorRequest { Owner = owner, Repo = repo });
            return string.IsNullOrWhiteSpace(response.Exception) 
                ? this.Ok(response) 
                : this.StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}

namespace TechTest
{
    using System.Text.RegularExpressions;
    using MediatR;
    using Octokit;

    internal class ContributorRequestHandler : IRequestHandler<ContributorRequest, ContributorResponse>
    {
        public async Task<ContributorResponse> Handle(ContributorRequest request, CancellationToken cancellationToken)
        {
            // TODO: validation
            // TODO: OAuth

            ContributorResponse result;
            var client = new GitHubClient(new ProductHeaderValue("e-bx-tech-test"));
            try
            {
                var allCommits = await client.Repository.Commit.GetAll(request.Owner, request.Repo);
                result = new ContributorResponse
                {
                    Commits = allCommits
                    .OrderByDescending(c => c.Commit.Author.Date)
                    .Take(30)
                    .Select(c => new CommitInformation
                    {
                        Contributor = c.Commit.Author.Name,
                        CommittedAt = c.Commit.Author.Date,
                        Message = c.Commit.Message
                    })
                };
            }
            catch (RateLimitExceededException rleEx)
            {
                result = new ContributorResponse
                {
                    Commits = Enumerable.Empty<CommitInformation>(),
                    Exception = rleEx.Message
                };
            }

            return result;
        }
    }
}

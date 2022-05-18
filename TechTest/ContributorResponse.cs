namespace TechTest
{
    internal class ContributorResponse
    {
        public IEnumerable<CommitInformation> Commits { get; init; } = Enumerable.Empty<CommitInformation>();

        public string? Exception { get; init; }
    }
}

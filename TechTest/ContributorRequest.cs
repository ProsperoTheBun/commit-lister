namespace TechTest
{
    using MediatR;

    internal class ContributorRequest : IRequest<ContributorResponse>
    {
        public string Owner { get; set; } = string.Empty;
        public string Repo { get; set; } = string.Empty;
    }
}

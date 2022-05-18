namespace TechTest
{
    internal class CommitInformation
    {
        public string Contributor { get; set; } = string.Empty;
        public DateTimeOffset CommittedAt { get; set; }
        public string Message { get; set; } = string.Empty;

    }
}

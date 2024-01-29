using SpreaGit.Domain;

namespace SpreaGit.Application;

public interface ICommitDateSpreader
{
    IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, SpreaGitConfiguration configuration);
}
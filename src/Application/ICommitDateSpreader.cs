using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Application;

public interface ICommitDateSpreader
{
    IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, SpreaGitConfiguration configuration);
}
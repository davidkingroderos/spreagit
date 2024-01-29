using SpreaGit.Domain.Models;

namespace SpreaGit.Application.Interfaces;

public interface ICommitDateSpreader
{
    IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, SpreaGitConfiguration configuration);
}
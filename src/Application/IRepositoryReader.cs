using SpreaGit.Domain;

namespace SpreaGit.Application;

public interface IRepositoryReader
{
    IEnumerable<GitLog> GetGitCommits(string repositoryPath);
    void CheckoutCommit(string repositoryPath, string commitHash);
}
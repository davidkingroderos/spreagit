using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Application;

public interface IRepositoryReader
{
    IEnumerable<GitLog> GetGitCommits(string repositoryPath);
    void CheckoutCommit(string repositoryPath, string commitHash);
}
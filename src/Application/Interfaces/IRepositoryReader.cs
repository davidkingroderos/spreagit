using SpreaGit.Domain.Models;

namespace SpreaGit.Application.Interfaces;

public interface IRepositoryReader
{
    IEnumerable<GitLog> GetGitCommits(string repositoryPath);
    void CheckoutCommit(string repositoryPath, string commitHash);
}
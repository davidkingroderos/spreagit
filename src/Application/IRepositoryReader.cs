using dk.roderos.SpreaGit.Domain;
using LibGit2Sharp;

namespace dk.roderos.SpreaGit.Application;

public interface IRepositoryReader
{
    IEnumerable<GitLog> GetGitCommits(string repositoryPath);
}

using System.Globalization;
using LibGit2Sharp;
using SpreaGit.Application;
using SpreaGit.Domain;

namespace SpreaGit.Infrastructure;

public class RepositoryReader : IRepositoryReader
{
    public void CheckoutCommit(string repositoryPath, string commitHash)
    {
        using var repository = new Repository(repositoryPath);

        Commands.Checkout(repository, commitHash);
    }

    public IEnumerable<GitLog> GetGitCommits(string repositoryPath)
    {
        using var repository = new Repository(repositoryPath);

        const string rfc2822Format = "ddd dd MMM HH:mm:ss yyyy K";

        return (from commit in repository.Commits
                let id = commit.Sha
                let author = commit.Author.Name
                let email = commit.Author.Email
                let date = commit.Author.When.ToString(rfc2822Format, CultureInfo.InvariantCulture)
                let message = commit.Message
                select new GitLog(id, author, email, date, message))
            .ToList();
    }
}
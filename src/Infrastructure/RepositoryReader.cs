using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using LibGit2Sharp;
using System.Globalization;

namespace dk.roderos.SpreaGit.Infrastructure;

public class RepositoryReader : IRepositoryReader
{
    public IEnumerable<GitLog> GetGitCommits(string repositoryPath) {
        using var repository = new Repository(repositoryPath);

        var RFC2822Format = "ddd dd MMM HH:mm:ss yyyy K";
        var commits = new List<GitLog>();

        foreach (var commit in repository.Commits)
        {
            var id = commit.Sha;
            var author = commit.Author.Name;
            var email = commit.Author.Email;
            var date = commit.Author.When.ToString(RFC2822Format, CultureInfo.InvariantCulture);
            var message = commit.Message;

            commits.Add(new(id, author, email, date, message));
        }

        return commits;
    }
}
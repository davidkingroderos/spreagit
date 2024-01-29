using SpreaGit.Application.Interfaces;
using SpreaGit.Domain.Models;

namespace SpreaGit.Infrastructure.Readers;

public class TextConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration)
    {
        await using var configurationFile = File.OpenRead(configuration);

        return new SpreaGitConfiguration("foo", "foo", DateTime.Now, DateTime.Now, false);
    }
}
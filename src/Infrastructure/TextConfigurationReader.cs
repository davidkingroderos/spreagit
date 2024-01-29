using SpreaGit.Application;
using SpreaGit.Domain;

namespace SpreaGit.Infrastructure;

public class TextConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration)
    {
        await using var configurationFile = File.OpenRead(configuration);

        return new SpreaGitConfiguration("foo", "foo", DateTime.Now, DateTime.Now, false);
    }
}
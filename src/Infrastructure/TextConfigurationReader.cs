using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Infrastructure;

public class TextConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration)
    {
        await using var configurationFile = File.OpenRead(configuration);

        return new SpreaGitConfiguration("foo", "foo", "foo", "foo");
    }
}
using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using System.Text.Json;

namespace dk.roderos.SpreaGit.Infrastructure;

public class JsonConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration)
    {
        using var file = File.OpenRead(configuration);

        return await JsonSerializer.DeserializeAsync<SpreaGitConfiguration?>(file);
    }
}
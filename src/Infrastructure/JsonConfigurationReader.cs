using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using System.Text.Json;

namespace dk.roderos.SpreaGit.Infrastructure;

public class JsonConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration)
    {
        await using var configurationFile = File.OpenRead(configuration);

        var options = new JsonSerializerOptions
        {
            Converters = { new JsonDateTimeConverter() }
        };

        return await JsonSerializer.DeserializeAsync<SpreaGitConfiguration?>(configurationFile, options);
    }
}
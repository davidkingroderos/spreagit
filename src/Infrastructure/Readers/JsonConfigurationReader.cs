using System.Text.Json;
using SpreaGit.Application.Interfaces;
using SpreaGit.Domain.Common;
using SpreaGit.Domain.Models;

namespace SpreaGit.Infrastructure.Readers;

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
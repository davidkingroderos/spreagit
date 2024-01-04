using System.Security.Cryptography;
using System.Text.Json;
using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Infrastructure;

public class JsonConfigurationReader : IConfigurationReader
{
    public async Task<SpreaGitConfiguration> ReadConfigurationAsync(string configFile)
    {
        if (!File.Exists(configFile))
        {
            throw new FileNotFoundException($"{configFile} does not exist.");
        }

        using var file = File.OpenRead(configFile);

        // TODO: Read Json and Convert to SpreaGitConfiguration

        throw new NotImplementedException();
    }
}


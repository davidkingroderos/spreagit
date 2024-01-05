using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dk.roderos.SpreaGit.Application;

public class SpreaGitService(IConfiguration configuration, ILogger<SpreaGitService> logger, IConfigurationReader configurationReader) : ISpreaGitService
{
    private readonly IConfiguration configuration = configuration;
    private readonly ILogger<SpreaGitService> logger = logger;
    private readonly IConfigurationReader configurationReader = configurationReader;

    public async Task SpreaGitAsync()
    {
        var configFile = configuration.GetSection("config").Value;
        logger.LogInformation("Config File: {configFile}", configFile);

        if (string.IsNullOrEmpty(configFile))
        {
            logger.LogError("Must specify 'config' argument");

            return;
        }

        if (!File.Exists(configFile))
        {
            logger.LogError("File does not exists: {configFile}", configFile);

            return;
        }

        var spreaGitConfiguration = await configurationReader.ReadConfigurationAsync(configFile);

        logger.LogInformation("SpreaGit Configuration: {spreaGitConfiguration}", spreaGitConfiguration);
    }
}
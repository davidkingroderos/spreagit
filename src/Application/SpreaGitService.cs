using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dk.roderos.SpreaGit.Application;

public class SpreaGitService(IConfiguration configuration, ILogger<SpreaGitService> logger, 
    IConfigurationReader configurationReader, IRepositoryReader repositoryReader) : ISpreaGitService
{
    private readonly IConfiguration configuration = configuration;
    private readonly ILogger<SpreaGitService> logger = logger;
    private readonly IConfigurationReader configurationReader = configurationReader;
    private readonly IRepositoryReader repositoryReader = repositoryReader;

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

        var repositoryPath = spreaGitConfiguration!.RepositoryPath;

        if (!Directory.Exists(repositoryPath))
        {
            logger.LogError("Directory does not exists: {repositoryPath}", repositoryPath);

            return;
        }

        var commits = repositoryReader.GetGitCommits(repositoryPath);

        logger.LogInformation("Logs count: {commitsCount}", commits.Count());

        foreach (var commit in commits)
        {
            logger.LogInformation("Id: {id}", commit.Id);
        }

        var outputPath = spreaGitConfiguration!.OutputPath;

        logger.LogInformation("Output Path: {outputPath}", repositoryPath);

        var outputRepositoryName = new DirectoryInfo(repositoryPath).Name + " spreagit";
        var outputRepositoryPath = Path.Combine(outputPath, outputRepositoryName);

        var suffix = 1;
        while (Directory.Exists(outputRepositoryPath))
        {
            outputRepositoryPath = Path.Combine(outputPath, $"{outputRepositoryName} ({suffix})");
            suffix++;
        }

        Directory.CreateDirectory(outputRepositoryPath);
    }
}
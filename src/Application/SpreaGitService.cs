using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dk.roderos.SpreaGit.Application;

public class SpreaGitService(
    IConfiguration configuration,
    ILogger<SpreaGitService> logger,
    IConfigurationReader configurationReader,
    IRepositoryReader repositoryReader,
    IRepositoryWriter repositoryWriter,
    ICommitDateSpreader commitDateSpreader) : ISpreaGitService
{
    // TODO: Create configuration defaulter
    // TODO: Create configuration validator
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

        logger.LogInformation("Repository Path: {repositoryPath}", repositoryPath);

        if (!Directory.Exists(repositoryPath))
        {
            logger.LogError("Directory does not exists: {repositoryPath}", repositoryPath);

            return;
        }

        // We need to start at the initial commit so we should reverse the list
        var commits = repositoryReader.GetGitCommits(repositoryPath).Reverse().ToList();
        var startDate = spreaGitConfiguration.StartDate;
        var endDate = spreaGitConfiguration.EndDate;

        if (startDate > endDate)
        {
            logger.LogError("Start Date ({startDate}) should be earlier than End Date ({endDate})", 
                startDate, endDate);

            return;
        }
        
        // TODO: Spread out dates of commits
        // TODO: Fix where startDate and endDate are same dates
        // TODO: Fix date formatting on args
        var alteredCommits = commitDateSpreader.SpreadOutDateCommits(commits, startDate, 
            endDate).ToList();
        
        logger.LogInformation("Logs count: {alteredCommitsCount}", alteredCommits.Count);

        var outputPath = spreaGitConfiguration.OutputPath;

        logger.LogInformation("Output Path: {outputPath}", repositoryPath);

        if (!Directory.Exists(outputPath))
        {
            logger.LogError("Directory does not exists: {outputPath}", outputPath);

            return;
        }

        // We append "spreagit" to the repository name to avoid confusion
        var outputRepositoryName = new DirectoryInfo(repositoryPath).Name + " spreagit";
        var outputRepositoryPath = Path.Combine(outputPath, outputRepositoryName);

        logger.LogInformation("Output Repository Path: {outputPath}", repositoryPath);

        var suffix = 1;
        while (Directory.Exists(outputRepositoryPath))
        {
            outputRepositoryPath = Path.Combine(outputPath, $"{outputRepositoryName} ({suffix})");
            suffix++;
        }

        Directory.CreateDirectory(outputRepositoryPath);

        repositoryWriter.InitializeGit(outputRepositoryPath);

        foreach (var commit in alteredCommits)
        {
            // TODO: The repositoryWriter should be the one who is logging these information
            // TODO: Make it into one method in repositoryWriter
            logger.LogInformation("Deleting repository contents: {commitId}", commit.Id);
            repositoryWriter.DeleteRepositoryContents(outputRepositoryPath);
            logger.LogInformation("Checking out commit: {commitId}", commit.Id);
            repositoryReader.CheckoutCommit(repositoryPath, commit.Id);
            logger.LogInformation("Copying repository contents: {commitId}", commit.Id);
            repositoryWriter.CopyRepositoryContents(repositoryPath, outputRepositoryPath);
            logger.LogInformation("Committing: {commitId}", commit.Id);
            repositoryWriter.Commit(outputRepositoryPath, commit);
        }
    }
}
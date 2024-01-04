using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dk.roderos.SpreaGit.Application;

public class SpreaGitService(IConfiguration configuration, ILogger<SpreaGitService> logger) : ISpreaGitService
{
    private readonly IConfiguration configuration = configuration;
    private readonly ILogger<SpreaGitService> logger = logger;

    public async Task SpreaGitAsync()
    {
        var inputPath = configuration.GetSection("input").Value ?? "Null";
        var outputPath = configuration.GetSection("output").Value ?? "Null";
        var startDate = configuration.GetSection("start").Value ?? "Null";
        var endDate = configuration.GetSection("end").Value ?? "Null";

        var spreaGitConfiguration = new SpreaGitConfiguration(inputPath, outputPath, startDate, endDate);

        logger.LogInformation("SpreaGit Configuration: {spreaGitConfiguration}", spreaGitConfiguration);
    }
}
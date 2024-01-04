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
        var input = configuration.GetSection("input").Value ?? "Null";
        var output = configuration.GetSection("output").Value ?? "Null";
        var start = configuration.GetSection("start").Value ?? "Null";
        var end = configuration.GetSection("end").Value ?? "Null";

        var spreaGitConfiguration = new SpreaGitConfiguration(input, output, start, end);

        logger.LogInformation("SpreaGit Configuration: {spreaGitConfiguration}", spreaGitConfiguration);
    }
}

using dk.roderos.SpreaGit.Application;
using Microsoft.Extensions.Configuration;

namespace dk.roderos.SpreaGit.Infrastructure;

public class SpreaGitService(IConfiguration configuration) : ISpreaGitService
{
    private readonly IConfiguration configuration = configuration;

    public async Task SpreaGitAsync()
    {
        var input = configuration.GetSection("input").Value;
        var output = configuration.GetSection("output").Value;
        var start = configuration.GetSection("start").Value;
        var end = configuration.GetSection("end").Value;
    }
}

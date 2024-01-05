using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Application;

public interface IConfigurationReader
{
    Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration);
}
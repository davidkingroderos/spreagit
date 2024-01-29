using SpreaGit.Domain;

namespace SpreaGit.Application;

public interface IConfigurationReader
{
    Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration);
}
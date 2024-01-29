using SpreaGit.Domain.Models;

namespace SpreaGit.Application.Interfaces;

public interface IConfigurationReader
{
    Task<SpreaGitConfiguration?> ReadConfigurationAsync(string configuration);
}
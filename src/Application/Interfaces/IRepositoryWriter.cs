using SpreaGit.Domain.Models;

namespace SpreaGit.Application.Interfaces;

public interface IRepositoryWriter
{
    void InitializeGit(string outputRepositoryPath);
    void CopyRepositoryContents(string repositoryPath, string targetPath);
    void Commit(string outputRepositoryPath, GitLog gitLog);
    void DeleteRepositoryContents(string targetPath);
}
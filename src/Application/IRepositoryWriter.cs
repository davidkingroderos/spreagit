using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Application;

public interface IRepositoryWriter
{
    void InitializeGit(string outputRepositoryPath);
    void CopyRepositoryContents(string repositoryPath, string targetPath);
    void Commit(string outputRepositoryPath, GitLog gitLog);
}
using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Application;

public interface IRepositoryWriter
{
    void InitializeGit(string outputRepositoryPath);
}
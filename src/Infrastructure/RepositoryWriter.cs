using dk.roderos.SpreaGit.Application;
using LibGit2Sharp;

namespace dk.roderos.SpreaGit.Infrastructure;

public class RepositoryWriter : IRepositoryWriter
{
    public void InitializeGit(string outputRepositoryPath)
    {
        Repository.Init(outputRepositoryPath);
    }
}
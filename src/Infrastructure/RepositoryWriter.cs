using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.roderos.SpreaGit.Infrastructure;

public class RepositoryWriter : IRepositoryWriter
{
    public void WriteGitCommits(string outputRepositoryPath, IEnumerable<GitLog> commits)
    {
        _ = Repository.Init(outputRepositoryPath);
    }
}

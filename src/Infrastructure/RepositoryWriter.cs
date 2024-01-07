using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.roderos.SpreaGit.Infrastructure;

public class RepositoryWriter : IRepositoryWriter
{
    public void WriteGitCommits(string outputPath, IEnumerable<GitLog> commits)
    {
    }
}

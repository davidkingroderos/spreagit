using dk.roderos.SpreaGit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.roderos.SpreaGit.Application;

public interface IRepositoryWriter
{
    void WriteGitCommits(string outputPath, IEnumerable<GitLog> commits);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.roderos.SpreaGit.Domain;

public record SpreaGitConfiguration(string RepositoryPath, string OutputPath, string StartDate, string EndDate);
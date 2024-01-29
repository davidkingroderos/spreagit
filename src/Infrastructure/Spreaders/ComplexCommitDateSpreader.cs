using System.Globalization;
using SpreaGit.Application.Interfaces;
using SpreaGit.Domain.Common;
using SpreaGit.Domain.Models;

namespace SpreaGit.Infrastructure.Spreaders;

public class ComplexCommitDateSpreader : ICommitDateSpreader
{
    public IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, SpreaGitConfiguration configuration)
    {
        var startDate = configuration.StartDate;
        var endDate = configuration.EndDate;
            
        var timeDifference = endDate - startDate;
        var secondsDifference = (int)timeDifference.TotalSeconds;
        var numberOfCommits = gitLogs.Count;

        var secondsIntervals = NumberDivider.GetRandomNumberParts(secondsDifference, numberOfCommits);
        var alteredCommits = new List<GitLog>(); 

        alteredCommits.AddRange(gitLogs.Select((currentLog, i) => currentLog with
        {
            Date = startDate.AddSeconds(secondsIntervals[i])
                .ToString(CultureInfo.InvariantCulture)
        }));

        return alteredCommits;
    }
}
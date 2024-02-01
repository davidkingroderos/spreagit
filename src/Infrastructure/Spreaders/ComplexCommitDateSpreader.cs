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
            // TODO: Change Date to DateTimeOffset so no conversion needed
            Date = new DateTimeOffset(startDate.AddSeconds(secondsIntervals[i]), TimeZoneInfo.Local.GetUtcOffset(gitLogs[i].Date))
        }));

        return alteredCommits;
    }
}
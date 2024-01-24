using System.Globalization;
using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Infrastructure;

public class ComplexCommitDateSpreader : ICommitDateSpreader
{
    public IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, DateTime startDate, DateTime endDate)
    {
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
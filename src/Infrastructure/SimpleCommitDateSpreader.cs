using System.Globalization;
using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;

namespace dk.roderos.SpreaGit.Infrastructure;

public class SimpleCommitDateSpreader : ICommitDateSpreader
{
    // TODO: Timezone should be included
    public IEnumerable<GitLog> SpreadOutDateCommits(List<GitLog> gitLogs, DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new ArgumentException("Start date must be earlier than end date");

        var totalCommits = gitLogs.Count;
        var daysDifference = (int)(endDate - startDate).TotalDays;
        var commitsPerDay = totalCommits / daysDifference;
        var remainingCommits = totalCommits % daysDifference;

        var alteredCommits = new List<GitLog>();

        var currentIndex = 0;
        for (var day = 0; day < daysDifference; day++)
        {
            if (remainingCommits > 0 && currentIndex < totalCommits)
            {
                var currentLog = gitLogs[currentIndex];
                var newDate = startDate.AddDays(day);
                var newCommit = currentLog with { Date = newDate.ToString(CultureInfo.InvariantCulture) };
                
                alteredCommits.Add(newCommit);
                currentIndex++;
                remainingCommits--;
            }
            
            for (var commitsAdded = 0;
                 commitsAdded < commitsPerDay && currentIndex < totalCommits;
                 commitsAdded++, currentIndex++)
            {
                var currentLog = gitLogs[currentIndex];
                var newDate = startDate.AddDays(day);
                var newCommit = currentLog with { Date = newDate.ToString(CultureInfo.InvariantCulture) };

                alteredCommits.Add(newCommit);
            }
        }
        
        return alteredCommits;
    }
}
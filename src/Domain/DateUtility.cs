namespace SpreaGit.Domain;

public abstract class DateUtility
{
    public static IEnumerable<DateTimeOffset> GetDateTimeOffsets(DateTime startDate, DateTime endDate)
    {
        var dateTimeOffsets = new List<DateTimeOffset>();

        if (endDate < startDate)
            throw new ArgumentException("End date must be greater than start date");
        
        for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            dateTimeOffsets.Add(currentDate);

        return dateTimeOffsets;
    }
}
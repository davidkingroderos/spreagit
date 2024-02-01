namespace SpreaGit.Domain.Models;

// TODO: Change to StartDate and EndDate to DateTimeOffset
public record SpreaGitConfiguration(
    string RepositoryPath, 
    string OutputPath, 
    DateTime StartDate, 
    DateTime EndDate,
    bool IgnoreWeekends);
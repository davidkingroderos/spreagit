namespace SpreaGit.Domain.Models;

public record SpreaGitConfiguration(
    string RepositoryPath, 
    string OutputPath, 
    DateTime StartDate, 
    DateTime EndDate,
    bool IgnoreWeekends);
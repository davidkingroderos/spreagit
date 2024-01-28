namespace dk.roderos.SpreaGit.Domain;

public record SpreaGitConfiguration(
    string RepositoryPath, 
    string OutputPath, 
    DateTime StartDate, 
    DateTime EndDate,
    bool IgnoreWeekends);
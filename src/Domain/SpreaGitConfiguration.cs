namespace dk.roderos.SpreaGit.Domain;

public record SpreaGitConfiguration(
    string RepositoryPath, 
    string OutputPath, 
    string StartDate, 
    string EndDate);
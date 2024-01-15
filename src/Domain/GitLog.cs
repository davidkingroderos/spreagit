namespace dk.roderos.SpreaGit.Domain;

public record GitLog(
    string Id, 
    string Author, 
    string Email, 
    string Date, 
    string Message);
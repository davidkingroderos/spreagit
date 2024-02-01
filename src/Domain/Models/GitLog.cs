namespace SpreaGit.Domain.Models;

public record GitLog(
    string Id, 
    string Author, 
    string Email, 
    DateTimeOffset Date, 
    string Message);
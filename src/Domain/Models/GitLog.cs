namespace SpreaGit.Domain.Models;

public record GitLog(
    string Id, 
    string Author, 
    string Email, 
    string Date, 
    string Message);
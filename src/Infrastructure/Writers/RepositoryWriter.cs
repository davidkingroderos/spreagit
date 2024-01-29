using LibGit2Sharp;
using SpreaGit.Application.Interfaces;
using SpreaGit.Domain.Models;

namespace SpreaGit.Infrastructure.Writers;

public class RepositoryWriter : IRepositoryWriter
{
    public void InitializeGit(string outputRepositoryPath)
    {
        Repository.Init(outputRepositoryPath);
    }
    
    public void DeleteRepositoryContents(string targetPath)
    {
        var directoryInfo = new DirectoryInfo(targetPath);

        foreach (var file in directoryInfo.GetFiles())
        {
            file.Delete(); 
        }

        // Delete all folders but dont include the .git folder
        var directories = directoryInfo.GetDirectories()
            .Where(folder => !folder.Name.EndsWith(".git", StringComparison.CurrentCultureIgnoreCase));
        foreach (var directory in directories)
        {
            directory.Delete(true); 
        } 
    }

    public void CopyRepositoryContents(string repositoryPath, string targetPath)
    {
        CopyFiles(repositoryPath, targetPath);
    }

    private static void CopyFiles(string repositoryPath, string targetPath)
    {
        // The first directory (output repository path) should exist but its needed because the method is going recursively
        if (!Directory.Exists(targetPath))
            Directory.CreateDirectory(targetPath);

        // TODO: If possible, don't copy files in .gitignore
        foreach (var file in Directory.GetFiles(repositoryPath))
        {
            var destinationFile = Path.Combine(targetPath, Path.GetFileName(file));
            File.Copy(file, destinationFile, true);
        }

        // Copy all folders but .git folder shouldn't be included
        // This since theres no proper way to copy folders, we'll do it recursively
        var directories = Directory.GetDirectories(repositoryPath)
            .Where(folder => !folder.EndsWith(".git", StringComparison.CurrentCultureIgnoreCase)).ToList();
        foreach (var directory in directories)
            CopyFiles(directory, Path.Combine(targetPath, Path.GetFileName(directory)));
    }

    // TODO: Fix bug on parsing dates
    // TODO: Fix bug of commit dates
    public void Commit(string outputRepositoryPath, GitLog gitLog)
    {
        using var repository = new Repository(outputRepositoryPath);
        
        Commands.Stage(repository, "*");

        // TODO: Change GitLog date datatype
        // var author = new Signature(gitLog.Author, gitLog.Email, DateTime.Parse(gitLog.Date));
        var author = new Signature(gitLog.Author, gitLog.Email, DateTime.Now); // TODO: Remove DateTime.Now()
        // Allow empty commits for now
        var allowEmptyCommit = new CommitOptions()
        {
            AllowEmptyCommit = true
        };

        // TODO: Add committer
        repository.Commit(gitLog.Message, author, author, allowEmptyCommit);
    }
}
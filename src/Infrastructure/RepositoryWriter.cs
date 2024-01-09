using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Domain;
using LibGit2Sharp;

namespace dk.roderos.SpreaGit.Infrastructure;

public class RepositoryWriter : IRepositoryWriter
{
    public void InitializeGit(string outputRepositoryPath)
    {
        Repository.Init(outputRepositoryPath);
    }

    public void CopyRepositoryContents(string repositoryPath, string targetPath)
    {
        // The first directory (output repository path) should exist but its needed because the method is going recursively
        if (!Directory.Exists(targetPath))
            Directory.CreateDirectory(targetPath);

        // TODO: If possible, don't copy files in .gitignore
        foreach (var file in Directory.GetFiles(repositoryPath))
            File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)));

        // Copy all folders but .git folder shouldn't be included
        // This since theres no proper way to copy folders, we'll do it recursively
        var directories = Directory.GetDirectories(repositoryPath).Where(folder => !folder.EndsWith(".git")).ToList();
        foreach (var directory in directories)
            CopyRepositoryContents(directory, Path.Combine(targetPath, Path.GetFileName(directory)));
    }

    public void Commit(string outputRepositoryPath, GitLog gitLog)
    {
        using var repository = new Repository(outputRepositoryPath);
        
        Commands.Stage(repository, "*");

        var author = new Signature(gitLog.Author, gitLog.Email, DateTime.Now);
        // Allow empty commits for now
        var allowEmptyCommit = new CommitOptions()
        {
            AllowEmptyCommit = true
        };
        
        // The committer is also the author
        repository.Commit(gitLog.Message, author, author, allowEmptyCommit);
    }
}
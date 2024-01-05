using dk.roderos.SpreaGit.Application;
using dk.roderos.SpreaGit.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

try
{
    var builder = Host.CreateApplicationBuilder(args);

    builder.Services.AddScoped<ISpreaGitService, SpreaGitService>();
    builder.Services.AddScoped<IConfigurationReader, JsonConfigurationReader>();

    builder.Logging.AddSimpleConsole(options =>
    {
        options.SingleLine = true;
        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss";
    });

    using IHost host = builder.Build();

    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    var spreaGitService = host.Services.GetRequiredService<ISpreaGitService>();

    await spreaGitService.SpreaGitAsync();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
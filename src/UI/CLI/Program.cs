using dk.roderos.SpreaGit.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

try
{
    var builder = Host.CreateApplicationBuilder(args);

    builder.Services.AddScoped<ISpreaGitService, SpreaGitService>();

    builder.Logging.AddConsole();

    using IHost host = builder.Build();

    string? input = builder.Configuration.GetValue<string>("output");
    string? output = builder.Configuration.GetValue<string>("input");
    string? start = builder.Configuration.GetValue<string>("start");
    string? end = builder.Configuration.GetValue<string>("end");

    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Input Folder: {input}", input);
    logger.LogInformation("Output Folder: {output}", output);
    logger.LogInformation("End Date: {hi}", start);
    logger.LogInformation("Start Date: {hi}", end);
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
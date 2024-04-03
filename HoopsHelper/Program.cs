using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

using HoopsHelper.ApiService;
using HoopsHelper.Commands;
using HoopsHelper.Data;
using HoopsHelper.Exceptions;
using HoopsHelper.Utilities;

// App settings
IConfigurationRoot settingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
var appSettings = new AppSettings();
settingsConfig.Bind(appSettings);

// Dependency injection
var registrations = new ServiceCollection();
registrations.AddSingleton(appSettings);
registrations.AddSingleton<INbaApiClient, NbaApiClient>();
registrations.AddSingleton<INbaApiService, NbaApiService>();
var registrar = new TypeRegistrar(registrations);

// App configuration
var app = new CommandApp(registrar);
app.Configure(config =>
{
    config.SetHelpProvider(new CustomHelpProvider(config.Settings));
    config.PropagateExceptions();
    config.CaseSensitivity(CaseSensitivity.None);

    config.AddBranch("stats", stats =>
    {
        stats.SetDescription("Display boxscore data by date/player/team");
        stats.AddCommand<StatsDateCommand>("date")
        .WithDescription("[aqua]Purpose:[/] Displays boxscore data for given date\n" +
        "[aqua]Arguments:[/] [[DATE]]: Many formats are accepted (e.g., 01/04/2024, 01-04-2024, Jan4)\n" +
        "[aqua]Notes:[/] Some date formats may be culture specific. See [link=https://learn.microsoft.com/en-us/dotnet/api/system.datetime.parse].NET DateTime.Parse method[/] for more info.");
    });
    config.AddCommand<QuitCommand>("quit").WithDescription("Terminates application");
    config.AddCommand<TestCasesCommand>("tests").IsHidden();
});

// Run it!
int status = AppSettings.CONTINUE;
while (status != AppSettings.QUIT)
{
    string input = Console.ReadLine()?.Trim() ?? "";
    string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    try
    {
        status = app.Run(arguments);
    }
    catch(Exception ex)
    {
        if (ex.InnerException is FantasyHelperException || ex.InnerException is FormatException)
        {
            AnsiConsole.MarkupLine($"[red]{ex.InnerException.Message}[/]\n");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }
    }
}

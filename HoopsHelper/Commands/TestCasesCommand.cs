using Spectre.Console.Cli;

using HoopsHelper.ApiService;
using HoopsHelper.Data;
using HoopsHelper.Helpers;

namespace HoopsHelper.Commands
{
    public class TestCasesCommand(INbaApiService apiService) : AsyncCommand<TestCasesSettings>
    {
        private readonly INbaApiService _apiService = apiService;

        private readonly List<(string, int[])> dateParams = [("2024-01-01", [14238950, 14239616]), ("2024-02-11", [])];
        private readonly string[] statParams = ["per_page=100&dates[]=2024-01-06", "per_page=100&dates[]=2024-01-06&cursor=14265218"];

        public override async Task<int> ExecuteAsync(CommandContext context, TestCasesSettings settings)
        {
            NbaApiClient client = new();

            if (settings.Date)
            {
                foreach (var (date, cursors) in dateParams)
                {
                    List<ApiStatsData> apiStats = await _apiService.GetStatsAsync(date: date);
                    TestExporter.ExportApiStats(apiStats, date);
                    List<Game> games = Deserializers.DeserializeStats(apiStats);
                    TestExporter.ExportGames(games, date);

                    string parameters = $"per_page=100&dates[]={date}";
                    string stats = await client.FetchDataAsync(AppSettings.StatsUrl, parameters);
                    TestExporter.ExportStatMocks(stats, parameters);

                    foreach (int cursor in cursors)
                    {
                        parameters = $"per_page=100&dates[]={date}&cursor={cursor}";
                        stats = await client.FetchDataAsync(AppSettings.StatsUrl, parameters);
                        TestExporter.ExportStatMocks(stats, parameters);
                    }
                }
            }

            if (settings.Stats)
            {
                foreach (string parameters in statParams)
                {
                    string stats = await client.FetchDataAsync(AppSettings.StatsUrl, parameters);
                    TestExporter.ExportStats(stats, parameters);
                }
            }

            return 0;
        }
    }
}

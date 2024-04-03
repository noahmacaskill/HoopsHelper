using Spectre.Console.Cli;

using HoopsHelper.ApiService;
using HoopsHelper.Data;
using HoopsHelper.Helpers;

namespace HoopsHelper.Commands
{
    public class StatsDateCommand(INbaApiService apiService) : AsyncCommand<StatsDateSettings>
    {
        private readonly INbaApiService _apiService = apiService;

        public override async Task<int> ExecuteAsync(CommandContext context, StatsDateSettings settings)
        {
            DateTime date = settings.Date ?? DateTime.Today.AddDays(-1);
            string dateString = date.ToString(AppSettings.DateFormat);
            List<ApiStatsData> apiStats = await _apiService.GetStatsAsync(date: dateString);
            List<Game> games = Deserializers.DeserializeStats(apiStats);

            Renderer.DisplayGames(games);

            return 0;
        }
    }
}

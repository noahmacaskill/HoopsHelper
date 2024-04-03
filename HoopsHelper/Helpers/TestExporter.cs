using Newtonsoft.Json;

using HoopsHelper.Data;

namespace HoopsHelper.Helpers
{
    internal static class TestExporter
    {
        private const string gameFixturesDir = @"c:\Users\noahm\source\repos\FantasyHelperSolution\FantasyHelperTests\Fixtures\ExpectedGames\";
        public const string apiStatsFixturesDir = @"c:\Users\noahm\source\repos\FantasyHelperSolution\FantasyHelperTests\Fixtures\ExpectedApiStats\";
        private const string statFixturesDir = @"c:\Users\noahm\source\repos\FantasyHelperSolution\FantasyHelperTests\Fixtures\ExpectedStats\";
        private const string statMocksDir = @"c:\Users\noahm\source\repos\FantasyHelperSolution\FantasyHelperTests\Fixtures\StatMocks\";

        public static void ExportGames(List<Game> games, string date)
        {
            string json = JsonConvert.SerializeObject(games);
            File.WriteAllText($"{gameFixturesDir}{date}.json", json);
        }

        public static void ExportApiStats(List<ApiStatsData> stats, string date)
        {
            string json = JsonConvert.SerializeObject(stats);
            File.WriteAllText($"{apiStatsFixturesDir}{date}.json", json);
        }

        public static void ExportStats(string stats, string parameters)
        {
            File.WriteAllText($"{statFixturesDir}{parameters}.json", stats);
        }

        public static void ExportStatMocks(string stats, string parameters)
        {
            File.WriteAllText($"{statMocksDir}{parameters}.json", stats);
        }
    }
}

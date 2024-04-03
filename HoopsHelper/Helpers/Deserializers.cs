using HoopsHelper.Data;

namespace HoopsHelper.Helpers
{
    public static class Deserializers
    {
        public static List<Game> DeserializeStats(List<ApiStatsData> statsData)
        {
            var groupedStats = statsData.GroupBy(st => st.Game.Id);

            var games = new List<Game>();
            foreach (var group in groupedStats)
            {
                var game = group.First().Game;

                foreach (var stats in group)
                {
                    if (stats.Player.TeamId == stats.Game.HomeTeam)
                    {
                        game.HomePlayers.Add(stats.Player);
                    }
                    else
                    {
                        game.AwayPlayers.Add(stats.Player);
                    }
                }

                games.Add(game);
            }

            return games;
        }
    }
}

using Spectre.Console;

using HoopsHelper.Data;

namespace HoopsHelper.Helpers
{
    public class Renderer
    {
        public static Table RenderTeamBoxScore(List<Player> players)
        {
            var boxScore = new Table();
            boxScore.AddColumns(AppSettings.BoxScoreHeaders);
            List<(string, string)> dnps = [];

            foreach (Player player in players)
            {
                if (player.StatLine.Minutes == 0)
                {
                    dnps.Add(($"{player.FirstName} {player.LastName}", player.Position));
                }
                else
                {
                    StatLine sl = player.StatLine;

                    boxScore.AddRow([$"{player.FirstName} {player.LastName}", player.Position, $"{sl.Minutes}", $"{sl.Points}", $"{sl.Rebounds}", $"{sl.Assists}",
                    $"{sl.Turnovers}", $"{sl.Steals}", $"{sl.Blocks}", $"{sl.Fgm}/{sl.Fga}", $"{sl.Fg3m}/{sl.Fg3a}", $"{sl.Ftm}/{sl.Fta}", $"{sl.Fpts}"]);
                }
            }

            foreach (var (name, pos) in dnps)
            {
                boxScore.AddRow($"[red]{name}[/]", $"[red]{pos}[/]", $"[red]0[/]");
            }

            return boxScore;
        }

        public static void DisplayGames(List<Game> games)
        {
            var root = new Tree("Games");

            foreach (Game game in games)
            {
                var gameNode = root.AddNode($"{AppSettings.TeamIdToName[game.HomeTeam]}: {game.HomeTeamScore} VS. {AppSettings.TeamIdToName[game.AwayTeam]}: {game.AwayTeamScore}");
                gameNode.AddNode(RenderTeamBoxScore(game.HomePlayers));
                gameNode.AddNode(RenderTeamBoxScore(game.AwayPlayers));
            }

            AnsiConsole.Write(root);
        }
    }
}

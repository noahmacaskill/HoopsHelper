using Spectre.Console.Cli;

namespace HoopsHelper.Commands
{
    public class StatsDateSettings : CommandSettings
    {

        [CommandArgument(0, "[DATE]")]
        public DateTime? Date { get; set; }
    }

    public class StatsTeamSettings : CommandSettings
    {
        [CommandArgument(0, "<TEAM>")]
        public string Team { get; set; } = string.Empty;

        [CommandOption("-g|--games <GAMES>")]
        public int Games { get; set; }

        [CommandOption("-s|--start <START_DATE>")]
        public string StartDate { get; set; } = string.Empty;

        [CommandOption("-e|--end <END_DATE>")]
        public string EndDate { get; set; } = string.Empty;
    }

    public class StatsPlayerSettings : CommandSettings
    {
        // TODO: Make player name array
        [CommandArgument(0, "<PLAYER_NAME>")]
        public string PlayerName { get; set; } = string.Empty;

        [CommandOption("-g|--games <GAMES>")]
        public int Games { get; set; }

        [CommandOption("-s|--start <START_DATE>")]
        public string StartDate { get; set; } = string.Empty;

        [CommandOption("-e|--end <END_DATE>")]
        public string EndDate { get; set; } = string.Empty;
    }

    public class TestCasesSettings : CommandSettings
    {
        [CommandOption("--date")]
        public bool Date { get; set; } = false;
        [CommandOption("--stats")]
        public bool Stats { get; set; } = false;
    }
}

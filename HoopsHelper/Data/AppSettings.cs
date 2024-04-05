namespace HoopsHelper.Data
{
    public class AppSettings
    {
        public const int CONTINUE = 0;
        public const int QUIT = 1;
        
        public const string StatsUrl = "https://api.balldontlie.io/v1/stats";
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateParameter = "dates[]";
        public const string CursorParameter = "cursor";

        public static readonly string[] BoxScoreHeaders = ["Name", "Position", "Minutes", "Points", "Rebounds", "Assists", "TOs", "Steals", "Blocks", "FG", "3PFG", "FT", "FPts"];
        public static readonly Dictionary<int, string> TeamIdToName = new ()
        {
            {1, "ATL" }, {2, "BOS" }, {3, "BKN" }, {4, "CHA" }, {5, "CHI" }, {6, "CLE" }, {7, "DAL" }, {8, "DEN" }, {9, "DET" }, {10, "GSW" },
            {11, "HOU" }, {12, "IND" }, {13, "LAC" }, {14, "LAL" }, {15, "MEM" }, {16, "MIA" }, {17, "MIL" }, {18, "MIN" }, {19, "NOP" }, {20, "NYK" },
            {21, "OKC" }, {22, "ORL" }, {23, "PHI" }, {24, "PHX" }, {25, "POR" }, {26, "SAC" }, {27, "SAS" }, {28, "TOR" }, {29, "UTA" }, {30, "WAS" }
        };
    }
}

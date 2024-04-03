using Newtonsoft.Json;

namespace HoopsHelper.Data
{
    public class Game
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("home_team_id")]
        public int HomeTeam { get; set; }
        [JsonProperty("home_team_score")]
        public int HomeTeamScore { get; set; }
        [JsonProperty("visitor_team_id")]
        public int AwayTeam { get; set; }
        [JsonProperty("visitor_team_score")]
        public int AwayTeamScore { get; set; }
        public List<Player> HomePlayers { get; set; } = [];
        public List<Player> AwayPlayers { get; set; } = [];

        internal static readonly string[] separator = [", "];

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            
            Game other = (Game)obj;

            return Id == other.Id &&
                HomeTeam == other.HomeTeam &&
                HomeTeamScore == other.HomeTeamScore &&
                AwayTeam == other.AwayTeam &&
                AwayTeamScore == other.AwayTeamScore &&
                HomePlayers.SequenceEqual(other.HomePlayers) &&
                AwayPlayers.SequenceEqual(other.AwayPlayers);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

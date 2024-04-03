using Newtonsoft.Json;

namespace HoopsHelper.Data
{
    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;
        [JsonProperty("position")]
        public string Position { get; set; } = string.Empty;
        [JsonProperty("team_id")]
        public int TeamId { get; set; }
        public StatLine StatLine { get; set; } = new();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Player other = (Player)obj;

            return Id == other.Id &&
                FirstName.Equals(other.FirstName) &&
                LastName.Equals(other.LastName) &&
                Position.Equals(other.Position) &&
                TeamId == other.TeamId &&
                StatLine.Equals(other.StatLine);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

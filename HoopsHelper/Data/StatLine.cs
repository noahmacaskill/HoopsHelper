using Newtonsoft.Json;

namespace HoopsHelper.Data
{
    public class StatLine
    {
        [JsonProperty("min")]
        public int Minutes { get; set; }
        [JsonProperty("pts")]
        public int Points { get; set; }
        [JsonProperty("reb")]
        public int Rebounds { get; set; }
        [JsonProperty("ast")]
        public int Assists { get; set; }
        [JsonProperty("turnover")]
        public int Turnovers { get; set; }
        [JsonProperty("stl")]
        public int Steals { get; set; }
        [JsonProperty("blk")]
        public int Blocks { get; set; }
        [JsonProperty("fga")]
        public int Fga { get; set; }
        [JsonProperty("fgm")]
        public int Fgm { get; set; }
        [JsonProperty("fg3a")]
        public int Fg3a { get; set; }
        [JsonProperty("fg3m")]
        public int Fg3m { get; set; }
        [JsonProperty("ftm")]
        public int Ftm { get; set; }
        [JsonProperty("fta")]
        public int Fta { get; set; }
        public int Fpts
        {
            // TODO: Generalize this for variable formats
            get
            {
                return Points + Rebounds + Fg3m + Ftm + 2 * Fgm + 2 * Assists + 4 * Blocks + 4 * Steals - Fga - Fta - 2 * Turnovers;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            StatLine other = (StatLine)obj;

            return Minutes.Equals(other.Minutes) &&
                Points == other.Points &&
                Rebounds == other.Rebounds &&
                Assists == other.Assists &&
                Turnovers == other.Turnovers &&
                Steals == other.Steals &&
                Blocks == other.Blocks &&
                Fga == other.Fga &&
                Fgm == other.Fgm &&
                Fg3a == other.Fg3a &&
                Fg3m == other.Fg3m &&
                Ftm == other.Ftm &&
                Fta == other.Fta;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Minutes, Points, Rebounds, Assists, Turnovers, Steals, Blocks);
        }
    }
}

namespace HoopsHelper.Data
{
    public class ApiStats
    {
        public List<ApiStatsData> Data { get; set; } = [];
        public int? NextCursor { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            ApiStats other = (ApiStats)obj;

            return Data.SequenceEqual(other.Data) &&
                NextCursor == other.NextCursor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Data, NextCursor);
        }
    }

    public class ApiStatsData
    {
        public Player Player { get; set; } = new();
        public Game Game { get; set; } = new();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            ApiStatsData other = (ApiStatsData)obj;

            return Player.Equals(other.Player) &&
                Game.Equals(other.Game);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Player.Id, Game.Id);
        }
    }
}

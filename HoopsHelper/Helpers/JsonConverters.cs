using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using HoopsHelper.Data;

namespace HoopsHelper.Helpers
{
    public class ApiStatsConverter : JsonConverter<ApiStats>
    {
        public override ApiStats? ReadJson(JsonReader reader, Type objectType, ApiStats? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            JArray data = jsonObject["data"]!.ToObject<JArray>()!;
            List<ApiStatsData> allStats = [];

            foreach (var stats in data)
            {
                StatLine statLine = JsonConvert.DeserializeObject<StatLine>(stats.ToString())!;
                Game game = JsonConvert.DeserializeObject<Game>(stats["game"]!.ToString())!;
                Player player = JsonConvert.DeserializeObject<Player>(stats["player"]!.ToString())!;
                player.StatLine = statLine;
                player.TeamId = (int)stats["team"]!["id"]!;

                allStats.Add(new ApiStatsData
                {
                    Game = game,
                    Player = player
                });
            }

            return new ApiStats
            {
                Data = allStats,
                NextCursor = (int?)jsonObject["meta"]!["next_cursor"]
            };
        }

        public override void WriteJson(JsonWriter writer, ApiStats? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

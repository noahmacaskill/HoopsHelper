using System.Text;

using Newtonsoft.Json;

using HoopsHelper.Data;
using HoopsHelper.Helpers;

namespace HoopsHelper.ApiService
{
    public class NbaApiService(INbaApiClient apiClient) : INbaApiService
    {
        public static string FormatParameters(Dictionary<string, object?> parameters)
        {
            StringBuilder sb = new("per_page=100");

            foreach (var (paramName, paramVal) in parameters)
            {
                if (paramVal != null)
                {
                    sb.Append($"&{paramName}={paramVal}");
                }
            }

            return sb.ToString();
        }

        public async Task<List<ApiStatsData>> GetStatsAsync(string? date = null)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ApiStatsConverter());

            Dictionary<string, object?> parameters = new()
            {
                {AppSettings.DateParameter, date }
            };

            string parameterString = FormatParameters(parameters);
            string statsJson = await apiClient.FetchDataAsync(AppSettings.StatsUrl, parameterString);

            List<ApiStatsData> allStats = [];

            while (true)
            {
                ApiStats stats = JsonConvert.DeserializeObject<ApiStats>(statsJson, settings)!;                
                allStats.AddRange(stats.Data);

                if (stats.NextCursor != null)
                {
                    parameters[AppSettings.CursorParameter] = stats.NextCursor;
                    string cursorParameterString = FormatParameters(parameters);
                    statsJson = await apiClient.FetchDataAsync(AppSettings.StatsUrl, cursorParameterString);
                }
                else
                {
                    break;
                }
            }

            return allStats;
        }
    }
}

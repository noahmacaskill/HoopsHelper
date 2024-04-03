using HoopsHelper.Data;

namespace HoopsHelper.ApiService
{
    public interface INbaApiService
    {
        Task<List<ApiStatsData>> GetStatsAsync(string? date = null);
    }
}

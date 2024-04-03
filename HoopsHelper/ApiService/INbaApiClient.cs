namespace HoopsHelper.ApiService
{
    public interface INbaApiClient
    {
        Task<string> FetchDataAsync(string url, string param);
    }
}

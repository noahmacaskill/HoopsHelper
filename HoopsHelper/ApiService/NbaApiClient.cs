using HoopsHelper.Exceptions;

namespace HoopsHelper.ApiService
{
    public class NbaApiClient : INbaApiClient
    {
        private readonly HttpClient client;

        private readonly string _apiKey;

        public NbaApiClient()
        {
            _apiKey = Environment.GetEnvironmentVariable("NBA_API_KEY") ?? throw new NbaApiServiceException("NBA_API_KEY environment variable has not been set. Plase set it (see documentation)");
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", _apiKey);
        }

        public async Task<string> FetchDataAsync(string url, string param)
        {
            HttpResponseMessage response = await client.GetAsync($"{url}?{param}");

            if (response.IsSuccessStatusCode == false)
            {
                throw new NbaApiServiceException(response.StatusCode);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}

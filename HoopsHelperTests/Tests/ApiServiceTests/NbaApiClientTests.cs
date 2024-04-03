using Newtonsoft.Json;

using HoopsHelper.ApiService;
using HoopsHelper.Data;
using HoopsHelper.Helpers;
using HoopsHelperTests.Fixtures;

namespace HoopsHelperTests.Tests.ApiServiceTests
{
    [TestFixture]
    public class NbaApiClientTests
    {
        NbaApiClient _apiClient;
        JsonSerializerSettings settings;

        [OneTimeSetUp]
        public void Setup()
        {
            string projDirectory = TestContext.CurrentContext.TestDirectory;
            Directory.SetCurrentDirectory(projDirectory);

            _apiClient = new NbaApiClient();

            settings = new JsonSerializerSettings();
            settings.Converters.Add(new ApiStatsConverter());
        }

        [Test]
        [TestCaseSource(typeof(FixturesHelper), nameof(FixturesHelper.StatsFixtures))]
        public async Task FetchDataTest(string expectedFile)
        {
            string expectedStatsJson = File.ReadAllText(expectedFile);
            ApiStats expectedStats = JsonConvert.DeserializeObject<ApiStats>(expectedStatsJson, settings)!;

            string parameters = Path.GetFileName(expectedFile).Split('.')[0];
            string actualStatsJson = await _apiClient.FetchDataAsync(AppSettings.StatsUrl, parameters);
            ApiStats actualStats = JsonConvert.DeserializeObject<ApiStats>(actualStatsJson, settings)!;;

            Assert.That(expectedStats, Is.EqualTo(actualStats));
        }
    }
}

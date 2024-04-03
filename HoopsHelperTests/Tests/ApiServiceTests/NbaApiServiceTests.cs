using Moq;
using Newtonsoft.Json;

using HoopsHelper.ApiService;
using HoopsHelper.Data;
using HoopsHelperTests.Fixtures;

namespace HoopsHelperTests.Tests.Tests.ApiServiceTests
{
    [TestFixture]
    public class NbaApiServiceTests
    {
        private NbaApiService _apiService;

        private static IEnumerable<TestCaseData> FormatParametersTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Dictionary<string, object?> { { "dates[]", null }, { "cursor", null } },
                    "per_page=100");

                yield return new TestCaseData(
                    new Dictionary<string, object?> { { "dates[]", "2024-01-01" }, { "cursor", null } },
                    "per_page=100&dates[]=2024-01-01");

                yield return new TestCaseData(
                    new Dictionary<string, object?> { { "dates[]", "2024-01-01" }, { "cursor", 1125 } },
                    "per_page=100&dates[]=2024-01-01&cursor=1125");
            }
        }

        [OneTimeSetUp]
        public void Setup()
        {
            string projDirectory = TestContext.CurrentContext.TestDirectory;
            Directory.SetCurrentDirectory(projDirectory);

            var apiClientMock = new Mock<INbaApiClient>();

            foreach (string statsFile in FixturesHelper.StatMocks)
            {
                string expectedStats = File.ReadAllText(statsFile);
                string parameters = Path.GetFileName(statsFile).Split('.')[0];
                apiClientMock.Setup(x => x.FetchDataAsync(AppSettings.StatsUrl, parameters)).Returns(Task.FromResult(expectedStats));
            }

            _apiService = new NbaApiService(apiClientMock.Object);
        }

        [Test]
        [TestCaseSource(nameof(FormatParametersTestCases))]
        public void FormatParametersTest(Dictionary<string, object?> parameters, string expectedParameters)
        {
            string actualParameters = NbaApiService.FormatParameters(parameters);

            Assert.That(actualParameters, Is.EqualTo(expectedParameters));
        }

        [Test]
        [TestCaseSource(typeof(FixturesHelper), nameof(FixturesHelper.ApiStatsFixtures))]
        public async Task GetStatsAsyncDateTest(string expectedFile)
        {
            string expectedStatsJson = File.ReadAllText(expectedFile);
            List<ApiStatsData> expectedGames = JsonConvert.DeserializeObject<List<ApiStatsData>>(expectedStatsJson)!;

            string date = Path.GetFileName(expectedFile).Split('.')[0];
            List<ApiStatsData> actualGames = await _apiService.GetStatsAsync(date: date);

            Assert.That(expectedGames, Is.EqualTo(actualGames));
        } 
    }
}

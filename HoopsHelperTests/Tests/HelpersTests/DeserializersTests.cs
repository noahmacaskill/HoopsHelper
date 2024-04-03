using Newtonsoft.Json;

using HoopsHelper.Data;
using HoopsHelper.Helpers;
using HoopsHelperTests.Fixtures;

namespace HoopsHelperTests.Tests.HelpersTests
{
    [TestFixture]
    public class DeserializersTests
    {   
        [Test, Sequential]
        public void DeserializeStatsTest([ValueSource(typeof(FixturesHelper), nameof(FixturesHelper.ApiStatsFixtures))] string inputFile,
            [ValueSource(typeof(FixturesHelper), nameof(FixturesHelper.GamesFixtures))] string expectedFile)
        {
            string inputStats = File.ReadAllText(inputFile);
            List<ApiStatsData> stats = JsonConvert.DeserializeObject<List<ApiStatsData>>(inputStats)!;
            string expectedGamesJson = File.ReadAllText(expectedFile);
            List<Game> expectedGames = JsonConvert.DeserializeObject<List<Game>>(expectedGamesJson)!;

            List<Game> actualGames = Deserializers.DeserializeStats(stats);

            Assert.That(expectedGames, Is.EqualTo(actualGames));
        }
    }
}

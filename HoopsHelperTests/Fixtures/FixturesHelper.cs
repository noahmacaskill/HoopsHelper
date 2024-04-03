namespace HoopsHelperTests.Fixtures
{
    public static class FixturesHelper
    {
        private const string gameFixturesDir = @"..\..\..\Fixtures\ExpectedGames\";
        private const string apiStatsFixturesDir = @"..\..\..\Fixtures\ExpectedApiStats\";
        private const string statFixturesDir = @"..\..\..\Fixtures\ExpectedStats\";
        private const string statMocksDir = @"..\..\..\Fixtures\StatMocks\";

        public static IEnumerable<string> GamesFixtures
        {
            get
            {
                string[] fixtures = Directory.GetFiles(gameFixturesDir);

                foreach (string fixture in fixtures)
                {
                    yield return fixture;
                }
            }
        }

        public static IEnumerable<string> ApiStatsFixtures
        {
            get
            {
                string[] fixtures = Directory.GetFiles(apiStatsFixturesDir);

                foreach (string fixture in fixtures)
                {
                    yield return fixture;
                }
            }
        }

        public static IEnumerable<string> StatsFixtures
        {
            get
            {
                string[] fixtures = Directory.GetFiles(statFixturesDir);

                foreach (string fixture in fixtures)
                {
                    yield return fixture;
                }
            }
        }

        public static IEnumerable<string> StatMocks
        {
            get
            {
                string[] fixtures = Directory.GetFiles(statMocksDir);

                foreach (string fixture in fixtures)
                {
                    yield return fixture;
                }
            }
        }
    }
}

namespace HoopsHelperTests.Fixtures
{
    public static class FixturesHelper
    {
        private static string gameFixturesDir = Path.Combine("..", "..", "..", "Fixtures", "ExpectedGames");
        private static string apiStatsFixturesDir = Path.Combine("..", "..", "..", "Fixtures", "ExpectedApiStats");
        private static string statFixturesDir = Path.Combine("..", "..", "..", "Fixtures", "ExpectedStats");
        private static string statMocksDir = Path.Combine("..", "..", "..", "Fixtures", "StatMocks");

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

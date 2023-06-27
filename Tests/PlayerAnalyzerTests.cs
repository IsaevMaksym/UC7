using BL;
using BL.Entities;

namespace Tests
{
    public class PlayerAnalyzerTests
    {
        private PlayerAnalyzer _playerAnalyzer;

        public PlayerAnalyzerTests()
        {
            _playerAnalyzer = new PlayerAnalyzer();
        }

        [Fact]
        public void OnePlayerAge25Experience5Skils222Passed_250Returned()
        {
            var players = GetPlayers(25, 5, new List<int> { 2, 2, 2 });
            double expected = 250;

            var actual = _playerAnalyzer.CalculateScore(players);

            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePlayerAge15Experience3Skils333Passed_67and5Returned()
        {
            var players = GetPlayers(15, 3, new List<int> { 3, 3, 3 });
            double expected = 67.5;

            var actual = _playerAnalyzer.CalculateScore(players);

            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePlayerAge35Experience15Skils444Passed_2520Returned()
        {
            var players = GetPlayers(35, 15, new List<int> { 4, 4, 4 });
            double expected = 2520;

            var actual = _playerAnalyzer.CalculateScore(players);

            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreePlayerspassed_1130Returned()
        {
            double expected = 1130;
            var players = GetPlayers(20, 4, new List<int> { 2, 1, 4 });
            players.Add(GetPlayers(15, 2, new List<int> { 0, 1, 1 }).First());
            players.Add(GetPlayers(28, 10, new List<int> { 3, 5, 2 }).First());

            var actual = _playerAnalyzer.CalculateScore(players);

            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePlayerSkillsIsNull_ArgumentNullExceptionIsThrown()
        {
            List<int> skills = null;

            var players = GetPlayers(20, 4, skills);

            Assert.Throws<ArgumentNullException>(() => _playerAnalyzer.CalculateScore(players));
        }

        [Fact]
        public void EmptyListIsPassed_ZeroIsReturned()
        {
            double expected = 0;

            var players = new List<Player>();

            var actual = _playerAnalyzer.CalculateScore(players);

            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);
        }

        private List<Player> GetPlayers(int age, int experiense, List<int> skills, string name = "SomeRandomName")
        {
            return new List<Player>
            {
                new Player
                {
                    Age = age,
                    Experience = experiense,
                    Skills = skills,
                    Name = name
                }
            };
        }
    }
}
using NUnit.Framework;

namespace BggAlerter.UnitTests
{
    class GameTests
    {
        private Game FirstGame;
        private Game SameGame;
        private Game DifferentGame;

        public GameTests()
        {
            FirstGame = new Game
            {
                Position = 1
            };

            SameGame = new Game
            {
                Position = 1
            };

            DifferentGame = new Game
            {
                Position = 2
            };
        }

        [Test]
        public void CorrectlyConstructs()
        {
            var position = 1;
            var name = "NameTest";
            var year = 2021;
            var rating = 1.2;

            var game = new Game(position, name, year, rating);

            Assert.AreEqual(position, game.Position);
            Assert.AreEqual(name, game.Name);
            Assert.AreEqual(year, game.Year);
            Assert.AreEqual(rating, game.Rating);
        }

        [Test]
        public void CorrectlyChecksEqual()
        {
            Assert.True(FirstGame == SameGame);
        }

        [Test]
        public void CorrectlyFailsEqual()
        {
            Assert.False(FirstGame == DifferentGame);
        }

        [Test]
        public void CorrectlyChecksNotEqual()
        {
            Assert.True(FirstGame != DifferentGame);
        }

        [Test]
        public void CorrectlyFailsNotEqual()
        {
            Assert.False(FirstGame != SameGame);
        }
    }
}

using BowlingGame;
using Xunit;

namespace BowlingGameTests
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void Game_FullGameZeros_Success()
        {
            RollMany(20, 0);

            Assert.Equal(0,_game.Score());
        }

        [Fact]
        public void Game_FullGameOnes_Success()
        {
            RollMany(20, 1);

            Assert.Equal(0,_game.Score());
        }

        [Fact]
        public void Game_OneSpareWithZeroes_Success()
        {
            RollSpare();
            RollMany(18, 0);

            Assert.Equal(10,_game.Score());
        }

        [Fact]
        public void Game_OneSpareWithOnes_Success()
        {
            RollSpare();
            RollMany(18, 1);

            Assert.Equal(29,_game.Score());
        }

        [Fact]
        public void Game_OneStrikeWithOnes_Success()
        {
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(26,_game.Score());
        }

        [Fact]
        public void Game_PerfectGame_Success()
        {
            RollMany(12, 10);

            Assert.Equal(300, _game.Score());
        }

        [Fact]
        public void Game_AllSpare_Success()
        {
            RollMany(21, 5);

            Assert.Equal(155, _game.Score());
        }

        /*Добавлено начало*/
        [Fact]
        public void Game_Throw_Test()
        {
            RollMany(10, 10);

            Assert.Equal(270, _game.Score());
        }

        [Theory]
        [InlineData (10,5,115)] //неверный результат
        [InlineData(10, 5, 70)] // верный
        public void Game_Test2(int times, int pins, int result)
        {
            RollMany(times, pins);
            Assert.Equal(result, _game.Score());
        }
         /*Добавлено конец*/

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}

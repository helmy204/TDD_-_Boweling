using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boweling.Service;

namespace Boweling.Service.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        GameService gameService;

        // SetUp
        [TestInitialize]
        public void Initialize()
        {
            gameService = new GameService();
        }

        [TestMethod]
        public void RollZeroScoreIsZero()
        {
            // Excercise
            gameService.Roll(0); 
            // Verify
            Assert.AreEqual(0, gameService.Score);
        }

        [TestMethod]
        //[Ignore]
        public void OpenFrameAddsPins()
        {
            // Excercise
            gameService.Roll(4);
            gameService.Roll(2);
            // Verify
            Assert.AreEqual(6, gameService.Score);
        }

        [TestMethod]
        //[Ignore]
        public void SpareAddsNextBall()
        {
            gameService.Roll(4);
            gameService.Roll(6);
            gameService.Roll(3);
            gameService.Roll(0);

            Assert.AreEqual(16, gameService.Score);
        }

        [TestMethod]
        //[Ignore]
        public void ATenInTwoFramesIsNotASpare()
        {
            gameService.Roll(3);
            gameService.Roll(6);
            gameService.Roll(4);
            gameService.Roll(2);

            Assert.AreEqual(15, gameService.Score);
        }

        [TestMethod]
        //[Ignore]
        public void AStrikeAddsNextTwoBalls()
        {
            gameService.Roll(10);
            gameService.Roll(3);
            gameService.Roll(2);

            Assert.AreEqual(20, gameService.Score);
        }
    }
}

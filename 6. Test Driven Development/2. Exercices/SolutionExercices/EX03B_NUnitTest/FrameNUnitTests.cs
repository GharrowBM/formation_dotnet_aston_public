using EX03B_Classes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EX03B_NUnitTest
{
    [TestFixture]
    public class FrameNUnitTestd
    {
        private Mock<IGenerator> _generator;

        [SetUp]
        public void Setup()
        {
            _generator = new Mock<IGenerator>();
        }

        [Test]
        public void Roll_SimpleFrameFirstRoll_CheckScore()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(6);
            Frame frame = new Frame(_generator.Object, false);

            bool result = frame.Roll();

            Assert.IsTrue(frame.Score == 6 && result);
        }

        [Test]
        public void Roll_SimpleFrameWithStrike_ReturnFalse()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(6);
            Frame frame = new Frame(_generator.Object, false) { Rolls = new List<Roll>() { new Roll(10) } };

            bool result = frame.Roll();

            Assert.IsFalse(result);
        }


        [Test]
        public void Roll_SimpleFrameAndSecondRoll_CkeckScore()
        {
            _generator.Setup(g => g.RandomPins(4)).Returns(3);
            Frame frame = new Frame(_generator.Object, false) {  Rolls = new List<Roll>() { new Roll(6) } };

            bool result = frame.Roll();

            Assert.That(frame.Score, Is.AtMost(10));
        }

        [Test]
        public void Roll_SimpleFrameAndThirdRoll_ReturnFalse()
        {
            Frame frame = new Frame(_generator.Object, false) {  Rolls = new List<Roll>() { new Roll(6), new Roll(2) } };

            bool result = frame.Roll();

            Assert.IsFalse(result);
        }

        [Test]
        public void Roll_LastFrameSecondRollAfterStrike_ReturnTrue()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(10) } };

            bool result = frame.Roll();

            Assert.IsTrue(result);
        }

        [Test]
        public void Roll_LastFrameSecondRollAfterStrike_ScoreChecker()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(10) } };

            bool result = frame.Roll();

            Assert.AreEqual(13, frame.Score);
        }


        [Test]
        public void Roll_LastFrameThirdRollAfterStrike_ReturnTrue()
        {
            _generator.Setup(g => g.RandomPins(7)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(10), new Roll(3) } };

            bool result = frame.Roll();

            Assert.IsTrue(result);
        }

        [Test]
        public void Roll_LastFrameThirdRollAfterStrike_ScoreChecker()
        {
            _generator.Setup(g => g.RandomPins(7)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(10), new Roll(3) } };

            bool result = frame.Roll();

            Assert.AreEqual(16, frame.Score);
        }

        [Test]
        public void Roll_LastFrameThirdRollAfterSpare_ReturnTrue()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(7), new Roll(3) } };

            bool result = frame.Roll();

            Assert.IsTrue(result);
        }

        [Test]
        public void Roll_LastFrameThirdRollAfterSpare_ScoreChecker()
        {
            _generator.Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(7), new Roll(3) } };

            bool result = frame.Roll();

            Assert.AreEqual(13, frame.Score);
        }

        [Test]
        public void Roll_LastFrameFourthRoll_ReturnFalse()
        {
            Frame frame = new Frame(_generator.Object, true) { Rolls = new List<Roll>() { new Roll(7), new Roll(3), new Roll(10) } };

            bool result = frame.Roll();

            Assert.IsFalse(result);
        }
    }
}
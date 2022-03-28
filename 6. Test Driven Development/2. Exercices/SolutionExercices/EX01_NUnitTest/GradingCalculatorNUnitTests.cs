using EX01_Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX01_NUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradeCalc_Input95ScoreAnd90Attendance_GetAGrade()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;
            char result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo('A'));
        }

        [Test]
        public void GradeCalc_Input85ScoreAnd90Attendance_GetBGrade()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;
            char result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo('B'));
        }

        [Test]
        public void GradeCalc_Input65ScoreAnd90Attendance_GetCGrade()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;
            char result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo('C'));
        }

        [Test]
        public void GradeCalc_Input95ScoreAnd65Attendance_GetBGrade()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;
            char result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo('B'));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailureScenarios_GetFGrade(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            char result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo('F'));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = 'A')]
        [TestCase(85, 90, ExpectedResult = 'B')]
        [TestCase(65, 90, ExpectedResult = 'C')]
        [TestCase(95, 65, ExpectedResult = 'B')]
        [TestCase(95, 55, ExpectedResult = 'F')]
        [TestCase(65, 55, ExpectedResult = 'F')]
        [TestCase(50, 90, ExpectedResult = 'F')]
        public char GradeCalc_InputScoreAndAttendance_GetCorrectGrade(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            return _gradingCalculator.GetGrade();

        }



    }
}

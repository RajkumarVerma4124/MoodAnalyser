using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace TestingMoodAnalyser
{
    [TestClass]
    public class TestingMood
    {
        [TestCategory("Sad Message")]
        [TestMethod]
        public void TestSadMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Sad Mood";
            string expected = "sad";
            MoodAnalyse mood = new MoodAnalyse();

            ///Act
            string actual = mood.AnalyzeMood(msg);
          
            ///Asert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Happy Message")]
        [TestMethod]
        public void TestHappyMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Any Mood";
            string expected = "happy";
            MoodAnalyse mood = new MoodAnalyse();

            ///Act
            string actual = mood.AnalyzeMood(msg);

            ///Asert
            Assert.AreEqual(expected, actual);
        }
    }
}

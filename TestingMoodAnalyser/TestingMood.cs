using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace TestingMoodAnalyser
{
    /// <summary>
    /// Different Test Cases For Analysing Mood
    /// </summary>
    [TestClass]
    public class TestingMood
    {
        //Method to test sad message
        [TestCategory("Sad Message")]
        [TestMethod]
        public void TestSadMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Sad Mood";
            string expected = "sad";
            MoodAnalyse mood = new MoodAnalyse(msg);

            ///Act
            string actual = mood.AnalyzeMood();
          
            ///Asert
            Assert.AreEqual(expected, actual);
        }

        //Method to test happy message
        [TestCategory("Happy Message")]
        [TestMethod]
        public void TestHappyMoodMessage()
        {
            ///AAA
            ///Arange
            string msg = "I am in Any Mood";
            string expected = "happy";
            MoodAnalyse mood = new MoodAnalyse(msg);

            ///Act
            string actual = mood.AnalyzeMood();

            ///Asert
            Assert.AreEqual(expected, actual);
        }
    }
}

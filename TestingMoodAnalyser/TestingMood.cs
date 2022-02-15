using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace TestingMoodAnalyser
{
    /// <summary>
    /// Different Test Cases For Analysing Mood
    /// </summary>
    [TestClass]
    public class TestingMood
    {
        MoodAnalyserReflector reflector;

        //Initializing the constructor
        [TestInitialize]
        public void SetUp()
        { 
            reflector = new MoodAnalyserReflector();
        }

        //Method to test sad and happy message(UC1-TC1.1 && TC1.2 && UC2-TC2.1)
        [TestCategory("Sad Or Happy Message && Null Exception")]
        [TestMethod]
        [DataRow("I am in Sad Mood", "sad")]
        [DataRow("I am in Any Mood", "happy")]
        [DataRow(null, "happy")]
        public void TestHappySadAndNullMoodMessage(string message, string expected)
        {
                  
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            ///Act
            string actual = moodAnalyse.AnalyzeMood();
          
            ///Asert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Method to test custom exception for null message(UC3-TC3.1)
        /// && To test custom exception empty message(UC3-TC3.2)
        /// </summary>
        [TestCategory("Custom Null Or Empty Exception")]
        [TestMethod]
        [DataRow(null, "Message should not be null")]
        [DataRow("","Message should not be empty")]
        public void TestCustomNullOrEmptyException(string message, string expected)
        {
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            try
            {
                ///Act
                string actual = moodAnalyse.AnalyzeMood();
            }
            catch(MoodAnalysisException e)
            {
                ///Asert
                Assert.AreEqual(expected, e.Message);
            }   
        }

        /// <summary>
        /// Method to test so moodanalyser class return moodanalyser objects(UC4-TC4.1)
        /// && To test so mood analyser with diff class to return no class found(UC4-TC4.2)
        /// && To test so mood analyser class return contructor not found(UC4-TC4.3)
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.Customer", "Customer", "")]
        [DataRow("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "")]
        [DataRow("MoodAnalyser.Linklist", "Linklist", "The Given Class IS Not Found")]
        [DataRow("MoodAnalyser.Stack", "Stack", "The Given Class IS Not Found")]
        [DataRow("MoodAnalyser.MoodAnalyse", "Linklist", "The Given Constructor Is Not Found")]
        [DataRow("MoodAnalyser.MoodAnalyse", "Customer", "The Given Constructor Is Not Found")]
        public void ReturnDefaultCtrOrNoClsFoundOrNoCtrFOund(string className, string constructor, string expectedError)
        {
            MoodAnalyse expected = new MoodAnalyse();
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserObject(className, constructor);
                expected.Equals(obj);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expectedError, actual.Message);
            }
        }

        /// <summary>
        /// Method to test moodanalyser class with parameter constructor to check if two objects are equal(UC5-TC5.1)
        /// && to test moodanalyser with diff class with parameter constructor to throw error(UC5-TC5.2)
        /// && to test moodanalyser with diff constructor with parameter constructor to throw error(UC5-TC5.3)
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyse", "I am in Happy mood", "MoodAnalyse", "")]
        [DataRow("MoodAnalyse", "I am in Sad mood", "MoodAnalyse", "")]
        [DataRow("MoodAnalyse", "I am in any mood", "MoodAnalyse", "")]
        [DataRow("MoodAnalyse.Queues", "I am in Happy mood", "MoodAnalyse", "No Such Class")]
        [DataRow("MoodAnalyse.Linkedlist", "I am in Sad mood", "MoodAnalyse", "No Such Class")]
        [DataRow("MoodAnalyse.Stack", "I am in any mood", "MoodAnalyse", "No Such Class")]
        [DataRow("MoodAnalyse", "I am in Happy mood", "Customer", "No Such Constructor")]
        [DataRow("MoodAnalyse", "I am in Sad mood", "Linkedlist", "No Such Constructor")]
        [DataRow("MoodAnalyse", "I am in any mood", "Stack", "No Such Constructor")]
        public void GivenMsgeReturnParaCtrClsNtFoundOrCtrNotFound(string className, string message, string constructor, string expextedError)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserParameterizedObject( className, constructor, message);
                obj.Equals(expected);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        /// <summary>
        /// Method to set the field value and invoke method using reflection(UC7-TC7.1) &&
        /// Method to set the field value with invalid field to throw exception(UC7-TC7.2&7.3)
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("happy", "happy", "Message")]
        [DataRow("sad", "sad", "Message")]
        [DataRow("happy", "Property is not found", "msg")]
        [DataRow("sad", "Property is not found", "newmsg")]
        [DataRow(null, "Message should not be null", "Message")]
        public void ReflectionReturnSetAndInvalidField(string value, string expected, string message)
        {
            string actual = null;
            try
            {
                actual = reflector.SetField(value, message);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalysisException act)
            {
                Assert.AreEqual(expected, act.Message);
            }
        }
    }
}

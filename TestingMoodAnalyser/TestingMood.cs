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
        MoodAnalyse setMood, setMoodAny, setNull, setEmpty;
        MoodAnalyserReflector reflector;

        //Initializing the constructor
        [TestInitialize]
        public void SetUp()
        {
            string sadMessage = "I am in Sad Mood";
            setMood = new MoodAnalyse(sadMessage);
            string happyMessage = "I am in Any Mood";
            setMoodAny = new MoodAnalyse(happyMessage);
            string nullMessage = null;
            setNull = new MoodAnalyse(nullMessage);
            string emptyMessage = "";
            setEmpty = new MoodAnalyse(emptyMessage);
            reflector = new MoodAnalyserReflector();
        }
        //Method to test sad message(UC1-TC1.1)
        [TestCategory("Sad Message")]
        [TestMethod]
        public void TestSadMoodMessage()
        {
            ///AAA
            ///Arange        
            string expected = "sad";

            ///Act
            string actual = setMood.AnalyzeMood();
          
            ///Asert
            Assert.AreEqual(expected, actual);
        }

        //Method to test happy message(UC1-TC1.2)
        [TestCategory("Happy Message")]
        [TestMethod]
        public void TestHappyMoodMessage()
        {
            ///AAA
            ///Arange
            string expected = "happy";

            ///Act
            string actual = setMoodAny.AnalyzeMood();

            ///Asert
            Assert.AreEqual(expected, actual);
        }

        //Method to test happy message(UC2-TC2.1)
        [TestCategory("Null Exception")]
        [TestMethod]
        public void TestNullMessageException()
        {
            ///AAA
            ///Arange
            string expected = "happy";

            ///Act
            string actual = setNull.AnalyzeMood();
                  
            ///Asert
            Assert.AreEqual(expected, actual);
        }

        //Method to test custom exception message(UC3-TC3.1)
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void TestCustomNullException()
        {
            ///AAA
            ///Arange
            string expected = "Message should not be null";
            try
            {
                ///Act
                string actual = setNull.AnalyzeMood();
            }
            catch(MoodAnalysisException e)
            {
                ///Asert
                Assert.AreEqual(expected, e.Message);
            }   
        }

        //Method to test custom exception message(UC3-TC3.2)
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void TestCustomEmptyException()
        {
            ///AAA
            ///Arange
            string expected = "Message should not be empty";
            try
            {
                ///Act
                string actual = setEmpty.AnalyzeMood();
            }
            catch (MoodAnalysisException e)
            {
                ///Asert
                Assert.AreEqual(expected, e.Message);
            }
        }

        //Method to test so moodanalyser class return moodanalyser objects(UC4-TC4.1)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.Customer", "Customer")]
        [DataRow("MoodAnalyser.MoodAnalyse", "MoodAnalyse")]
        public void ReturnDefaultConstructor(string className, string constructor)
        {
            MoodAnalyse expected = new MoodAnalyse();
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserObject(className, constructor);
            }
            catch (MoodAnalysisException ex)
            {
                throw new Exception(ex.Message);
            }
            expected.Equals(obj);
        }

        //Method to test so mood analyser with diff class to return no class found(UC4-TC4.2)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.Linklist", "Linklist", "The Given Class IS Not Found")]
        [DataRow("MoodAnalyser.Stack", "Stack", "The Given Class IS Not Found")]
        public void ReturnDefaultConstructorNoClassFound(string className, string constructor, string expected)
        {
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserObject(className, constructor);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        //Method to test so mood analyser class return contructor not found(UC4-TC4.3)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.MoodAnalyse", "Linklist", "The Given Constructor Is Not Found")]
        [DataRow("MoodAnalyser.MoodAnalyse", "Customer", "The Given Constructor Is Not Found")]
        public void ReturnDefaultConstructorNoConstructorFound(string className, string constructor, string expected)
        {
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserObject(className, constructor);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        //Method to test moodanalyser class with parameter constructor to check if two objects are equal(UC5-TC5.1)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow("I am in Sad mood")]
        [DataRow("I am in any mood")]
        public void GivenMessageReturnParameterizedConstructor(string message)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserParameterizedObject("MoodAnalyse", "MoodAnalyse", message);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
            obj.Equals(expected);
        }

        //Method to test moodanalyser with diff class with parameter constructor to throw error(UC5-TC5.2)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyse.Queues", "I am in Happy mood", "No Such Class")]
        [DataRow("MoodAnalyse.Linkedlist", "I am in Sad mood", "No Such Class")]
        [DataRow("MoodAnalyse.Stack", "I am in any mood", "No Such Class")]
        public void GivenMessageReturnParameterizedClassNotFound(string className, string message, string expextedError)
        {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserParameterizedObject(className, "MoodAnalyse", message);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        //Method to test moodanalyser with diff constructor with parameter constructor to throw error(UC5-TC5.3)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Customer", "I am in Happy mood", "No Such Constructor")]
        [DataRow("Linkedlist", "I am in Sad mood", "No Such Constructor")]
        [DataRow("Stack", "I am in any mood", "No Such Constructor")]
        public void GivenMessageReturnParameterizedConstructorNotFound(string constructor, string message, string expextedError)
            {
            MoodAnalyse expected = new MoodAnalyse(message);
            object obj = null;
            try
            {
                obj = reflector.CreateMoodAnalyserParameterizedObject("MoodAnalyse", constructor, message);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expextedError, actual.Message);
            }
        }

        //Method to invoke analyse mood method to return happy or sad(UC6-TC6.1)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("happy")]
        public void ReflectionReturnMethod(string expected)
        {
            string actual = reflector.InvokeAnalyserMethod("happy", "AnalyzeMood");
            Assert.AreEqual(expected, actual);
        }

        //Method to invoke analyse mood method to return invalid method(UC6-TC6.2)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("No Such Method")]
        public void ReflectionReturnInvalidMethod(string expected)
        {
            try
            {
                string actual = reflector.InvokeAnalyserMethod("happy", "AnalyzerMood");
            }
            catch(MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        //Method to set the field value and invoke method using reflection(UC7-TC7.1)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("happy", "happy", "message")]
        [DataRow("sad", "sad", "message")]
        public void ReflectionReturnSetField(string value, string expected, string message)
        {    
            string actual = reflector.SetField(value, message); 
            Assert.AreEqual(expected, actual);  
        }

        //Method to set the field value with invalid field to throw exception(UC7-TC7.2&7.3)
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("happy", "Field is not found", "msg")]
        [DataRow("sad", "Field is not found", "newmsg")]
        [DataRow("", "Message should not be null", "message")]
        [DataRow(null, "Message should not be null", "message")]
        public void ReflectionReturnInvalidField(string value, string expected, string message)
        {
            try
            {
                string actual = reflector.SetField(value, message);
            }
            catch (MoodAnalysisException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
         
        }
    }
}

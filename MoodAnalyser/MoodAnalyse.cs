using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    /// <summary>
    /// Class to check a message, ability to analyse and respond happy or sad Mood
    /// </summary>
    public class MoodAnalyse
    {
        //Declaring varibale
        public string message;

        //Constructor to initialize message 
        public MoodAnalyse(string message)
        {
            this.message = message;
        }

        //Method to analyse the mood from  the given message
        public string AnalyzeMood()
        {
            if (message.ToLower().Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}

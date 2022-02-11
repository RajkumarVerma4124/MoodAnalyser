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
        //Method to analyse the mood from  the given message
        public string AnalyzeMood(string message)
        {
            if (message.ToLower().Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}

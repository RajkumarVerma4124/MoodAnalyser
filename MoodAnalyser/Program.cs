using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    /// <summary>
    /// Mood analyser program to analyse the mood
    /// </summary>
    public class Program
    {
        //Entry point to the program
        public static void Main(string[] args)
        {
            //Displaying the welcome message
            Console.WriteLine("Welcome To The Mood Analyser Program");

            //Calling the mood analyser object(UC1)
            MoodAnalyse mood = new MoodAnalyse();
            string resMood = mood.AnalyzeMood("I am in Sad Mood");
            string resNewMood = mood.AnalyzeMood("I am in Any Mood");
            Console.WriteLine("The mood is {0}",resMood);
            Console.WriteLine("The mood is {0}", resNewMood);
            Console.ReadLine();
        }
    }
}

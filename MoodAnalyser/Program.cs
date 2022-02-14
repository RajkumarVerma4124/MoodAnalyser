using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static string msg = null;
        //Entry point to the program
        public static void Main(string[] args)
        {
            //Displaying the welcome message
            Console.WriteLine("Welcome To The Mood Analyser Program");

            //Creating the object of mood analyser
            MoodAnalyse moodAnalyse = new MoodAnalyse();
            moodAnalyse.Message = "I am happy today";
            Console.WriteLine();
            TestAnalysisModel(moodAnalyse);
            Console.ReadLine();
        }

        //Method to test the analysis class property
        public static void TestAnalysisModel(MoodAnalyse moodAnalyse)
        {
            ValidationContext context = new ValidationContext(moodAnalyse, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(moodAnalyse, context, validationResults, true);
            if (!valid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine("{0}", validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Satisfied all the validation");
            }
            Console.ReadLine();
        }
    }
}

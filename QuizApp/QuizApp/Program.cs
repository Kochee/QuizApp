using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
/*
Console Exam (quiz) taking app
*/
namespace COMP1202_S20_Assg1_101282062
{
    class Program
    {
        public static void IntroMessage() // Welcome message and rules of the quiz
        {
            string welcome = "Welcome";
            string readRules = "Please read Quiz rules below: ";
            Write(new string(' ', (WindowWidth - welcome.Length) / 2));
            WriteLine(welcome);
            ForegroundColor = ConsoleColor.Red;
            Write(new string(' ', (WindowWidth - readRules.Length) / 2));
            WriteLine(readRules);
            ForegroundColor = ConsoleColor.White;
            WriteLine("\n - The quiz is comprised of five(5) multiple choice questions" +
                "\n - The quiz cannot be saved. Once you start you must finish the quiz" +
                "\n - You have unlimited time to answer the questions." +
                "\n - Four(4) attempts for each question. Once used 4 attempts, the quiz moves to the next question." +
                "\n - to answer a question type lowercase or capital A, B, C or D, based on your choice." +
                "\n - Maximum of 20 points and a minimum of 0 for each question for a maximum of 100 points in total" +
                "\n - Point distribution for one question:" +
                "\n\t  First attempt ====> 20 points" +
                "\n\t  Second atempt ====> 10 points" +
                "\n\t  Third atempt =====>  5 points" +
                "\n\t  Fourth attempt ===>  0 points\n\n");
        } //End Welcome message and quiz ruless
        public static int CalcPoints(Dictionary<string, string>[] qPool) // Calculate the marks scored by the user
        {
            int totalPoints = 0;
            for (int i = 0; i <= 4; i++)
            {
                if (qPool[i]["attempts"] == "1")
                {
                    totalPoints += 20;
                }
                else if (qPool[i]["attempts"] == "2")
                {
                    totalPoints += 10;
                }
                else if (qPool[i]["attempts"] == "3")
                {
                    totalPoints += 5;
                }
                else
                {
                    totalPoints += 0;
                }
            }
            return totalPoints;
        } //End of calculating marks scored
        public static void ExitMessage(int points, string fName, Dictionary<string, string>[] qPool) //Build Progress Report
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("MMMM dd, yyyy HH:mm:ss");
            WriteLine("Date and Time: {0}" +
                "\nUser Name: {1}" +
                "\nMarks scored: {2}" +
                "\nPercentage scored: {3:p0}" +
                "\nNumber of attempts for each question:", formattedTime, fName, points, points * 0.01);
            for (int i = 0; i <= 4; i++)
            {
                string attempt = int.Parse(qPool[i]["attempts"]) > 1 ? "attempts" : "attempt";
                WriteLine(" Question {0}: {1} {2}", i + 1, qPool[i]["attempts"], attempt);
            }
        } //End building progress report
        static void Main(string[] args)
        {
            // Create an array to perform as Pool of Questions AND 
            // instantiate five dictionaries each containing keys and values for one question, four answers, correct answer, and the attempts.
            Dictionary<string, string>[] qPool = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
                new Dictionary<string, string>()
            }; //End initiating Pool of Questions Array

            //Create Question 1
            Dictionary<string, string> Q1 = new Dictionary<string, string>()
            {
                {"Question", "Select the Capital of Albania" },
                { "A", "Prishtine"},
                { "B", "Shkoder"},
                { "C", "Shkup"},
                { "D", "Tirane" },
                { "correct", "D" },
                { "attempts", "0" }
            };
            qPool[0] = Q1; // Add Question 1 to the Pool of Questions

            //Create Question 2
            Dictionary<string, string> Q2 = new Dictionary<string, string>()
            {
                {"Question", "How many strings has a mandolin got?" },
                { "A", "One (1)"},
                { "B", "Five (5)"},
                { "C", "Eight (8)"},
                { "D", "Six (6)" },
                { "correct", "C" },
                { "attempts", "0" }
            };
            qPool[1] = Q2; // Add Question 2 to the Pool of Questions

            //Create Question 3
            Dictionary<string, string> Q3 = new Dictionary<string, string>()
            {
                {"Question", "Who is the drummer of Metallica?" },
                { "A", "Mike Tyson"},
                { "B", "Lars Ulrich"},
                { "C", "Lars Larsen"},
                { "D", "Michael Jackson" },
                { "correct", "B" },
                { "attempts", "0" }
            };
            qPool[2] = Q3; // Add Question 3 to the Pool of Questions

            //Create Question 4
            Dictionary<string, string> Q4 = new Dictionary<string, string>()
            {
                {"Question", "Which car won Fernando Alonso his first tittle in Formula 1 with?" },
                { "A", "Ferrari"},
                { "B", "BMW"},
                { "C", "Fiat"},
                { "D", "Renault" },
                { "correct", "D" },
                { "attempts", "0" }
            };
            qPool[3] = Q4; // Add Question 4 to the Pool of Questions

            //Create Question 5
            Dictionary<string, string> Q5 = new Dictionary<string, string>()
            {
                {"Question", "What is the name of the Barcelona football stadium?" },
                { "A", "Camp Nou"},
                { "B", "Barcelona"},
                { "C", "Camping"},
                { "D", "Real" },
                { "correct", "A" },
                { "attempts", "0" }
            };
            qPool[4] = Q5; // Add Question 5 to the Pool of Questions

            //Welcome message and rules of the quiz.
            IntroMessage();
            Write("Please enter your full name and press Enter/Return to take the quiz: ");
            string fName = ReadLine(); //Register user's full name.
            Clear();

            // Begin the quiz
            for (int i = 0; i < qPool.Length; i++)
            {
                // Display the question and 4 optional answers
                WriteLine("Question " + (i + 1) + ": " + qPool[i]["Question"] + "\n" +
                    "A.  " + qPool[i]["A"] + "\n" +
                    "B.  " + qPool[i]["B"] + "\n" +
                    "C.  " + qPool[i]["C"] + "\n" +
                    "D.  " + qPool[i]["D"] + "\n");

                int attempts = 1;
                while (attempts != 5)
                {
                    // Ask user to answer the question
                    Write("Enter your answer: ");
                    string answer = ReadLine().ToUpper();

                    if (answer != qPool[i]["correct"]) //If answer is incorrect
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Wrong Answer. You have {0} attempts left", 4 - attempts);
                        ForegroundColor = ConsoleColor.White;
                        qPool[i]["attempts"] = Convert.ToString(attempts); //Store number of attempts for each question
                        attempts++;
                    }
                    else if (answer == qPool[i]["correct"]) //If answer is correct
                    {
                        qPool[i]["attempts"] = Convert.ToString(attempts); //Store number of attempts for each question
                        int points = 0;
                        if (qPool[i]["attempts"] == "1")//Calculate points earned for current question
                        {
                            points = 20;
                        }
                        else if (qPool[i]["attempts"] == "2")
                        {
                            points = 10;
                        }
                        else if (qPool[i]["attempts"] == "3")
                        {
                            points = 5;
                        }
                        else { points = 0; }

                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Correct! {0} points", points);
                        ForegroundColor = ConsoleColor.White;
                        WriteLine("Press any key to continue");
                        ReadKey();
                        attempts = 5; // End the loop by reaching the counter limit rather than checking for condition
                        Clear();
                    }
                } // End of (while loop) checking for answers
                Clear();
            } // End of (for loop)/All questions asked 

            //Display Progress Report
            ExitMessage(CalcPoints(qPool), fName, qPool);
            /*END*/
            ReadLine();
        } //END MAIN
    }
}
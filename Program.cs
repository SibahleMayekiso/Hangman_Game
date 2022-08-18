using System;
using System.Collections.Generic;

namespace Hangman_Game
{
    class Program
    {

        enum eDifficulty
        {
            EASY,
            MEDIUM,
            HARD
        }

        static void Main(string[] args)
        {
            List<string> wordList = new List<string>();
            string[] words = {"hello", "bingo", "world", "this", "game", "is", "hangman"};
            wordList.AddRange(words);

            RoundController(WordSelector(wordList), DifficultySelector());
        }

        //Methods that select a random wordfrom a list
        public static string WordSelector(List<string> list)
        {
            Random rndGenerator = new Random();
            int randomIndex = rndGenerator.Next(0, list.Count);


            return list[randomIndex];
        }

        //Prompts the user to select a difficulty
        public static int DifficultySelector()
        {
            Console.WriteLine($"Select Difficulty: \n1.{eDifficulty.EASY.ToString()}\n2.{eDifficulty.MEDIUM.ToString()}\n3.{eDifficulty.HARD.ToString()}");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("=================================================");

            return userInput;
        }

        //Controlls the game implementation based on parameters
        public static void RoundController(string word, int difficulty)
        {
            int wordLength = word.Length;
            string strdifficultylvl = "";
            int attemptCount = 0;
            int maxAttempt = 24;
            bool wordMatchFlag = false;

            
            //Takes the random word and creates a blank template for it
            string[] arrBlankedWord = new string[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                arrBlankedWord[i] = "_";
            }
            //Convert word to char array
            char[] arrWord = new char[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                arrWord[i] = word[i];

            }

            //Switch statement controls the difficulty
            switch (difficulty)
            {
                case 1:
                    strdifficultylvl = "EASY";
                    maxAttempt /= 2;
                    break;
                case 2:
                    strdifficultylvl = "MEDIUM";
                    maxAttempt /= 3;
                    break;
                case 3:
                    strdifficultylvl = "HARD";
                    maxAttempt /= 4;
                    break;

                default: break;
            }


            
            



            while (attemptCount <= maxAttempt || wordMatchFlag == !true)
            {
                //Displays word with spacers
                foreach (var i in arrBlankedWord)
                {
                    Console.Write($"{i} ");
                };
                Console.WriteLine();
                Console.WriteLine("=================================================");

                //
                string strWordCheck = "";
                Console.WriteLine($"Difficulty: {strdifficultylvl}\nMax Attempts Allowed: {maxAttempt}\nAttempts: {attemptCount}");
                Console.WriteLine("=================================================");
                Console.WriteLine("Please enter a letter:");

                char userInput = 'A';
                #region

                //User input validation
                try
                    {
                        userInput = Convert.ToChar(Console.ReadLine().ToLower());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                #endregion

                Console.WriteLine("=================================================\n");

                if (Array.Exists(arrWord, element => element == userInput))
                {
                    arrBlankedWord[Array.IndexOf(arrWord, userInput)] = userInput.ToString();
                    
                    /*foreach (var i in arrBlankedWord)
                    {
                        Console.Write($"{i} ");
                    };
                    Console.WriteLine();
                    Console.WriteLine("=================================================");*/
                }
                /*else
                {
                    /*foreach (var i in arrBlankedWord)
                    {
                        Console.Write($"{i} ");
                    };
                    
                    Console.WriteLine();
                    Console.WriteLine("=================================================");
                }*/

                

                foreach (var c in arrBlankedWord)
                {
                    strWordCheck += c;
                }
                if (strWordCheck == word)
                {
                    wordMatchFlag = true;
                }




                attemptCount++;
                if (wordMatchFlag == true)
                {
                    Console.WriteLine("Congratulations!!!!!!!!!!!");
                    break;
                }
                else if (attemptCount >= maxAttempt)
                {
                    Console.WriteLine("Failure!!!!!!!!!!!");
                    break;
                }
            }
            
        }
    }
}

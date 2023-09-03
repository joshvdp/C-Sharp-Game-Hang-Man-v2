using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hang_Man_v2
{
    class Hang_Man_Program
    {
        static int letterCount = 0;
        static void Main(string[] args)
        {
            Random shuffle = new Random();
            List <string> wordStorage = new List <string> { "apple", "samsung", "xiaomi", "vivo", "oppo", "realme" };
            int s = shuffle.Next(wordStorage.Count);
            String pickedWord = wordStorage[s];

            int rightWords = pickedWord.Length;
            int timesWrong = 0;
            List<char> lettersGuessed = new List<char>();
            int correctGuessed = 0;

            Console.WriteLine(s); //beta count

            print("\nWelcome to Hangman Game!\n");
            print("\n +====+\n" +
                     " |    O\n" +
                     " |   /|\\ \n" +
                     " |   / \\ \n" +
                     " |\n");
            print("\nMake a Guess: Phone Brands e.g. Cherry Mobile, LG etc.");
            print("\n------------------------------\n\n");

            foreach (char k in pickedWord) //letter counter 
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                print("\u0305 "); 
                letterCount++;
            }

            print("\n" + "This is a " + letterCount + " Letter Word");
            print("\n------------------------------");
            while (timesWrong != 6 && correctGuessed != rightWords)
            {
                print("\nLetters Typed: ");
                foreach (char letters in lettersGuessed) 
                {
                    print("[" + letters + "]");
                }

                print("\nEnter a Letter Make a Guess: "); //user input
                char guessedLetter = Console.ReadLine()[0];
                print("------------------------------\n");

                if (lettersGuessed.Contains(guessedLetter)) //already guessed
                {
                    print("\n[You already used this letter!]\n");
                    drawHangman(timesWrong);
                    correctGuessed = printV(lettersGuessed, pickedWord);
                    print("\r\n");
                    printPicked(pickedWord);
                    print("\n" + "This is a " + letterCount + " Letter word");
                    print("\n------------------------------");
                }
                else
                {

                Boolean right = false;
                    for (int i = 0; i < pickedWord.Length; i++)
                    {
                        if (guessedLetter == pickedWord[i])
                        {
                            right = true;
                        }
                    }
                    if (right)
                    {
                        drawHangman(timesWrong);
                        lettersGuessed.Add(guessedLetter);
                        correctGuessed = printV(lettersGuessed, pickedWord);
                        print("\r\n");
                        printPicked(pickedWord);
                        print("\n" + "This is a " + letterCount + " Letter word"); 
                        print("\n------------------------------");
                    }
                    else //wrong
                    {
                        timesWrong++;
                        lettersGuessed.Add(guessedLetter);
                        drawHangman(timesWrong);
                        correctGuessed = printV(lettersGuessed, pickedWord);
                        print("\r\n");
                        printPicked(pickedWord);
                        print("\n" + "This is a " + letterCount + " Letter word");
                        print("\n------------------------------");
                    }
                }
            }
            if (correctGuessed == rightWords)
            {
                print("\r\nCongratulations! YOU WON!\n");
                print("\nThe man has been saved!\n");
                print("\nBy: Dela Peña, Joshua Ver S.\n2BSEMC-GD-2\n\n");
            }
            else if (timesWrong == 6)
            {
                print("\r\nBetter luck next time! \n");
                print("\nBy: Dela Peña, Joshua Ver S.\n2BSEMC-GD-2\n\n");
            }   
        

        static void drawHangman(int wrongAttempt)
            {
                if (wrongAttempt == 0)
                {
                    print("\n +====+\n" +
                      " |\n" +
                      " |\n" +
                      " |\n" +
                      " |\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }
                else if (wrongAttempt == 1)
                {
                    print("\n +====+\n" +
                        " |    O\n" +
                        " |\n" +
                        " |\n" +
                        " |\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }
                else if (wrongAttempt == 2)
                {
                    print("\n +====+\n" +
                         " |    O\n" +
                         " |    |\n" +
                         " |\n" +
                         " |\n");   
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }
                else if (wrongAttempt == 3)
                {
                    print("\n +====+\n" +
                         " |    O\n" +
                         " |    |\\ \n" +
                         " |\n" +
                         " |\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;

                }
                else if (wrongAttempt == 4)
                {
                    print("\n +====+\n" +
                          " |    O\n" +
                          " |   /|\\ \n" +
                          " |\n" +
                          " |\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;

                }
                else if (wrongAttempt == 5)
                {
                    print("\n +====+\n" +
                          " |    O\n" +
                          " |   /|\\ \n" +
                          " |     \\ \n" +
                          " |\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }
                else if (wrongAttempt == 6)
                {
                    print("\n +====+\n" +
                          " |    O\n" +
                          " |   /|\\ \n" +
                          " |   / \\ \n" +
                          " |\n");
                    print("\nYou left the man hanging around!\n");
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                }
            }
            static int printV(List<char> guessed, String pickedRandomWord) //print letters
            {
                int x = 0;
                int y = 0; 
                print("\n");
                foreach (char c in pickedRandomWord)
                {
                    if (guessed.Contains(c))
                    {
                        print(c + " "); //correct
                        y++;
                    }
                    else
                    {
                        print("  "); //wrong
                    }
                    x++;
                }
                return y;
            }
            static void printPicked(String picked)
            {
                print("\r"); 
                letterCount = 0;
                foreach (char c in picked)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    print("\u0305 ");
                    letterCount++;
                }
            }
            static void print (String x)
            {
                Console.Write(x);
            }


        }
    }
}

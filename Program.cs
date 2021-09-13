using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PE185_Mozes_Arpad
{
    class Game
    {
        public Game(int numberLength, int numberOfGuesses)
        {
            NumberLength = numberLength;
            NumberOfGuesses = numberOfGuesses;
            Guesses = new int[numberOfGuesses, numberLength];
            Hits = new int[numberOfGuesses];
            Solution = new int[numberLength];
            for (int i = 0; i < numberLength; i++)
            {
                Solution[i] = 0;
            }
        }
        public int NumberLength { get; }
        public int NumberOfGuesses { get; }
        public int[,] Guesses { get; }
        public int[] Hits { get; }
        public int[] Solution { get; }

        public int[] Solve(int depth = 0, int[] givenHits = null)
        {   
            // For the first call copy of the input Hits
            if(depth == 0)
            {
                givenHits = new int[NumberOfGuesses];
                Array.Copy(Hits, givenHits, NumberOfGuesses);
            } 
            
            //Console.Write(depth.ToString() + " ");

            // Trying out each digit from 0 to 9 at this depth
            for (int currentDgt = 0; currentDgt < 10; currentDgt++)
            {
                int[] myHits = new int[NumberOfGuesses];
                Array.Copy(givenHits, myHits, NumberOfGuesses);
                // int[] myHits = givenHits; // Making an own copy of Hits for modifications, making them discardable
                bool wrongDgt = false;

                Solution[depth] = currentDgt; // Supposing that the actual digit is i
                
                // Conditional modification of Hits
                for (int i = 0; i < NumberOfGuesses; i++) // Looking for a match in the guesses
                {
                    if (Guesses[i, depth] == currentDgt) // If found a match then try to reduce the linked hit
                    {
                        if (myHits[i] > 0) // If positive, can be reduced by 1
                        {
                            myHits[i]--;
                        }
                        else // If it is already zero then it cannot be a solution, we can skip this branch of the tree
                        {
                            wrongDgt = true;
                            break;
                        }
                    }
                }

                /*if (myHits.Max() > NumberLength - depth + 1)
                {
                    wrongDgt = true;
                }*/

                // If modifiaction was not possible (satisfying the conditions given by guesses) try the next digit
                if (wrongDgt) {continue; }

                // If modification was possible, and not the last digit then call it iteratively
                if (depth + 1 < NumberLength) { Solve(depth + 1, myHits); }

                // At the last digit check if the conditions of the guesses are satisfied
                if (depth + 1 == NumberLength)
                { if (myHits.Max() == 0) { return Solution; } }
            }

            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Input Reading

            StreamReader sr = new StreamReader(@"..\..\..\input.txt");
            int numberLength = int.Parse(sr.ReadLine());
            int numberOfGuesses = int.Parse(sr.ReadLine());

            var game = new Game(numberLength, numberOfGuesses);
            Console.WriteLine(game.NumberOfGuesses.ToString() + " " + game.NumberLength.ToString());

            for (int i = 0; i < numberOfGuesses; i++)
            {
                string[] line = sr.ReadLine().Split();
                char[] arr = line[0].ToCharArray(0, numberLength);
                for (int j = 0; j < numberLength; j++)
                {
                    game.Guesses[i, j] = int.Parse(arr[j].ToString());
                }
                game.Hits[i] = int.Parse(line[1]);
            }
            sr.Close();
            #endregion

            Console.Write(game.Solve().ToString());
            Console.ReadKey();
        }
    }
}
